using System;

namespace menu_v1.Strings
{
    class Opg1
    {
        public static void opgave1()
        {
            int tal = 1;// en integer variable med 1 som given værdi
            string text = "text";// en string variable med text som given værdi
            double ctal = 2.5;// en double værdi med 2.5 som given værdi
            Console.WriteLine("{0}\n{1}\n{2}", tal, text, ctal);// udksriver de 3 variabler pænt på vær sin linje
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.stringsMenu();// sender bruger tilbage til opgave menu
        }
    }
}
