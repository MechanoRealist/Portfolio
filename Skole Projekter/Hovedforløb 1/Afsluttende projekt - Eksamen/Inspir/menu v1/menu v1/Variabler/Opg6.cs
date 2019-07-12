using System;

namespace menu_v1.Variabler
{
    class Opg6
    {
        public static void opgave6()
        {
            double r;// en double variable uden nogle given værdi
            Console.WriteLine("skriv radiusen");// udskriver teksten i consolen
            r = Convert.ToDouble(Console.ReadLine());// convertere string inputtet om til double og gæmmer den i r variablen
            double areal = Math.PI * Math.Pow(r, 2);// udføre formlen til at udrenge arealet og gæmmer det dernæst i double variablen kaldet areal

            Console.WriteLine(areal);// udskriver værdien gæmt i areal
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.VariablerMenu();// sender brugeren tilbage til opgave menu'en
        }
    }
}
