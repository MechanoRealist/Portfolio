using System;

namespace menu_v1.loops
{
    class Opg9
    {
        public static void opgave9()
        {
            int x = 20;// en int variable med 20 som en given værdi
            int y = 4;
            int valgx = 20;
            int valgy = 10;
            string navn = "rasmus";// en string variable med mit navn som given værdi
            Console.WriteLine("skriv dit navn");
            navn = Console.ReadLine();// ændre navnet til brugerens behov
            KonsolHjælper.ClearMain();
            Console.WriteLine("vælg hvor langt til højre du vil have din ramme");
            valgx = Convert.ToInt32(Console.ReadLine());//konvertere string til int og gemmer brugerens input i valgx
            KonsolHjælper.ClearMain();
            Console.WriteLine("vælg hvor langt ned din ramme skal være");
            valgy = Convert.ToInt32(Console.ReadLine());
            KonsolHjælper.ClearMain();
            if (valgx >= 90)
            {
                valgx = 90;
            }
            if (valgy >= 20)// en if statement der kontrollere om brugeren har skrevet mere end 20 og vis han har udføre koden under
            {
                valgy = 19;// sætter brugerens svar ned til at detk an passe i rammen vi har lavet til menu og overskrift
            }
            int starty = valgy;
            int startx = valgx;
            for (int i = 0; i < valgx; i++)// et loop der køre lige så længe som brugeren valgte tidligere
            {
                Console.SetCursorPosition(x, y);//set start position for programmet
                Console.Write("_");// udskriver teksten (tegnet i det her tilfælde)
                x++;
            }
            for (int i = 0; i < valgy; i++)
            {
                y++;
                Console.SetCursorPosition(x, y);
                Console.WriteLine("|");

            }
            for (int i = 0; i < valgx; i++)
            {
                x--;
                Console.SetCursorPosition(x, y);
                Console.Write("_");
            }
            for (int i = 0; i < valgy; i++)
            {

                Console.SetCursorPosition(x, y);
                Console.WriteLine("|"); y--;
            }
            Console.SetCursorPosition(valgx / 2 + 20, starty / 2 + 4);// sætter cursor position i midten af den personlige ramme
            Console.Write(navn);// udskriver navnet hvor cursoren står og skifter ikek til næste linje
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.loopsMenu();// tager brugeren tilbage til opgave menu
        }
    }
}
