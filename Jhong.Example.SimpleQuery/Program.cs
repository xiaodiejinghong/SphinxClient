namespace Jhong.Example.SimpleQuery
{
    using Jhong.SphinxClient;
    using Jhong.SphinxClient.Enum;
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
             * 这算是一个最重要的案例了
             * 演示怎么查询
             */
            var client = new SphinxClient("192.168.192.132", 9312);
            //设置查询模式
            client.Mode = MatchMode.SPH_MATCH_ANY;
            //执行查询并返回结果
            var keystr = "苹果生产Mac";
            var result = client.Query(keystr, "*");
            //输出结果
            Console.WriteLine("查询内容:" + keystr);
            Console.WriteLine("查询返回文档命中数:{0}", result[0].Matches.Count());
            Console.WriteLine("-------------------------------");
            Console.WriteLine("分词信息:");
            foreach (var word in result[0].Words) Console.WriteLine(string.Format("词语:{0},总命中次数：{1}次，命中文档数:{2}个", word.Word, word.Hits, word.Docs));
            Console.WriteLine("-------------------------------");
            Console.WriteLine("命中信息:");
            foreach (var m in result[0].Matches) Console.WriteLine("文档ID:{0}，权重:{1}", m.DocID, m.Weight);
            Console.ReadKey();
        }
    }
}