using System;

namespace menu_v1.Variabler
{
    class Opg1
    {
        public static void opgave1()
        {
            int tal1 = 5;// en integer varaible med den givne værdi af 5
            int tal2 = 3;
            Console.WriteLine(tal1 + "\n" + tal2);// udskriver tal1 og tal 2 på vær deres linje
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.VariablerMenu();// sender brugeren tilbage til opgave menu'en
        }
    }
}
