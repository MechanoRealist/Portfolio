using System;

namespace menu_v1.Variabler
{
    class Opg2
    {
        public static void opgave2()
        {
            var tal1 = 5;// en integer varaible med dne givne værdi af 5
            var tal2 = 3;
            Console.WriteLine("\tTal1 er {0}\n\tTal2 er {1}", tal1, tal2);// udskriver teksten med tal1 og tal2 på vær deres linje i et pænt format
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.VariablerMenu();// sender brugeren tilbage til opgave menu'en
        }
    }
}
