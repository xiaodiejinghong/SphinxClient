namespace Jhong.SphinxClient.Enum
{
    public enum RankingMode
    {
        SPH_RANK_PROXIMITY_BM25 = 0,
        SPH_RANK_BM25 = 1,
        SPH_RANK_NONE = 2,
        SPH_RANK_WORDCOUNT = 3,
        SPH_RANK_PROXIMITY = 4,
        SPH_RANK_MATCHANY = 5,
        SPH_RANK_FIELDMASK = 6,
        SPH_RANK_SPH04 = 7,
        SPH_RANK_EXPR = 8,
        SPH_RANK_TOTAL = 9
    }
}