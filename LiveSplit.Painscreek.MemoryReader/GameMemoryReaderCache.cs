using System;

namespace LiveSplit.Painscreek.MemoryReader
{
  public class GameMemoryReaderCache
  {
    /// <summary>
    /// The pointer to the current player control instance
    /// </summary>
    public IntPtr CurrentPlayerControlInstance = IntPtr.Zero;

    /// <summary>
    /// The pointer to the current tutorial instance
    /// </summary>
    public IntPtr CurrentTutorialInstance = IntPtr.Zero;

    /// <summary>
    /// The data of the current player control instance
    /// </summary>
    public byte[] CurrentPlayerControlInstanceData = null;

    /// <summary>
    /// The data of the current tutorial instance
    /// </summary>
    public byte[] CurrentTutorialInstanceData = null;

    /// <summary>
    /// The flashlight configuration
    /// </summary>
    public byte? FlashlightData = null;

    /// <summary>
    /// Resets all cached values
    /// </summary>
    public void Reset()
    {
      CurrentPlayerControlInstance = IntPtr.Zero;
      CurrentTutorialInstance = IntPtr.Zero;
      CurrentPlayerControlInstanceData = null;
      CurrentTutorialInstanceData = null;
      FlashlightData = null;
    }
  }
}
