namespace Jhong.SphinxClient.Extension
{
    using System.Text;

    internal static class StringExtension
    {
        internal static byte[] GetUTF8Bytes(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }
    }
}