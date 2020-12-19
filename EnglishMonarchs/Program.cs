using System;

using EnglishMonarchs.RunApp;

namespace EnglishMonarchs
{
    class Program
    {
        static void Main(string[] args)
        {
            IApp app = new App();
            app.Run();
        }

    }
}
