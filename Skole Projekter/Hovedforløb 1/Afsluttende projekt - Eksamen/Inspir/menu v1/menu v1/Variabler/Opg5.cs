using System;

namespace menu_v1.Variabler
{
    class Opg5
    {
        public static void opgave5()
        {
            string navn;// en string varialbe uden nogle given værdi
            int alder;// en integer variable uden nogle given værdi
            Console.WriteLine("skriv dit navn");// udskriver teksten i consolen
            navn = Console.ReadLine();//gæmmer brugerens input i navn variablen
            KonsolHjælper.ClearMain();
            Console.WriteLine("skriv din alder");
            alder = Convert.ToInt32(Console.ReadLine());// convertere brugerens input til integer og gæmmer dne i alder variablen
            KonsolHjælper.ClearMain();
            Console.WriteLine("Navn:\t{0}\nAlder:\t{1}", navn, alder);// udskriver teksten og variablernes værdi i et pænt format
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.VariablerMenu();// sender brugeren tilbage til opgave menu'en
        }
    }
}
