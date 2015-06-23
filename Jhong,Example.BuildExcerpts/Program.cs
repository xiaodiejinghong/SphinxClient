namespace Jhong.Example.BuildExcerpts
{
    using Jhong.SphinxClient;
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        /*
         * 本案例展示构建摘录（也就是类似百度那种命中加红加粗之类的）
         * 这里需要注意的，index不能传入‘*’因为需要使用具体索引配置作为分词组件的执行配置
         */

        private static void Main(string[] args)
        {
            var client = new SphinxClient("192.168.1.102", 9312);
            var keystr = "苹果生产ios";
            var queryRes = client.Query(keystr);

            var ids = from m in queryRes[0].Matches select m.DocID;
            var selectstr = string.Format("select title from post where id in ({0})", string.Join(",", ids));

            var docs = new List<string>();
            using (var conn = new MySqlConnection())
            {
                conn.ConnectionString = "Server=192.168.1.102;Database=blog; User=root;Password=root;Charset=utf8;";
                conn.Open();
                using (var reader = MySqlHelper.ExecuteReader(conn, selectstr))
                {
                    while (reader.Read())
                    {
                        docs.Add(reader["title"].ToString());
                    }
                }
            }

            var buildRes = client.BuildExcerpts(docs, "main", keystr, new Jhong.SphinxClient.Model.SphinxBuildExceptsOptions(beforeMatch: "<font color='red'>", afterMatch: "</font>"));
            Console.WriteLine("传入文档内容:");
            foreach (var d in docs)
            {
                Console.WriteLine(d);
            }
            Console.WriteLine("");
            Console.WriteLine("返回结果:");
            foreach (var r in buildRes)
            {
                Console.WriteLine(r);
            }
            Console.ReadKey();
        }
    }
}