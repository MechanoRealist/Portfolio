using System;

namespace menu_v1.loops

{
    class Opg5
    {
        public static void opgave5()
        {
            for (int i = 1; i < 11; i++)//et loop der køre 10 gange
            {
                Console.WriteLine("{0, 4} * 7 = {1, 5}", i, i * 7);// udskriver regne stykket og resultatet sidst
            }
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.loopsMenu();// tager brugeren tilbage til opgave menu
        }
    }
}
