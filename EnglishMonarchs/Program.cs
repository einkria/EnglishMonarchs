/*
 * Application: English Monarchs, .Net Console Application
 * Author: Kristín Þóra Jökulsdóttir
 */
using System;

using EnglishMonarchs.RunApp;

namespace EnglishMonarchs
{
    class Program
    {
        static void Main(string[] args)
        {
            IApp app = new App();

            try
            {
                var result = app.Run().GetAwaiter().GetResult();
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine($"Caught ArgumentException: {aex.Message}");
            }
        }

    }
}
