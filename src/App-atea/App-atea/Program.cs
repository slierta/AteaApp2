using System;
using Atea.Helpers;
using App.Atea.Data;

namespace Atea // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            if (args.Length != 2 || !args.All(s => int.TryParse(s, out _)))
                Console.WriteLine("The app needs two integer numbers as arguments to run");
            else
            {
                var result = args.Add();
                Console.WriteLine($"The result is: {result}");
                var item = new ExecutionItem(args, result);
                Store.Instance.Insert(item);
                Console.WriteLine($"There's {Store.Instance.CountRecords()} record(s) stored in the db");
            }
        }
    }
}