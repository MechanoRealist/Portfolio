using System;
using System.Threading;

namespace menu_v1.Switch_Case
{
    class Opg1
    {
        public static void opgave1()
        {
            int countDown = 10;// en integer variable med værdien 10
            while (true)// et uendeligt loop (sat til true for aldrig at stoppe)
            {
                Console.WriteLine("skriv et tal mellem 1-6");// udskriver teksten
                var svar = Console.ReadKey();// gemmer brugerens svar i en var variable 
                switch (svar.Key)// kontrolere den enkelte tast brugeren trykker for mulighederne
                {
                    case ConsoleKey.D1:// en case der aktivere vis brugens tast var 1 (numpad tæller ikke da den vilel have heddet ConsoleKey.numpad1)
                        Console.WriteLine("du har tastet {0}", Convert.ToString(svar));// udskriver teksten og brugerens valgte tast
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("du har tastet {0}", Convert.ToString(svar));
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("du har tastet {0}", Convert.ToString(svar));
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("TILLYKKE DU HAR VUNDET!!!!");
                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine("du har tastet {0}", Convert.ToString(svar));
                        break;
                    case ConsoleKey.D6:
                        Console.WriteLine("du har tastet {0}", Convert.ToString(svar));
                        break;
                    default:// casen der bliver valgt automatisk vis brugerens svar ikke var en mulighed
                        Console.WriteLine(" var ikke mulighed tallet skal være mellem 1 og 6");
                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine("programmet vil lukke om {0} sekunder", countDown);
                            Thread.Sleep(1000);// pauser programmet i 1 sekundt
                            KonsolHjælper.ClearMain();// tømmer program delen af templated jeg laver i starten af programmet
                            countDown--;
                        }
                        Environment.Exit(0);// lukket consol vinduet ned
                        break;
                }
                Console.ReadLine();// pauser programmet og venter på brugerens input
                KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
                KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
                Menu.skiftMenu();// sender bruger tilbage til opgave menu
            }
        }
    }
}
