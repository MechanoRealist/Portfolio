using System;

namespace menu_v1.Metoder_og_instanser
{
    class Opg1
    {
        public class Bog// en public class der kan kaldes alle vegne i mit program
        {
            public void PrintInfo()// en methode lavet til at udskrive informationen i writelinen
            {
                Console.WriteLine("Jeg er en bog.");
            }        
        }
        public static void opgave1()
        {
            Console.SetCursorPosition(0, 2);
            Bog Sherlock = new Bog();// generere et nyt bog element
            Sherlock.PrintInfo();// sender sherloc objectet med den information til printinfo
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.menu();// tager brugeren tilbage til opgave menu
        }
    }
}
