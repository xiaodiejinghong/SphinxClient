namespace Jhong.Example.BuildKeywords
{
    using SphinxClient;
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
             * 本案例演示分词的构建
             * 这里值得注意的index不能传入‘*’，因为分词器需要具体的词库等配置（Config文件中）作为分词的标准
             */
            var client = new SphinxClient("192.168.1.102", 9312);
            var inputstr = "微软发明了Windows";
            var res = client.BuildKeywords(inputstr, "main");
            Console.WriteLine("输入语句为:" + inputstr);
            Console.WriteLine("分词结果为:");
            foreach (var r in res)
            {
                Console.WriteLine("  " + r.Normalized);
            }
            Console.ReadKey();
        }
    }
}