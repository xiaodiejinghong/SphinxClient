namespace Jhong.SphinxClient.Model
{
    using System.Collections.Generic;

    public class SphinxResult
    {
        public IList<string> Fields { get; set; }

        public IList<string> AttrName { get; set; }

        public IList<int> AttrTypes { get; set; }

        public IList<SphinxMatch> Matches { get; set; }

        public int Total { get; set; }

        public int TotalFound { get; set; }

        public float Time { get; set; }

        public IList<SphinxWordInfo> Words { get; set; }

        public int Status { get; set; }

        public string ErrStr { get; set; }

        public string WarnStr { get; set; }
    }
}