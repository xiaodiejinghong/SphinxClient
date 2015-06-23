namespace Jhong.SphinxClient.Model
{
    public class SphinxBuildExceptsOptions
    {
        public string BeforeMatch { get; private set; }

        public string AfterMatch { get; private set; }

        public string ChunkSeparator { get; private set; }

        public int Limit { get; private set; }

        public int Around { get; private set; }

        public bool ExactPhrase { get; private set; }

        public bool SinglePassage { get; private set; }

        public bool UseBoundaries { get; private set; }

        public bool WeightOrder { get; private set; }

        public SphinxBuildExceptsOptions(string beforeMatch = "<b>", string afterMatch = "</b>", string chunkSeparator = " ... ", int limit = 256, int around = 5, bool exactphrase = false, bool singlePassage = false, bool useBoundaries = false, bool weightOrder = false)
        {
            this.BeforeMatch = beforeMatch;
            this.AfterMatch = afterMatch;
            this.ChunkSeparator = chunkSeparator;
            this.Limit = limit;
            this.Around = around;
            this.ExactPhrase = exactphrase;
            this.SinglePassage = SinglePassage;
            this.UseBoundaries = useBoundaries;
            this.WeightOrder = weightOrder;
        }
    }
}