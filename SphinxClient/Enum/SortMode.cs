namespace Jhong.SphinxClient.Enum
{
    public enum SortMode
    {
        /// <summary>
        /// 按相关度降序排列（最好的匹配排在最前面）
        /// </summary>
        SPH_SORT_RELEVANCE = 0,
        /// <summary>
        /// 按属性降序排列 （属性值越大的越是排在前面）
        /// </summary>
        SPH_SORT_ATTR_DESC = 1,
        /// <summary>
        /// 按属性升序排列（属性值越小的越是排在前面）
        /// </summary>
        SPH_SORT_ATTR_ASC = 2,
        /// <summary>
        /// 先按时间段（最近一小时/天/周/月）降序，再按相关度降序
        /// </summary>
        SPH_SORT_TIME_SEGMENTS = 3,
        /// <summary>
        /// 按一种类似SQL的方式将列组合起来，升序或降序排列
        /// </summary>
        SPH_SORT_EXTENDED = 4,
        /// <summary>
        /// 按某个算术表达式排序
        /// </summary>
        SPH_SORT_EXPR = 5
    }
}