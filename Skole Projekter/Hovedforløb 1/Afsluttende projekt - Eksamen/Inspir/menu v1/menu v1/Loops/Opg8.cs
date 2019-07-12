using System;

namespace menu_v1.loops
{
    class Opg8
    {
        public static void opgave8()
        {
            int x = 20;// en int variable med start punktet 20
            int y = 4;
            for (int i = 0; i < 10; i++)//et loop der køre 10 gange
            {
                Console.SetCursorPosition(x, y);//sæter din cursos position i vinduet med x verdi da det vores start punkt mod højre
                Console.Write("_");//udskriver teksten men uden at gå ne linje vidre som writeline gør
                x++;// plusser en mere til x så den skriver næste karakter i rækken istedet for samme sted som vi lige har gjordt
            }
            for (int i = 0; i < 5; i++)// præcis det samme loop som før men nu ned af i stedet for mod højre
            {
                y++;
                Console.SetCursorPosition(x, y);
                Console.WriteLine("|");

            }
            for (int i = 0; i < 10; i++)// det omvendte loop af det første loop
            {
                x--;
                Console.SetCursorPosition(x, y);
                Console.Write("_");
            }
            for (int i = 0; i < 5; i++)
            {

                Console.SetCursorPosition(x, y);
                Console.WriteLine("|"); y--;
            }
            Console.SetCursorPosition(22, 6);
            Console.Write("Rasmus");
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.loopsMenu();// tager brugeren tilbage til opgave menu
        }
    }
}
