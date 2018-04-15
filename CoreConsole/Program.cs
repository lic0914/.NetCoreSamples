using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
        }
       
        /*json文件读取
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("json1.json");
            var config = builder.Build();
            Console.WriteLine("name="+config["name"]+ ",age=" + config["age"]);
            Console.WriteLine("爱好:\r\n");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(config["hobby:"+i]);//子元素是 config["hobby:0"] ,config["hobby:0:a"]
            }
            Console.WriteLine("ok");
            Console.ReadKey();
            
        }
        */
        /*命令行读取
        static void Main(string[] args)
        {
            var settings = new Dictionary<string, string>
            {
                {"name","lic" },
                {"age","10" }
            };
            var binder = new ConfigurationBuilder()
             .AddInMemoryCollection(settings)
             .AddCommandLine(args);
            var config = binder.Build();
            Console.WriteLine($"name={config["name"]},age={config["age"]}");
            Console.ReadKey();
        }
        */
    }
}
