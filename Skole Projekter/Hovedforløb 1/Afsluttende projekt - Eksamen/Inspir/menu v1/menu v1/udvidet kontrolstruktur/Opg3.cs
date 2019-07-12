using System;

namespace menu_v1.udvidet_kontrolstruktur
{
    class Opg3
    {
        public static void opgave3()
        {
            double længde;// en double variable uden given værdi
            double pris;
            Console.WriteLine("hvor langt skal du rejse i km frem og tilbage");// udskriver teksten
            længde = Convert.ToInt32(Console.ReadLine());// gemmer brugerens input i længde variablen
            if (længde > 100)// en statement der kontrollere om længde er størere end 100 og vis jeg udføre koden under
            {
                pris = længde * 0.77;// lægnde bliver ganget med 0.77 og gæmt i "pris" variablen
                Console.WriteLine("du får {0}kr. pr. dag. fordi du rejser {1}km", pris, længde);
            }
            else if (længde > 24 && længde < 101)
            {
                pris = længde * 1.54;
                Console.WriteLine("du får {0}kr. pr. dag.  fordi du rejser {1}km", pris, længde);
            }
            else if (længde < 24)
            {
                Console.WriteLine("du rejser ikke nok km til at få fradrag");
            }
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.kontrolMenu();// sender brugeren tilbage til opgave menu'en
        }
    }
}
