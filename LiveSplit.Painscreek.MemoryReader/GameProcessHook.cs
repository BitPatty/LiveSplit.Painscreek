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
      catch (Win32Exception)
      {
        CachedProcess?.Dispose();
        CachedProcess = null;
        return null;
      }
    }

    /// <summary>
    /// Attempts to find the process with the specified name
    /// </summary>
    /// <param name="processName">The process name</param>
    /// <returns>The matching process or NULL if it wasn't found</returns>
    private Process TryFindProcess(string processName)
    {
      foreach (Process process in Process.GetProcessesByName(processName))
      {
        if (IgnoredProcessIDs.Contains(process.Id)) continue;
        if (!process.ProcessName.Equals(processName, StringComparison.OrdinalIgnoreCase)) continue;
        return process;
      }

      return null;
    }

    /// <summary>
    /// Disposes the instance
    /// </summary>
    public void Dispose()
    {
      CachedProcess?.Dispose();
      CachedProcess = null;
    }
  }
}
