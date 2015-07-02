namespace Jhong.SphinxClient.Enum
{
    public enum RankingMode
    {
        /// <summary>
        /// 默认模式
        /// </summary>
        SPH_RANK_PROXIMITY_BM25 = 0,
        /// <summary>
        /// 统计相关度计算模式
        /// </summary>
        SPH_RANK_BM25 = 1,
        /// <summary>
        /// 禁用评分的模式
        /// </summary>
        SPH_RANK_NONE = 2,
        /// <summary>
        /// 根据关键词出现次数排序
        /// </summary>
        SPH_RANK_WORDCOUNT = 3,
        /// <summary>
        /// 将原始的词组相似度作为结果返回
        /// </summary>
        SPH_RANK_PROXIMITY = 4,
        /// <summary>
        /// 返回之前在SPH_MATCH_ANY中计算的位次
        /// </summary>
        SPH_RANK_MATCHANY = 5,
        /// <summary>
        /// 返回一个32位掩码
        /// </summary>
        SPH_RANK_FIELDMASK = 6,
        /// <summary>
        /// 
        /// </summary>
        SPH_RANK_SPH04 = 7,
        /// <summary>
        /// 
        /// </summary>
        SPH_RANK_EXPR = 8,
        /// <summary>
        /// 
        /// </summary>
        SPH_RANK_TOTAL = 9
    }
}