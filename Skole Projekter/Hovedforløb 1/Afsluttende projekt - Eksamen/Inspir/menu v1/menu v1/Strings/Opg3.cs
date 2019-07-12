using System;

namespace menu_v1.Strings
{
    class Opg3
    {
        public static void opgave3()
        {
            string tekst = "i dag har vi den 24. December";// gemmer teksten i string variablen tekst
            Console.WriteLine(tekst);// udskriver værdien af tekst variablen
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.stringsMenu();// sender bruger tilbage til opgave menu
        }
    }
}
