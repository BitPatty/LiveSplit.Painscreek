using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace LiveSplit.Painscreek.MemoryReader
{
  public class ProcessHook : IDisposable
  {
    private Process GameProcess;
    private readonly List<int> IgnoredProcessIDs = new List<int> { };

    public Process LoadGameProcess()
    {
      TryLoadProcess();
      return GameProcess;
    }

    private bool TryLoadProcess()
    {
      if (GameProcess != null && !GameProcess.HasExited) return true;

      GameProcess?.Dispose();
      GameProcess = null;

      try
      {
        Process targetProcess = TryFindProcess("Painscreek");
        if (targetProcess == null) return false;
        Debug.WriteLine("Found process");
        GameProcess = targetProcess;
        return true;

      }
      catch (Win32Exception ex)
      {
        GameProcess?.Dispose();
        GameProcess = null;
        return false;
      }
    }

    private Process TryFindProcess(string processName)
    {
      foreach (Process process in Process.GetProcessesByName(processName))
      {
        if (IgnoredProcessIDs.Contains(process.Id)) continue;
        if (!process.ProcessName.Equals(processName, StringComparison.OrdinalIgnoreCase)) continue;

        //ProcessModuleWow64Safe module = process.MainModuleWow64Safe();
        //long baseAddress = module.BaseAddress.ToInt64();
        //long entryPointAddress = module.EntryPointAddress.ToInt64();
        //long relativeEntryPointAddress = entryPointAddress - baseAddress;

        //// TODO
        ////if (relativeEntryPointAddress != 0x5493C7)
        ////{
        ////    IgnoredProcessIDs.Add(process.Id);
        ////    continue;
        ////}

        Debug.WriteLine($"Hooking up process {process.Id}");
        return process;
      }

      return null;
    }

    public void Dispose()
    {
      GameProcess?.Dispose();
      GameProcess = null;
    }

  }
}
