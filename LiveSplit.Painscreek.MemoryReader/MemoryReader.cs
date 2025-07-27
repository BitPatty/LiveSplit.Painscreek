using System;
using System.Diagnostics;
using System.Threading;

namespace LiveSplit.Painscreek.MemoryReader
{
  public class MemoryReader : IDisposable
  {
    private static readonly GameMemory Memory = new GameMemory();

    public GameState? CurrentGameState { get; private set; } = null;

    private readonly Mutex UpdateMutex = new Mutex();

    public void UpdateGameState()
    {
      if (!UpdateMutex.WaitOne(10))
        return;

      try
      {
        byte[] memoryData = Memory.TryLoadPlayerControlData();

        if (memoryData == null)
        {
          CurrentGameState = null;
          return;
        }

        CurrentGameState = new GameState
        {
          IsPaused = memoryData[0xFB] == 1,
          LevelLoading = memoryData[0xFF] == 1,
          IsLoading = memoryData[0x100] == 1,
          LoadingActive = memoryData[0x10c] == 1
        };

        Debug.WriteLine($"Is Paused: {CurrentGameState.Value.IsPaused} / Is Loading: {CurrentGameState.Value.IsLoading} / {CurrentGameState.Value.LevelLoading} / {CurrentGameState.Value.LoadingActive}");
      }
      finally
      {
        UpdateMutex.ReleaseMutex();
      }
    }

    public void Dispose()
    {
      Memory.Dispose();
    }

  }
}
