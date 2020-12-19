using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishMonarchs
{
    class App
    {
        public void Run()
        {
            WriteIntro();
            RunApp();
        }

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

        private void RunApp()
        {
            while(true)
            {
                Console.WriteLine("To fetch information about the history English Monarchs, enter 'Y'.");
                Console.WriteLine("Enter any other key to quit:");
                var selection = Console.ReadKey();

                if (!selection.KeyChar.Equals('y') && !selection.KeyChar.Equals('Y'))
                {
                    Console.WriteLine();
                    Console.WriteLine("Thank you for using English Monarchs. Goodbye!");
                    return;
                }

                Console.WriteLine();
                Console.WriteLine("You have chosen Y, well done!");
            }
        }
    }
}
