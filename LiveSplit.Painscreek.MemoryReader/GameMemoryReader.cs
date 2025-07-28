using LiveSplit.ComponentUtil;
using LiveSplit.Web;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;

namespace LiveSplit.Painscreek.MemoryReader
{
  public class GameMemoryReader : IDisposable
  {
    /// <summary>
    /// Hook to load the game process
    /// </summary>
    private readonly GameProcessHook ProcessHook = new GameProcessHook();

    /// <summary>
    /// Cached data from the game's memory
    /// </summary>
    private readonly GameMemoryReaderCache Cache = new GameMemoryReaderCache();

    /// <summary>
    /// The process ID from which the data was last read
    /// </summary>
    private int LastUsedProcessID;

    // PlayerControl:Awake    - 00 55 48                - add [rbp+48],dl
    // PlayerControl:Awake+2  - 8B EC                   - mov ebp,esp
    // PlayerControl:Awake+4  - 56                      - push rsi
    // PlayerControl:Awake+5  - 48 83 EC 08             - sub rsp,08 { 8 }
    // PlayerControl:Awake+9  - 48 8B F1                - mov rsi,rcx
    // PlayerControl:Awake+c  - 48 83 EC 20             - sub rsp,20 { 32 }
    // PlayerControl:Awake+10 - 49 BB 9082880600000000  - mov r11,Rewired.ReInput:get_players { (-326416299) }
    // PlayerControl:Awake+1a - 41 FF D3                - call r11
    // PlayerControl:Awake+1d - 48 83 C4 20             - add rsp,20 { 32 }
    // PlayerControl:Awake+21 - 48 63 96 34010000       - movsxd  rdx,dword ptr [rsi+00000134]
    // PlayerControl:Awake+28 - 48 8B C8                - mov rcx,rax
    // PlayerControl:Awake+2b - 48 83 EC 20             - sub rsp,20 { 32 }
    // PlayerControl:Awake+2f - 83 38 00                - cmp dword ptr [rax],00 { 0 }
    // PlayerControl:Awake+32 - 49 BB F0F7890600000000  - mov r11,Rewired.ReInput+PlayerHelper:GetPlayer { (-326416299) }
    // PlayerControl:Awake+3c - 41 FF D3                - call r11
    // PlayerControl:Awake+3f - 48 83 C4 20             - add rsp,20 { 32 }
    // PlayerControl:Awake+43 - 48 89 86 C8000000       - mov [rsi+000000C8],rax
    // PlayerControl:Awake+4a - B8 28AF1C06             - mov eax,061CAF28 { (262A9E60) }
    // PlayerControl:Awake+4f - 48 89 30                - mov [rax],rsi
    // PlayerControl:Awake+52 - 48 8B 75 F8             - mov rsi,[rbp-08]
    // PlayerControl:Awake+56 - C9                      - leave 
    // PlayerControl:Awake+57 - C3                      - ret
    private readonly string PlayerControlAwakeSignature = "55 48 8B EC 56 48 83 EC 08 48 8B F1 48 83 EC 20 49 BB ?? ?? ?? ?? ?? ?? ?? ?? 41 FF D3 48 83 C4 20 48 63 96 34 01 00 00 48 8B C8 48 83 EC 20 83 38 00 49 BB ?? ?? ?? ?? ?? ?? ?? ?? 41 FF D3 48 83 C4 20 48 89 86 C8 00 00 00 B8 ?? ?? ?? ?? 48 89 30 48 8B 75 F8 C9 C3";

    // LockTrigger:Update+318 - 41 FF D3               - call r11
    // LockTrigger:Update+31b - 48 83 C4 20            - add rsp,20 { 32 }
    // LockTrigger:Update+31f - 48 8B 04 25 E0BC6505   - mov rax,[0565BCE0] { (2C280900) }
    // LockTrigger:Update+327 - 0FB6 80 D0000000       - movzx eax,byte ptr [rax+000000D0]
    // LockTrigger:Update+32e - 85 C0                  - test eax,eax
    // LockTrigger:Update+330 - 0F84 AC000000          - je LockTrigger:Update+3e2
    // LockTrigger:Update+336 - 48 8B 04 25 E0BC6505   - mov rax,[0565BCE0] { (2C280900) }
    // LockTrigger:Update+33e - 48 8B 40 30            - mov rax,[rax+30]
    // LockTrigger:Update+342 - 48 8B 40 70            - mov rax,[rax+70]
    // LockTrigger:Update+346 - 0FB6 40 24             - movzx eax,byte ptr [rax+24]
    // LockTrigger:Update+34a - 85 C0                  - test eax,eax
    // LockTrigger:Update+34c - 0F85 90000000          - jne LockTrigger:Update+3e2
    // LockTrigger:Update+352 - 48 8B 04 25 E0BC6505   - mov rax,[0565BCE0] { (2C280900) }
    // LockTrigger:Update+35a - 48 8B 40 30            - mov rax,[rax+30]
    // LockTrigger:Update+35e - 48 8B 40 70            - mov rax,[rax+70]
    // LockTrigger:Update+362 - C6 40 24 01            - mov byte ptr [rax+24],01 { 1 }
    // LockTrigger:Update+366 - 48 8B 04 25 F0BB6505   - mov rax,[0565BBF0] { (3DE26170) }
    // LockTrigger:Update+36e - 48 8B 80 90000000      - mov rax,[rax+00000090]
    // LockTrigger:Update+375 - 48 8B 0C 25 E0BC6505   - mov rcx,[0565BCE0] { (2C280900) }
    // LockTrigger:Update+37d - 48 8B 49 30            - mov rcx,[rcx+30]
    // LockTrigger:Update+381 - 48 8B 49 70            - mov rcx,[rcx+70]
    // LockTrigger:Update+385 - 48 8B 51 10            - mov rdx,[rcx+10]
    // LockTrigger:Update+389 - 48 8B C8               - mov rcx,rax
    // LockTrigger:Update+38c - 48 83 EC 20            - sub rsp,20 { 32 }
    // LockTrigger:Update+390 - 83 38 00               - cmp dword ptr [rax],00 { 0 }
    // LockTrigger:Update+393 - 49 BB E872CF0500000000 - mov r11,0000000005CF72E8 { (-1718807576) }
    // LockTrigger:Update+39d - 41 FF D3               - call r11
    private readonly string LockTriggerUpdateSignature = "41 FF D3 48 83 C4 20 48 8B 04 25 ?? ?? ?? ?? 0F B6 80 D0 00 00 00 85 C0 0F 84 AC 00 00 00 48 8B 04 25 ?? ?? ?? ?? 48 8B 40 30 48 8B 40 70 0F B6 40 24 85 C0";

    /// <summary>
    /// Refreshes the game's data
    /// </summary>
    public GameState? RefreshGameState()
    {
      Process process = ProcessHook.TryLoadPainscreekProcess();

      // Clear the data if the process is lost
      if (process == null)
      {
        Debug.WriteLine("Game process not found");
        Reset();
        return null;
      }

      // Clear the data if the process has changed
      if (process.Id != LastUsedProcessID)
      {
        Debug.WriteLine($"Game process ID changed from {LastUsedProcessID} to {process.Id}");
        Reset();
      }

      LastUsedProcessID = process.Id;
      UpdateDataCachesFromMemory(process);
      return ParseGameStateFromDataCache();
    }

    /// <summary>
    /// Parses the game's state from the cached game data
    /// </summary>
    /// <returns>The last read game state or NULL if it is not available</returns>
    private GameState? ParseGameStateFromDataCache()
    {
      byte[] playerControlInstanceData = Cache.CurrentPlayerControlInstanceData;
      if (playerControlInstanceData == null) return null;

      byte[] tutorialInstanceData = Cache.CurrentTutorialInstanceData;
      if (tutorialInstanceData == null) return null;

      byte? flashlightData = Cache.FlashlightData;
      if (!flashlightData.HasValue) return null;

      GameState state = new GameState
      {
        IsPaused = playerControlInstanceData[0xFB] == 1,
        IsInSceneTransition = playerControlInstanceData[0xFF] == 1,
        DoNotUse_IsLoading = playerControlInstanceData[0x100] == 1,
        DoNotUse_LoadingActive = playerControlInstanceData[0x10c] == 1,
        IsEndingScene = playerControlInstanceData[0x107] == 1,
        IsPrologueScene = playerControlInstanceData[0xFE] == 1,
        IsStartMenu = playerControlInstanceData[0xFD] == 1,
        EndingPath = playerControlInstanceData[0x108],
        IsWindowOpen = playerControlInstanceData[0xE8] == 1,
        IsItemObserveOn = playerControlInstanceData[0xF6] == 1,
        OpenWindowID = BinaryUtils.ByteArrayToInt32BE(playerControlInstanceData, 0xEC),
        IsInteracting = playerControlInstanceData[0xF9] == 1,
        IsFlashlightComponentDisabled = flashlightData == 0,
        IsTutorialOn = tutorialInstanceData[0xD2] == 1
      };

#if DEBUG
      //LogStructToDebug(state);
      Debug.WriteLine(Cache.CurrentTutorialInstance.ToString("x"));
      //Debug.WriteLine(state.DoNotUse_LoadingActive);
#endif

      return state;
    }

    /// <summary>
    /// Attempts to load the relevant memory sections from the game process
    /// </summary>
    /// <param name="process">The process</param>
    /// <returns>The data or NULL if it could not be read</returns>
    private void UpdateDataCachesFromMemory(Process process)
    {
      (byte[] PlayerControlData, byte[] TutorialData, byte FlashlightData)? gameData = TryLoadGameData(process);

      if (!gameData.HasValue)
      {
        Cache.CurrentPlayerControlInstanceData = null;
        Cache.CurrentTutorialInstanceData = null;
        return;
      }

      Cache.CurrentPlayerControlInstanceData = gameData.Value.PlayerControlData;
      Cache.CurrentTutorialInstanceData = gameData.Value.TutorialData;
      Cache.FlashlightData = gameData.Value.FlashlightData;
    }

    /// <summary>
    /// Attempts to load the game's data
    /// </summary>
    /// <param name="process">The process</param>
    /// <returns>The game's data or NULL if it could not be loaded</returns>
    private (byte[] PlayerControlData, byte[] TutorialData, byte FlashlightData)? TryLoadGameData(Process process)
    {
      IntPtr? currentPlayerControlInstancePointer = TryFindCurrentPlayerControlInstancePointer(process);
      if (!currentPlayerControlInstancePointer.HasValue) return null;

      IntPtr? currentTutorialInstancePointer = TryFindCurrentTutorialInstancePointer(process);
      if (!currentTutorialInstancePointer.HasValue) return null;

      byte[] playerControlInstanceData = TryLoadPlayerControlData(process, currentPlayerControlInstancePointer.Value);
      if (playerControlInstanceData == null) return null;

      byte[] tutorialData = TryLoadTutorialData(process, currentTutorialInstancePointer.Value);
      if (tutorialData == null) return null;

      byte[] flashlightData = TryReadProcessBytes(process, currentPlayerControlInstancePointer.Value - 8, 1);
      if (flashlightData == null) return null;

      return (PlayerControlData: playerControlInstanceData, TutorialData: tutorialData, FlashlightData: flashlightData[0]);
    }

    /// <summary>
    /// Attempts to find the pointer to the currently active player control instance
    /// </summary>
    /// <param name="process">The process</param>
    /// <returns>The pointer or NULL if it could not be read/found</returns>
    private IntPtr? TryFindCurrentPlayerControlInstancePointer(Process process)
    {
      if (Cache.CurrentPlayerControlInstance != IntPtr.Zero) return Cache.CurrentPlayerControlInstance;

      byte[] instancePointerBytes = TryFindFirstSignatureMatch(process, PlayerControlAwakeSignature, 0x4B, 4);
      if (instancePointerBytes == null)
      {
        Debug.WriteLine("Could not find signature match for PlayerControl:Awake");
        Cache.CurrentPlayerControlInstance = IntPtr.Zero;
        return null;
      }

      IntPtr instancePointer = IntPtr.Zero + BinaryUtils.ByteArrayToInt32LE(instancePointerBytes);
      Debug.WriteLine($"Found player control instance pointer at {instancePointer.ToString("x")}");
      Cache.CurrentPlayerControlInstance = instancePointer;
      return instancePointer;
    }

    /// <summary>
    /// Attempts to find the pointer to the currently active tutorial instance
    /// </summary>
    /// <param name="process">The process</param>
    /// <returns>The pointer or NULL if it could not be read/found</returns>
    private IntPtr? TryFindCurrentTutorialInstancePointer(Process process)
    {
      if (Cache.CurrentTutorialInstance != IntPtr.Zero) return Cache.CurrentTutorialInstance;

      byte[] instancePointerBytes = TryFindFirstSignatureMatch(process, LockTriggerUpdateSignature, 0xB, 4);
      if (instancePointerBytes == null)
      {
        Debug.WriteLine("Could not find signature match for Tutorial:Update");
        Cache.CurrentTutorialInstance = IntPtr.Zero;
        return null;
      }


      IntPtr instancePointer = IntPtr.Zero + BinaryUtils.ByteArrayToInt32LE(instancePointerBytes);
      Debug.WriteLine($"Found tutorial instance pointer at {instancePointer.ToString("x")}");
      Cache.CurrentTutorialInstance = instancePointer;
      return instancePointer;
    }

    ///// <summary>
    ///// Attempts to load the data of a fadeout texture instance
    ///// </summary>
    ///// <param name="process">The process</param>
    ///// <param name="playerControlInstanceData">The data of the player control instance</param>
    ///// <returns>The fadeout texture data or NULL if it could not be read</returns>
    //private byte[] TryLoadFadeoutTextureData(Process process, byte[] playerControlInstanceData)
    //{
    //  byte[] texturePointerBytes = new byte[4] {
    //    playerControlInstanceData[0xB0],
    //    playerControlInstanceData[0xB1],
    //    playerControlInstanceData[0xB2],
    //    playerControlInstanceData[0xB3]
    //  };

    //  IntPtr texturePointer = IntPtr.Zero + BinaryUtils.ByteArrayToInt32LE(texturePointerBytes);
    //  // TODO
    //  return TryReadProcessBytes(process, texturePointer, 0x140);
    //}

    /// <summary>
    /// Tries to load the data of a player control instance
    /// </summary>
    /// <param name="process">The process</param>
    /// <param name="playerControlInstancePointer">The pointer to the player control instance</param>
    /// <returns>The player control data or NULL if it could not be read</returns>
    private byte[] TryLoadPlayerControlData(Process process, IntPtr playerControlInstancePointer)
    {
      if (playerControlInstancePointer == IntPtr.Zero) return null;
      IntPtr? instancePointer = TryReadPointerAddress32(process, playerControlInstancePointer);
      if (!instancePointer.HasValue) return null;
      return TryReadProcessBytes(process, instancePointer.Value, 0x140);
    }

    /// <summary>
    /// Tries to load the data of a tutorial instance
    /// </summary>
    /// <param name="process">The process</param>
    /// <param name="tutorialInstancePointer">The pointer to the tutorial instance</param>
    /// <returns>The tutorial data or NULL if it could not be read</returns>
    private byte[] TryLoadTutorialData(Process process, IntPtr tutorialInstancePointer)
    {
      if (tutorialInstancePointer == IntPtr.Zero) return null;
      IntPtr? instancePointer = TryReadPointerAddress32(process, tutorialInstancePointer);
      if (!instancePointer.HasValue) return null;
      return TryReadProcessBytes(process, instancePointer.Value, 0xE5);
    }


    /// <summary>
    /// Tries to read a 32 bit pointer address at the specified offset
    /// </summary>
    /// <param name="process">The process</param>
    /// <param name="offset">The offset from the entrypoint of where the pointer is located</param>
    /// <returns>The pointer or NULL if it could not be read</returns>
    private IntPtr? TryReadPointerAddress32(Process process, IntPtr offset)
    {
      if (offset == IntPtr.Zero) return null;
      byte[] pointerData = TryReadProcessBytes(process, offset, 4);
      if (pointerData == null) return null;
      return IntPtr.Zero + BinaryUtils.ByteArrayToInt32LE(pointerData);
    }


    /// <summary>
    /// Attempts to read bytes from the process memory
    /// </summary>
    /// <param name="process">The process</param>
    /// <param name="offset">The offset from the entrypoint of where to start reading bytes</param>
    /// <param name="length">The number of bytes to read</param>
    /// <returns>The read bytes or NULL if they could not be read</returns>
    private byte[] TryReadProcessBytes(Process process, IntPtr offset, int length)
    {
      try
      {
        byte[] data = process.ReadBytes(offset, length);
        if (data == null)
          Debug.WriteLine($"Could not read {length} bytes at {offset.ToString("x")}: null");

        return data;
      }
      catch (Exception e)
      {
        Debug.WriteLine($"Could not read {length} bytes at {offset.ToString("x")}: {e.Message}");
        return null;
      }
    }

    /// <summary>
    /// Attempts to find the specified signature in the process
    /// </summary>
    /// <param name="process">The process to find the signature in</param>
    /// <param name="signature">The signature</param>
    /// <param name="offset">The offset from signature start of where to start reading bytes from</param>
    /// <param name="length">The number of bytes to read</param>
    /// <returns>The read bytes or NULL if they could not be read</returns>
    private byte[] TryFindFirstSignatureMatch(Process process, string signature, int offset, int length)
    {
      try
      {
        foreach (var page in process.MemoryPages())
        {
          SignatureScanner scanner = new SignatureScanner(process, page.BaseAddress, (int)page.RegionSize);
          SigScanTarget target = new SigScanTarget(offset, signature);
          IntPtr match = scanner.Scan(target);
          if (match == IntPtr.Zero) continue;
          byte[] data = TryReadProcessBytes(process, match, length);
          if (data != null) return data;
        }

        return null;
      }
      catch (Exception e)
      {
        Debug.WriteLine($"Failed to read signature data for '{signature}' at {offset}: {e.Message}");
        return null;
      }
    }

    /// <summary>
    /// Resets the stored data
    /// </summary>
    private void Reset()
    {
      LastUsedProcessID = 0;
      Cache.Reset();
    }

    /// <summary>
    /// Logs a struct to the debug channel
    /// </summary>
    /// <typeparam name="T">The struct type</typeparam>
    /// <param name="obj">The struct</param>
    private static void LogStructToDebug<T>(T obj) where T : struct
    {
      foreach (var field in typeof(T).GetFields())
        Debug.WriteLine($"{field.Name}: {field.GetValue(obj)}");
    }

    /// <summary>
    /// Disposes the reader
    /// </summary>
    public void Dispose()
    {
      ProcessHook.Dispose();
    }
  }
}
