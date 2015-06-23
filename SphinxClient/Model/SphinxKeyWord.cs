namespace Jhong.SphinxClient.Model
{
    public class SphinxKeyWord
    {
        public string Tokenized { get; private set; }

        public string Normalized { get; private set; }

        public int Docs { get; private set; }

        public int Hits { get; private set; }

        public SphinxKeyWord(string tokenized, string normailzed, int docs, int hits)
        {
            this.Tokenized = tokenized;
            this.Normalized = normailzed;
            this.Docs = docs;
            this.Hits = hits;
        }
    }
}