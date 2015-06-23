namespace Jhong.SphinxClient
{
    using DataStructure;
    using Enum;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public class SphinxClient
    {
        /// <summary>
        ///
        /// </summary>
        private IList<SphReq> _reqs;

        /// <summary>
        ///
        /// </summary>
        private IDictionary<string, int> _fieldWeights;

        /// <summary>
        ///
        /// </summary>
        private bool _hasouter = false;

        /// <summary>
        ///
        /// </summary>
        private float _latitude = 0.0f;

        /// <summary>
        ///
        /// </summary>
        private string _latitudeAttr = string.Empty;

        /// <summary>
        ///
        /// </summary>
        private IDictionary<string, int> _indexWeight;

        /// <summary>
        ///
        /// </summary>
        private float _longitude = 0.0f;

        /// <summary>
        ///
        /// </summary>
        private string _longitudeAttr = string.Empty;

        /// <summary>
        ///
        /// </summary>
        private IList<SphinxOvrride> _overrides;

        /// <summary>
        /// 获取或设置CutOff
        /// </summary>
        public int CutOff { get; set; }

        /// <summary>
        /// 获取或设置Filters
        /// </summary>
        public IList<SphinxFilter> Filters { get; set; }

        /// <summary>
        /// 获取或设置GroupBy
        /// </summary>
        public string GroupBy { get; set; }

        /// <summary>
        /// 获取或设置GroupDistinct
        /// </summary>
        public string GroupDistinct { get; set; }

        /// <summary>
        /// 获取或设置GroupFunc
        /// </summary>
        public GroupFunc GroupFunc { get; set; }

        /// <summary>
        /// 获取或设置GroupSort
        /// </summary>
        public string GroupSort { get; set; }

        /// <summary>
        /// 获取或设置Host
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 获取或设置Limit
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// 获取或设置MaxID
        /// </summary>
        public long MaxID { get; set; }

        /// <summary>
        /// 获取或设置MaxMatches
        /// </summary>
        public int MaxMatches { get; set; }

        /// <summary>
        /// 获取或设置MaxQueryTime
        /// </summary>
        public int MaxQueryTime { get; set; }

        /// <summary>
        /// 获取或设置MinID
        /// </summary>
        public long MinID { get; set; }

        /// <summary>
        /// 获取或设置Mode
        /// </summary>
        public MatchMode Mode { get; set; }

        /// <summary>
        /// 获取或设置Offset
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// 获取或设置OuterOffset
        /// </summary>
        public int OuterOffset { get; set; }

        /// <summary>
        /// 获取或设置OuterLImit
        /// </summary>
        public int OuterLimit { get; set; }

        /// <summary>
        /// 获取或设置OuterOrderBy
        /// </summary>
        public string OuterOrderBy { get; set; }

        /// <summary>
        /// 获取或设置OuterOrderTime
        /// </summary>
        public string OuterOrderTime { get; set; }

        /// <summary>
        /// 获取或设置Port
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 获取或设置PredictedTime
        /// </summary>
        public int PredictedTime { get; set; }

        /// <summary>
        /// 获取或设置Rank
        /// </summary>
        public RankingMode Rank { get; set; }

        /// <summary>
        /// 获取或设置RankExpr
        /// </summary>
        public string RankExpr { get; set; }

        /// <summary>
        /// 获取或设置RetryCount
        /// </summary>
        public int RetryCount { get; set; }

        /// <summary>
        /// 获取或设置RetryDelay
        /// </summary>
        public int RetryDelay { get; set; }

        /// <summary>
        /// 获取或设置Select
        /// </summary>
        public string Select { get; set; }

        /// <summary>
        /// 获取或设置Sort
        /// </summary>
        public SortMode Sort { get; set; }

        /// <summary>
        /// 获取或设置SortBy
        /// </summary>
        public string SortBy { get; set; }

        /// <summary>
        /// 获取或设置TimeOut
        /// </summary>
        public int TimeOut { get; set; }

        /// <summary>
        /// 获取或设置Weights
        /// </summary>
        public IList<int> Weights { get; set; }

        /// <summary>
        /// 签订契约
        /// </summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.Limit > 0, "Limit must greater than 0");
            Contract.Invariant(this.Offset >= 0, "Offset must greater than or equal 0");
            Contract.Invariant(this.Port > 0 && this.Port < 65535, "Port not in 0~65535");
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public SphinxClient()
            : this("127.0.0.1", 9312)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="host">地址</param>
        /// <param name="port">端口</param>
        public SphinxClient(string host, int port)
        {
            this.TimeOut = 2000;
            this.Offset = 0;
            this.Mode = MatchMode.SPH_MATCH_EXTENDED2;
            this.Offset = 0;
            this.Mode = MatchMode.SPH_MATCH_ANY;
            this.Limit = 20;
            this.Rank = RankingMode.SPH_RANK_PROXIMITY_BM25;
            this.RankExpr = string.Empty;
            this.Sort = SortMode.SPH_SORT_RELEVANCE;
            this.SortBy = string.Empty;
            this.Weights = new List<int>();
            this.MaxID = 0;
            this.MaxID = 0;
            this.Filters = new List<SphinxFilter>();
            this.GroupFunc = Enum.GroupFunc.SPH_GROUPBY_DAY;
            this.GroupBy = string.Empty;
            this.MaxMatches = 1000;
            this.GroupSort = "@group desc";
            this.CutOff = 0;
            this.RetryCount = 0;
            this.RetryDelay = 0;
            this.GroupDistinct = string.Empty;
            this.Select = "*";
            this.PredictedTime = 0;
            this.OuterOrderBy = string.Empty;
            this.OuterOffset = 0;
            this.OuterLimit = 0;
            this._indexWeight = new Dictionary<string, int>();
            this._fieldWeights = new Dictionary<string, int>();
            this._overrides = new List<SphinxOvrride>();
            this._reqs = new List<SphReq>();
            this.Host = host;
            this.Port = port;
        }

        /// <summary>
        /// 加入查询队列
        /// </summary>
        /// <param name="query">待查询语句</param>
        /// <param name="index">索引</param>
        /// <param name="comment"></param>
        /// <returns>待查询任务数目</returns>
        public int AddQuery(string query, string index = "*", string comment = "")
        {
            Contract.Requires(false == string.IsNullOrWhiteSpace(query),"query can not be null or empty");
            var sphreq = new SphReq();
            sphreq.Write(this.Offset);
            sphreq.Write(this.Limit);
            sphreq.Write((int)this.Mode);
            sphreq.Write((int)this.Rank);
            if (this.Rank == RankingMode.SPH_RANK_EXPR) sphreq.Write(this.RankExpr);
            sphreq.Write((int)this.Sort);
            sphreq.Write(this.SortBy);
            sphreq.Write(query);
            sphreq.Write(null == this.Weights ? 0 : this.Weights.Count());
            if (null != this.Weights) foreach (var w in this.Weights) sphreq.Write(w);
            sphreq.Write(index);
            sphreq.Write(1);
            sphreq.Write(this.MinID);
            sphreq.Write(this.MaxID);
            sphreq.Write(this.Filters.Count());
            foreach (var filter in this.Filters)
            {
                sphreq.Write(filter.Attr);
                sphreq.Write((int)filter.Type);
                switch (filter.Type)
                {
                    case FilterType.SPH_FILTER_VALUES:
                        sphreq.Write(filter.Values.Count());
                        foreach (var value in filter.Values)
                            sphreq.Write(value);
                        break;

                    case FilterType.SPH_FILTER_RANGE:
                        sphreq.Write(filter.UMin);
                        sphreq.Write(filter.UMax);
                        break;

                    case FilterType.SPH_FILTER_FLOATRANGE:
                        sphreq.Write(filter.FMin);
                        sphreq.Write(filter.FMax);
                        break;

                    case FilterType.SPH_FILTER_STRING:
                        sphreq.Write(filter.SValue);
                        break;
                }
                sphreq.Write(filter.Exclude);
            }
            sphreq.Write((int)this.GroupFunc);
            sphreq.Write(this.GroupBy);
            sphreq.Write(this.MaxMatches);
            sphreq.Write(this.GroupSort);
            sphreq.Write(this.CutOff);
            sphreq.Write(this.RetryCount);
            sphreq.Write(this.RetryDelay);
            sphreq.Write(this.GroupDistinct);
            if (string.IsNullOrWhiteSpace(this._longitudeAttr) || string.IsNullOrWhiteSpace(this._latitudeAttr))
            {
                sphreq.Write(0);
            }
            else
            {
                sphreq.Write(1);
                sphreq.Write(this._latitudeAttr);
                sphreq.Write(this._longitudeAttr);
                sphreq.Write(this._latitude);
                sphreq.Write(this._longitude);
            }
            sphreq.Write(this._indexWeight.Count());
            foreach (var iw in this._indexWeight)
            {
                sphreq.Write(iw.Key);
                sphreq.Write(iw.Value);
            }
            sphreq.Write(this.MaxQueryTime);
            sphreq.Write(this._fieldWeights.Count());
            foreach (var fw in this._fieldWeights)
            {
                sphreq.Write(fw.Key);
                sphreq.Write(fw.Value);
            }
            sphreq.Write(comment);
            sphreq.Write(this._overrides.Count());
            foreach (var o in this._overrides)
            {
                sphreq.Write(o.Attr);
                sphreq.Write((int)o.Type);
                sphreq.Write(o.NumValues);
                for (int i = 0; i < o.NumValues; i++)
                {
                    sphreq.Write(o.DocIDs[i]);
                    switch (o.Type)
                    {
                        case AttributeType.SPH_ATTR_FLOAT:
                            sphreq.Write(Convert.ToSingle(o.UIntValues[i]));
                            break;

                        case AttributeType.SPH_ATTR_BIGINT:
                            sphreq.Write(o.UIntValues[i]);
                            break;

                        default:
                            sphreq.Write(Convert.ToInt32(o.UIntValues[i]));
                            break;
                    }
                }
            }
            sphreq.Write(this.Select);
            this._reqs.Add(sphreq);
            return this._reqs.Count();
        }

        /// <summary>
        /// 构建摘录
        /// </summary>
        /// <param name="docs">待构建的字符串集合</param>
        /// <param name="index">引用的索引库</param>
        /// <param name="words">关键字字串</param>
        /// <param name="options">构建选型</param>
        /// <returns>构建完成的摘录集合</returns>
        public IList<string> BuildExcerpts(IList<string> docs, string index, string words, SphinxBuildExceptsOptions options)
        {
            Contract.Requires(false == string.IsNullOrWhiteSpace(index), "index can not be null");
            Contract.Requires(false == string.IsNullOrWhiteSpace(words), "words can not be null");
            var flag = 1;
            if (options.ExactPhrase) flag |= 2;
            if (options.SinglePassage) flag |= 4;
            if (options.UseBoundaries) flag |= 8;
            if (options.WeightOrder) flag |= 16;

            var req = new SphReq();
            req.Write(0);
            req.Write(flag);
            req.Write(index);
            req.Write(words);
            req.Write(options.BeforeMatch);
            req.Write(options.AfterMatch);
            req.Write(options.ChunkSeparator);
            req.Write(options.Limit);
            req.Write(options.Around);
            req.Write(docs.Count());
            foreach (var doc in docs) req.Write(doc);
            var tmp = new SphReq();
            tmp.Write(1);
            tmp.Write((short)SearchCommand.SEARCHD_COMMAND_EXCERPT);
            tmp.Write((short)Command.VER_COMMAND_EXCERPT);
            var reqLength = (int)req.Length;
            tmp.Write(reqLength);
            req.Mosaic(tmp.CutOffHead(), SphReq.BlockMosaicLocation.Top);
            var conn = this.GetConnection();
            conn.Send(req.GetBuffer());

            var rece = new byte[(int)(1.5 * reqLength)];
            var receLength = conn.Receive(rece);
            conn.Close();
            var rep = new SphRep(rece, receLength);
            var repLength = this.CheckResponse(rep);
            var res = new List<string>();
            for (int i = 0; i < docs.Count(); i++) res.Add(rep.ReadStringNode());
            return res;
        }

        /// <summary>
        /// 构建分词
        /// </summary>
        /// <param name="query">带分词的语句</param>
        /// <param name="index">引用的索引库</param>
        /// <returns>分词集合</returns>
        public IList<SphinxKeyWord> BuildKeywords(string query, string index)
        {
            Contract.Requires(false == string.IsNullOrWhiteSpace(query), "query can not be null or emtpy");
            Contract.Requires(false == string.IsNullOrWhiteSpace(index), "index can not be null or empty");
            var req = new SphReq();
            req.Write(query);
            req.Write(index);
            req.Write(1);
            var tmp = new SphReq();
            tmp.Write(1);
            tmp.Write((short)SearchCommand.SEARCHD_COMMAND_KEYWORDS);
            tmp.Write((short)Command.VER_COMMAND_KEYWORDS);
            tmp.Write((int)req.Length);
            req.Mosaic(tmp.CutOffHead(), SphReq.BlockMosaicLocation.Top);
            var conn = this.GetConnection();
            conn.Send(req.GetBuffer());
            var rece = new byte[5 * req.Length];
            var receLength = conn.Receive(rece);
            var rep = new SphRep(rece, receLength);
            var rLen = this.CheckResponse(rep);
            var nwords = rep.ReadInt();
            var res = new List<SphinxKeyWord>();
            for (int i = 0; i < nwords; i++) res.Add(new SphinxKeyWord(rep.ReadStringNode(), rep.ReadStringNode(), rep.ReadInt(), rep.ReadInt()));
            return res;
        }

        /// <summary>
        /// 检查返回数据
        /// </summary>
        /// <param name="rep"></param>
        /// <returns>长度</returns>
        private int CheckResponse(SphRep rep)
        {
            var status = rep.ReadShort();
            var ver = rep.ReadShort();
            var len = rep.ReadInt();
            switch (status)
            {
                case (short)SearchStatus.SEARCHD_OK:
                case (short)SearchStatus.SEARCHD_WARNING: break;
                case (short)SearchStatus.SEARCHD_ERROR:
                    var response = rep.Read(len);
                    throw new Exception("Search Error:" + Encoding.UTF8.GetString(response));
                case (short)SearchStatus.SEARCHD_RETRY:
                    var response2 = rep.Read(len);
                    throw new Exception("Temporary Search Error:" + Encoding.UTF8.GetString(response2));
                default:
                    throw new Exception(string.Format("Unknow Status Code:{0}", status));
            }
            return len;
        }

        /// <summary>
        /// 清理待查询任务
        /// </summary>
        public void ClearQueryTasks()
        {
            this._reqs.Clear();
        }

        /// <summary>
        /// 获取连接
        /// </summary>
        /// <returns></returns>
        private Socket GetConnection()
        {
            var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            var ipEndPoint = new IPEndPoint(IPAddress.Parse(this.Host), this.Port);
            socket.ReceiveTimeout = this.TimeOut;
            try
            {
                socket.Connect(ipEndPoint);
            }
            catch
            {
                throw;
            }
            var rep = new byte[4];
            var len = socket.Receive(rep);
            var sphrep = new SphRep(rep, len);
            var version = sphrep.ReadInt();
            if (version < 1) throw new Exception(string.Format("expected searchd protocol version 1+, got version {0}", version));
            return socket;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">待查询语句</param>
        /// <param name="index">索引（默认搜索全部）</param>
        /// <param name="comment"></param>
        /// <returns>结果集合</returns>
        public IList<SphinxResult> Query(string query, string index = "*", string comment = "")
        {
            this.ClearQueryTasks();
            this.AddQuery(query, index, comment);
            var res = this.RunQueries();
            this.ClearQueryTasks();
            return res;
        }

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <returns></returns>
        public IList<SphinxResult> RunQueries()
        {
            var reqsCount = this._reqs.Count();
            var reqsLength = this._reqs.Sum(r => r.Length);
            var req = new SphReq();
            req.Write(1);
            req.Write((short)SearchCommand.SEARCHD_COMMAND_SEARCH);
            req.Write((short)Command.VER_COMMAND_SEARCH);
            req.Write((int)(4 + reqsLength));
            req.Write(reqsCount);
            foreach (var r in this._reqs) req.Mosaic(r.CutOffHead());
            var conn = this.GetConnection();
            conn.Send(req.GetBuffer());

            var receive = new byte[1024 * 512];
            var receLen = conn.Receive(receive);
            conn.Dispose();

            var rep = new SphRep(receive, receLen);
            var len = this.CheckResponse(rep);
            var sphinxResultList = new List<SphinxResult>();
            for (int rc = 0; rc < reqsCount; rc++)
            {
                var sphinxResult = new SphinxResult()
                {
                    AttrName = new List<string>(),
                    AttrTypes = new List<int>(),
                    Fields = new List<string>(),
                    Matches = new List<SphinxMatch>(),
                    Words = new List<SphinxWordInfo>(),
                    Status = rep.ReadInt()
                };
                if (sphinxResult.Status != (int)SearchStatus.SEARCHD_OK)
                {
                    if (sphinxResult.Status == (int)SearchStatus.SEARCHD_WARNING)
                    {
                        sphinxResult.WarnStr = Encoding.UTF8.GetString(rep.Read(len - 4));
                    }
                    else
                    {
                        sphinxResult.ErrStr = Encoding.UTF8.GetString(rep.Read(len - 4));
                        return null;
                    }
                }
                var fieldsNum = rep.ReadInt();
                for (int i = 0; i < fieldsNum; i++) sphinxResult.Fields.Add(rep.ReadStringNode());
                var attrNum = rep.ReadInt();
                for (int i = 0; i < attrNum; i++)
                {
                    sphinxResult.AttrName.Add(rep.ReadStringNode());
                    sphinxResult.AttrTypes.Add(rep.ReadInt());
                }
                var matchNum = rep.ReadInt();
                var id64 = rep.ReadInt();
                long doc;
                for (int i = 0; i < matchNum; i++)
                {
                    doc = 0 == id64 ? rep.ReadInt() : rep.ReadLong();
                    var docInfo = new SphinxMatch()
                    {
                        DocID = doc,
                        Weight = rep.ReadInt(),
                        AttrValues = new List<object>()
                    };
                    foreach (var type in sphinxResult.AttrTypes)
                    {
                        switch ((AttributeType)System.Enum.Parse(typeof(AttributeType), type.ToString()))
                        {
                            case AttributeType.SPH_ATTR_BIGINT:
                                docInfo.AttrValues.Add(rep.ReadLong());
                                rep.Read(8);
                                break;

                            case AttributeType.SPH_ATTR_FLOAT:
                                docInfo.AttrValues.Add(rep.ReadSingle());
                                rep.Read(8);
                                break;

                            case AttributeType.SPH_ATTR_MULTI:
                                var itemsNum = rep.ReadLong();
                                var vars = new List<long>();
                                for (int j = 0; j < itemsNum; j++) vars.Add(rep.ReadLong());
                                docInfo.AttrValues.Add(vars);
                                break;

                            default:
                                rep.Read(8);
                                docInfo.AttrValues.Add(rep.ReadLong());
                                break;
                        }
                    }
                    sphinxResult.Matches.Add(docInfo);
                }
                sphinxResult.Total = rep.ReadInt();
                sphinxResult.TotalFound = rep.ReadInt();
                sphinxResult.Time = rep.ReadInt();
                var wordNum = rep.ReadInt();
                for (int i = 0; i < wordNum; i++) sphinxResult.Words.Add(new SphinxWordInfo()
                {
                    Word = rep.ReadStringNode(),
                    Docs = rep.ReadInt(),
                    Hits = rep.ReadInt()
                });
                sphinxResultList.Add(sphinxResult);
            }
            return sphinxResultList;
        }
    }
}