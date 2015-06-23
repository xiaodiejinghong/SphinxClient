namespace Jhong.SphinxClient.Model
{
    using Jhong.SphinxClient.Enum;
    using System.Collections.Generic;

    internal class SphinxOvrride
    {
        public string Attr { get; set; }

        public IList<long> DocIDs { get; set; }

        public IList<uint> UIntValues { get; set; }

        public int NumValues { get; set; }

        public AttributeType Type { get; set; }
    }
}