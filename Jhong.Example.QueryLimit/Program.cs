namespace Jhong.Example.QueryLimit
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
             * 作用就是类似mysql的limit，控制返回多少个命中数，做分页的时候挺好用
             */
            var client = new SphinxClient("192.168.52.135", 9312);
            client.Mode = MatchMode.SPH_MATCH_ANY;
            //设置Limit数目（跟MYSQL的limit关键字作用差不多）
            client.Limit = 5;
            var res1 = client.Query("ios");
            Console.WriteLine("第一次查询，Limit值为{0},共返回{1}个记录", client.Limit, res1[0].Matches.Count());
            //设置Limit数目
            client.Limit = 1;
            var res2 = client.Query("ios");
            Console.WriteLine("第二次查询，Limit值为{0},共返回{1}个记录", client.Limit, res2[0].Matches.Count());
            Console.ReadKey();
        }
    }
}