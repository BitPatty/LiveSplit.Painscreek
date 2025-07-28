using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace LiveSplit.Painscreek.MemoryReader
{
  public class GameProcessHook : IDisposable
  {
    private Process CachedProcess;
    private readonly List<int> IgnoredProcessIDs = new List<int> { };

    /// <summary>
    /// Attempts to load the game process
    /// </summary>
    /// <returns>The game process or NULL if it could not be found</returns>
    public Process TryLoadPainscreekProcess()
    {
      if (CachedProcess != null && !CachedProcess.HasExited) return CachedProcess;

      CachedProcess?.Dispose();
      CachedProcess = null;

      try
      {
        Process process = TryFindProcess("Painscreek");
        if (process == null) return null;
        Debug.WriteLine($"Found matching process with PID {process.Id}");
        CachedProcess = process;
        return null;

      }
      catch (Win32Exception ex)
      {
        CachedProcess?.Dispose();
        CachedProcess = null;
        return null;
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
      CachedProcess?.Dispose();
      CachedProcess = null;
    }
  }
}
