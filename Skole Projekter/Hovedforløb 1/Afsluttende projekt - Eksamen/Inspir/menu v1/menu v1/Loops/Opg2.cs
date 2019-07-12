using System;
using System.Threading;

namespace menu_v1.loops
{
    class Opg2
    {
        public static void opgave2()
        {
            int tal = 100;// en int variable med et 100 tal som given værdi
            for (int i = 1; i < 101; i++)// et for loop der køre 100 gange
            {
                Console.WriteLine(i + " udskrevet i for loop");
                Thread.Sleep(250);// pauser programmet i et kvart sekundt så brugeren kan nå og se tallet inden den fortsætter med at tælle
                KonsolHjælper.ClearMain();// tømmer program delen af consol vinduet så loopet ikke for overskrevet vores ramme
            }
            while (tal >= 0)// et while loop der køre indtil tallet rammer 0
            {
                Console.WriteLine(tal + " udskrevet i while loop");
                tal--;
                Thread.Sleep(250);
                KonsolHjælper.ClearMain();
            }
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.loopsMenu();// tager brugeren tilbage til opgave menu
        }
    }
}
