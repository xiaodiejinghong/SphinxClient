namespace Jhong.SphinxClient.Model
{
    using Jhong.SphinxClient.Enum;
    using System.Collections.Generic;

    public class SphinxFilter
    {
        public FilterType Type { get; set; }

        public string Attr { get; set; }

        public string Exclude { get; set; }

        public List<int> Values { get; set; }

        public uint UMin { get; set; }

        public uint UMax { get; set; }

        public float FMin { get; set; }

        public float FMax { get; set; }

        public string SValue { get; set; }
    }
}