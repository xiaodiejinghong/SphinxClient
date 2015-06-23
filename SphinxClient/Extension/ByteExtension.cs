namespace Jhong.SphinxClient.Extension
{
    /// <summary>
    ///
    /// </summary>
    internal static class ByteExtension
    {
        /// <summary>
        /// 反转
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        internal unsafe static byte[] ReverseX(this byte[] buffer)
        {
            byte tmp;
            var length = buffer.Length;
            var count = length / 2;
            byte* start, end;
            fixed (byte* b = buffer)
            {
                start = b;
                end = b + length - 1;
                while (count > 0)
                {
                    count--;
                    tmp = *start;
                    *start = *end;
                    *end = tmp;
                    start++;
                    end--;
                }
            }
            return buffer;
        }
    }
}