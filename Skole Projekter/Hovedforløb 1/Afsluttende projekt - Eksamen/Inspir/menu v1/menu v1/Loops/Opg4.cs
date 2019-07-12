using System;

namespace menu_v1.loops
{
    class Opg4
    {
        public static void opgave4()
        {
            int gg = 20;
            while (gg > 0)// et loop der køre så længe gg er mere end 0
            {
                Console.WriteLine(gg);// udskriver gg i consolen
                gg--;// formindsker gg med 1
            }
            for (int i = 20; i > 0; i--)// et loop der køre 20 gange
            {
                Console.WriteLine(i + " for loop");// udskriver i og teksten efter
            }
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.loopsMenu();// tager brugeren tilbage til opgave menu
        }
    }
}
