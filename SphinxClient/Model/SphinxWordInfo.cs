namespace Jhong.SphinxClient.Model
{
    public class SphinxWordInfo
    {
        /// <summary>
        /// 词语
        /// </summary>
        public string Word { get; set; }

        /// <summary>
        /// 文档总数
        /// </summary>
        public long Docs { get; set; }

        /// <summary>
        /// 命中次数
        /// </summary>
        public long Hits { get; set; }
    }
}