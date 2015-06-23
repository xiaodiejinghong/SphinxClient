namespace Jhong.SphinxClient.Model
{
    using System.Collections.Generic;

    public class SphinxMatch
    {
        /// <summary>
        /// 命中文档ID
        /// </summary>
        public long DocID { get; set; }

        /// <summary>
        /// 文档权重
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// 其他零碎信息
        /// </summary>
        public IList<object> AttrValues { get; set; }
    }
}