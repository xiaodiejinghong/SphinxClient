namespace Jhong.SphinxClient.Enum
{
    public enum GroupFunc
    {
        /// <summary>
        /// 从时间戳中按YYYYMMDD格式抽取年、月、日
        /// </summary>
        SPH_GROUPBY_DAY = 0,
        /// <summary>
        /// 从时间戳中按YYYYNNN格式抽取年份和指定周数（自年初计起）的第一天;
        /// </summary>
        SPH_GROUPBY_WEEK = 1,
        /// <summary>
        /// 从时间戳中按YYYYMM格式抽取月份;
        /// </summary>
        SPH_GROUPBY_MONTH = 2,
        /// <summary>
        /// 从时间戳中按YYYY格式抽取年份;
        /// </summary>
        SPH_GROUPBY_YEAR = 3,
        /// <summary>
        /// 使用属性值自身进行分组
        /// </summary>
        SPH_GROUPBY_ATTR = 4,
        /// <summary>
        /// 
        /// </summary>
        SPH_GROUPBY_ATTRPAIR = 5
    }
}