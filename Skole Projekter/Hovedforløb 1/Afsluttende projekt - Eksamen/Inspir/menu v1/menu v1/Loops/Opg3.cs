using System;

namespace menu_v1.loops
{
    class Opg3
    {
        public static void opgave3()
        {
            for (int i = 0; i < 51;)// et loop der køre 51 gange
            {
                Console.WriteLine(i);
                i++; //pluser 1 med i kunne også skrives i+=5 istedet for 5*i++
                i++;
                i++;
                i++;
                i++;
            }
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.loopsMenu();// tager brugeren tilbage til opgave menu
        }
    }
}
