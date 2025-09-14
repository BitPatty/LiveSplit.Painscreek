using System;

namespace LiveSplit.Painscreek.MemoryReader
{
  internal class BinaryUtils
  {

    public static int ByteArrayToInt32BE(byte[] bytes, int offset = 0)
    {
      byte[] targetBytes = new byte[4]
      {
        bytes[3 + offset],
        bytes[2 + offset],
        bytes[1 + offset],
        bytes[offset]
      };
      return BitConverter.ToInt32(targetBytes, 0);
    }

    public static int ByteArrayToInt32LE(byte[] bytes, int offset = 0)
    {
      byte[] targetBytes = new byte[4]
      {
        bytes[0 + offset],
        bytes[1 + offset],
        bytes[2 + offset],
        bytes[3 + offset]
      };
      return BitConverter.ToInt32(targetBytes, 0);
    }
  }
}
