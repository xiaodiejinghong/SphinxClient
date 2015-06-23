namespace Jhong.SphinxClient.Enum
{
    /// <summary>
    /// 匹配模式
    /// </summary>
    public enum MatchMode
    {
        /// <summary>
        /// 匹配所有查询词（默认）
        /// </summary>
        SPH_MATCH_ALL = 0,

        /// <summary>
        /// 匹配查询词中的任意一个
        /// </summary>
        SPH_MATCH_ANY = 1,

        /// <summary>
        /// 将整个查询看作一个词组，要求按顺序完整匹配
        /// </summary>
        SPH_MATCH_PHRASE = 2,

        /// <summary>
        /// 将查询看作一个布尔表达式
        /// </summary>
        SPH_MATCH_BOOLEN = 3,

        /// <summary>
        /// 将查询看作一个Sphinx内部查询语言的表达式
        /// </summary>
        SPH_MATCH_EXTENDED = 4,

        /// <summary>
        /// 使用完全扫描，忽略查询词汇
        /// </summary>
        SPH_MATCH_FULLSCAN = 5,

        /// <summary>
        /// 类似 SPH_MATCH_EXTENDED ，并支持评分和权重
        /// </summary>
        SPH_MATCH_EXTENDED2 = 6
    }
}