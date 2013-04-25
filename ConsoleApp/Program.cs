using System;
using Microsoft.Owin.Hosting;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StartOptions options = new StartOptions();
            options.OutputFile = "owin.log.txt";            
            options.Url = "http://localhost:8080";
            options.Verbosity = 2;

            using (WebApplication.Start<Startup>(options))
            {
                Console.WriteLine("Server running on {0}", options.Url);
                Console.ReadLine();
            }
        }
    }
}
