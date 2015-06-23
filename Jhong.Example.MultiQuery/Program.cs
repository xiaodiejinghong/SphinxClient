namespace Jhong.Example.MultiQuery
{
    using Jhong.SphinxClient;
    using Jhong.SphinxClient.Enum;
    using System;
    using System.Linq;

    internal class Program
    {
        //具体同SimpleQuery
        private static void Main(string[] args)
        {
            var client = new SphinxClient("192.168.52.135", 9312);
            //设置查询模式
            client.Mode = MatchMode.SPH_MATCH_ANY;
            client.AddQuery("苹果", "*");
            client.AddQuery("微软", "*");
            client.AddQuery("谷人希", "*");
            //执行查询并返回结果
            var result = client.RunQueries();
            client.ClearQueryTasks();
            Console.WriteLine("一共返回了{0}个记录", result.Count());
            for (int i = 0; i < result.Count(); i++)
            {
                Console.WriteLine("第{0}个记录命中了{1}个文档", i, result[i].Matches.Count());
            }
            Console.ReadKey();
        }
    }
}