using LiveSplit.ComponentUtil;
using System;
using System.Diagnostics;

namespace LiveSplit.Painscreek.MemoryReader
{
  internal class GameMemory : IDisposable
  {
    public bool IsLoaded => PlayerControlInstancePointer != IntPtr.Zero;

    private readonly ProcessHook GameProcess = new ProcessHook();
    private readonly string PlayerControlAwakeSignature = "55 48 8B EC 56 48 83 EC 08 48 8B F1 48 83 EC 20 49 BB ?? ?? ?? ?? ?? ?? ?? ?? 41 FF D3 48 83 C4 20 48 63 96 34 01 00 00 48 8B C8 48 83 EC 20 83 38 00 49 BB ?? ?? ?? ?? ?? ?? ?? ?? 41 FF D3 48 83 C4 20 48 89 86 C8 00 00 00 B8 ?? ?? ?? ?? 48 89 30 48 8B 75 F8 C9 C3";
    private IntPtr PlayerControlInstancePointer;
    private int ProcessID;

    public byte[] TryLoadPlayerControlData()
    {
      Process process = GameProcess.LoadGameProcess();

      // Clear the data if the process is lost
      if (process == null)
      {
        Debug.WriteLine("Process not found");
        if (IsLoaded) Reset();
        return null;
      }

      // Update the pointer to the player control instance if the process has changed
      if (process.Id != ProcessID)
      {
        Debug.WriteLine($"Process ID changed from {ProcessID} to {process.Id}");
        ProcessID = process.Id;
        TryUpdatePlayerControlInstancePointer(process);
      }

      // Clear the data if the player control instance could not be located
      if (PlayerControlInstancePointer == IntPtr.Zero)
      {
        Debug.WriteLine("Player control instance pointer not found");
        Reset();
        return null;
      }

      // Load the player control data
      return TryLoadPlayerControlData(process);
    }

    private void TryUpdatePlayerControlInstancePointer(Process process)
    {
      byte[] instancePointerBytes = TryFindSignature(process, PlayerControlAwakeSignature, 0x4B, 4);

      if (instancePointerBytes == null)
      {
        Debug.WriteLine("Could not find signature match");
        PlayerControlInstancePointer = IntPtr.Zero;
        return;
      }

      IntPtr instancePointer = IntPtr.Zero;
      instancePointer += instancePointerBytes[0];
      instancePointer += instancePointerBytes[1] << 8;
      instancePointer += instancePointerBytes[2] << 16;
      instancePointer += instancePointerBytes[3] << 24;

      PlayerControlInstancePointer = instancePointer;
    }

    private byte[] TryLoadPlayerControlData(Process process)
    {
      byte[] currentInstancePointerBytes = process.ReadBytes(PlayerControlInstancePointer, 4);
      if (currentInstancePointerBytes == null)
      {
        Debug.WriteLine("Could not find instance pointer");
        return null;
      }

      IntPtr currentInstancePointer = IntPtr.Zero;
      currentInstancePointer += currentInstancePointerBytes[0];
      currentInstancePointer += currentInstancePointerBytes[1] << 8;
      currentInstancePointer += currentInstancePointerBytes[2] << 16;
      currentInstancePointer += currentInstancePointerBytes[3] << 24;

      return process.ReadBytes(currentInstancePointer, 0x140);
    }

    private byte[] TryFindSignature(Process process, string signature, int offset, int length)
    {
      foreach (var page in process.MemoryPages())
      {
        SignatureScanner scanner = new SignatureScanner(process, page.BaseAddress, (int)page.RegionSize);
        SigScanTarget target = new SigScanTarget(offset, signature);
        IntPtr match = scanner.Scan(target);
        if (match == IntPtr.Zero) continue;
        return process.ReadBytes(match, length);
      }

      return null;
    }

    private void Reset()
    {
      PlayerControlInstancePointer = IntPtr.Zero;
      ProcessID = 0;
    }

    public void Dispose()
    {
      GameProcess.Dispose();
    }
  }
}
