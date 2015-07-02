namespace Jhong.Example.Status
{
    using Jhong.SphinxClient;
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var client = new SphinxClient("192.168.192.132", 9312);
            var statusInfo = client.Status;
            Console.WriteLine("状态信息：");
            foreach (var item1 in statusInfo)
            {
                foreach (var item2 in item1)
                {
                    Console.WriteLine(item2);
                }
                Console.WriteLine("");
            }
            Console.ReadKey();
        }
    }
}