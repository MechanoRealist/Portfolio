using System;
using System.Configuration;

namespace TwitterBot
{
    class Program
    {
        static Database database;
        static bool quit = false;
        static void Main(string[] args)
        {
            database = new Database();
            while(quit == false)
            {
                Console.Clear();
                Console.WriteLine("Press:\n 1 Get tweets menu\n 2 TEST SQL\n 3 test\n Q Quit");
                ConsoleKeyInfo choice = Console.ReadKey();
                Console.WriteLine();
                switch (choice.KeyChar)
                {
                    case '1':
                        GetTweetsUI();
                        break;
                    case '2':
                        Console.WriteLine("Max Query Size: {0}", database.GetMaxQuerySize());
                        break;
                    case '3':
                        Controlpanel.Init();

                        break;
                    case '4':
                        TwitterStuff.GetRawData("dkpol");
                        break;
                    case 'q':
                        quit = true;
                        Console.WriteLine("Quitting...");
                        System.Threading.Thread.Sleep(500);
                        break;
                }
            }
        }
        public static void GetTweetsUI()
        {
            Console.Clear();
            bool back = false;
            while (back == false)
            {
                Console.WriteLine("Assemble tweets: [A]\nBack: [Z]");
                ConsoleKeyInfo choice = Console.ReadKey();
                Console.WriteLine();
                switch (choice.KeyChar)
                {
                    case 'a':
                        Controlpanel.Init();
                        Controlpanel.AssembleDataset(database);
                        break;
                    case 'z':
                        back = true;
                        break;
                }
            }
        }
    }
    public class Analysis
    {

    }
}
