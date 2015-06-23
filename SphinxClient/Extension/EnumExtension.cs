using System;

namespace Jhong.SphinxClient.Extension
{
    using Enum;

    internal static class EnumExtension
    {
        internal static byte[] GetBytes(this Command cmd)
        {
            return BitConverter.GetBytes((int)cmd);
        }
    }
}