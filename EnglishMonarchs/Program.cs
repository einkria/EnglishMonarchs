using System;

namespace EnglishMonarchs
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.WriteIntro();
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
        }
    }
}
