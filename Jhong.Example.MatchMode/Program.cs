namespace Jhong.Example.MatchMode
{
    using SphinxClient;
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
             * 本案例展示两种常见的命中模式设置
             */

            var client = new SphinxClient("192.168.192.132", 9312);
            //SPH_MATCH_ALL
            //此模式需要全部分词都命中才算命中
            var keystr = "苹果生产Mac";
            client.Mode = Jhong.SphinxClient.Enum.MatchMode.SPH_MATCH_ALL;
            var result1 = client.Query(keystr);
            Console.WriteLine("MatchAll模式：");
            foreach (var m in result1[0].Matches) Console.WriteLine("文档ID:{0}，权重:{1}", m.DocID, m.Weight);

            Console.WriteLine("-----------------------------");

            //SPH_MATCH_ANY
            //此模式仅要求命中一个或以上即符合命中
            client.Mode = Jhong.SphinxClient.Enum.MatchMode.SPH_MATCH_ANY;
            var result2 = client.Query(keystr);
            Console.WriteLine("MatchAny模式：");
            foreach (var m in result2[0].Matches) Console.WriteLine("文档ID:{0}，权重:{1}", m.DocID, m.Weight);
            Console.ReadKey();
        }
    }
}