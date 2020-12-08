using FinLabLibs;
using System;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FinLabTools
{
    class Program
    {
        static IConfigurationRoot Configuration { get; set; }
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsetting.json", true);

            Configuration = builder.Build();

            Console.WriteLine(Configuration["path"]);

            if (args.IsNullOrEmpty() == true)
            {
                Console.WriteLine("Hello World!!!!");

                Portfolio pfl = new Portfolio(Configuration["path"]);

                pfl.Stocks.ForEach(n =>
                {
                    Console.WriteLine(n);
                });

                pfl.Add("3611");
                pfl.Save();
                return;
            }

            string command = args[0];

            var result = FinLabToolCommand.Instance.Call(command);
            Console.WriteLine(result);
        }
    }
}
