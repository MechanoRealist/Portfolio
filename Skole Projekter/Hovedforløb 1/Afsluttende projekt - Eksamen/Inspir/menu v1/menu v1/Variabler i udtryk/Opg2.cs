using System;

namespace menu_v1.Variabler_i_udtryk
{
    class Opg2
    {
        public static void opgave2()
        {
            double var1 = 34;//en double varaible med den givne værdi af 34
            double var2 = 32;
            double var3 = 2;
            double resultat = var1 + 5 / var2 - 17 + var3;// en double variable der udregner formalen og gæmmer resultatet i resultat variablen
            Console.WriteLine(resultat);// udskriver værdien gæmt i resultat
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.variableUdtrykMenu();// sender brugeren tilbage til opgave menu'en
        }
    }
}
