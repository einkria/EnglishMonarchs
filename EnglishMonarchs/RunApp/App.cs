using System;
using System.Threading.Tasks;

using EnglishMonarchs.Models;
using EnglishMonarchs.Services;

namespace EnglishMonarchs.RunApp
{
    /*
     * Console Application that fetches data on English Monarchs from an API, and prints out interesting facts from the data, to the console.
     */
    class App : IApp
    {
        private IMonarchsDataService _dataService;
        private MonarchsInfoService _infoService;

        public App()
        {
            _dataService = new MonarchsDataService();
        }
        public async Task<bool> Run()
        {
            WriteIntro();
            await RunApp();
            WriteOutro();
            return true;
        }

        /************ Private functions *************/

        private void WriteIntro()
        {
            Console.WriteLine("WELCOME TO :");
            Console.WriteLine();
            Console.WriteLine("  ______             _ _     _       __  __                            _         ");
            Console.WriteLine(" |  ____|           | (_)   | |     |  \\/  |                          | |        ");
            Console.WriteLine(" | |__   _ __   __ _| |_ ___| |__   | \\  / | ___  _ __   __ _ _ __ ___| |__  ___ ");
            Console.WriteLine(" |  __| | '_ \\ / _` | | / __| '_ \\  | |\\/| |/ _ \\| '_ \\ / _` | '__/ __| '_ \\/ __|");
            Console.WriteLine(" | |____| | | | (_| | | \\__ \\ | | | | |  | | (_) | | | | (_| | | | (__| | | \\__ \\");
            Console.WriteLine(" |______|_| |_|\\__, |_|_|___/_| |_| |_|  |_|\\___/|_| |_|\\__,_|_|  \\___|_| |_|___/");
            Console.WriteLine("                __/ |                                                            ");
            Console.WriteLine("               |___/                                                             ");
            Console.WriteLine();
            Console.WriteLine("An information app with useful information about the history of English Monarchs");
            Console.WriteLine();
        }

        private void WriteOutro()
        {
            Console.WriteLine();
            Console.WriteLine("Thank you for using ENGLISH MONARCHS!");
            Console.WriteLine();
            Console.WriteLine("   _____                 _ _                ");
            Console.WriteLine("  / ____|               | | |               ");
            Console.WriteLine(" | |  __  ___   ___   __| | |__  _   _  ___ ");
            Console.WriteLine(" | | |_ |/ _ \\ / _ \\ / _` | '_ \\| | | |/ _ \\");
            Console.WriteLine(" | |__| | (_) | (_) | (_| | |_) | |_| |  __/");
            Console.WriteLine("  \\_____|\\___/ \\___/ \\__,_|_.__/ \\__, |\\___|");
            Console.WriteLine("                                  __/ |     ");
            Console.WriteLine("                                 |___/      ");
            Console.WriteLine();
        }

        private async Task<bool> RunApp()
        {
            
            Console.WriteLine("To fetch information about the history English Monarchs, enter 'Y'.");
            Console.WriteLine("Enter any other key to quit:");

            var selection = Console.ReadKey();

            if (selection.KeyChar.Equals('y') || selection.KeyChar.Equals('Y'))
            {
                await GetMonarchInfo();
                PrintMonarchInfo();
            }

            return true;
            
        }

        private void PrintMonarchInfo()
        {
            Console.WriteLine();
            Console.WriteLine("**************************************************************************************************");
            Console.WriteLine();
            WriteNumberInList();
            WriteMostCommonName();
            WriteLongestMonarchRule();
            WriteLongestHouseRule();
            Console.WriteLine();
            Console.WriteLine("**************************************************************************************************");
        }

        private async Task<bool> GetMonarchInfo()
        {
            var data = await _dataService.GetMonarchs();
            Monarchs monarchs = new Monarchs(data);
            _infoService = new MonarchsInfoService(monarchs);
            return true;
        }

        private void WriteNumberInList()
        {
            String info = "   There are " + _infoService.NumberOfMonarchs() + " Monarchs in the list.";
            Console.WriteLine(info);
        }

        private void WriteLongestMonarchRule()
        {
            String info = "   The monarch that (has) ruled for the longest time is/was " + _infoService.GetLongestRuler() + ", who (has) ruled for " + _infoService.GetLongestRule() + " years.";
            Console.WriteLine(info);
        }

        private void WriteLongestHouseRule()
        {
            String info = "   The House that ruled for the longest time was " + _infoService.GetLongestHouseRuler() + 
                          ", which ruled for " + _infoService.GetLongestHouseRule() + " years.";
            Console.WriteLine(info);
        }

        private void WriteMostCommonName()
        {
            String info = "";
            string firstName = _infoService.GetMostFrequentFirstName();

            if (firstName == null)
            {
                info = "   An error occured when finding out the most common first name.";
            }
            else
            {
                info = "   The most common name in the list of Monarchs is " + firstName + ".";
            }

            Console.WriteLine(info);
            
        }
    }
}
