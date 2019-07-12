using System;

namespace menu_v1.Strings
{
    class Opg4
    {
        public static void opgave4()
        {
            double tal = 200.50;// en double variable med en given værdi af 200.50
            string text = "jeg har ";// en tekst string med værdien "jeg har "
            string text2 = "kr. i banken";
            Console.WriteLine(text + tal + text2);// udskriver de 3 variabler i en pæn rækkefølge
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.stringsMenu();// sender bruger tilbage til opgave menu
        }
    }
}
