using System;

namespace menu_v1.Variabler
{
    class Opg3
    {
        public static void opgave3()
        {
            string navn = "søren";// en string variable med dne givne værdi søren
            int alder = 16;// en integer varaible med værdien 16
            double penge = 1234.34;// en double variable (til comma tal) med dne givne værdi 1234,34
            Console.WriteLine("jeg hedder {0} er {1} år gammel og har tjent {2} kr. på at lappe cykler", navn, alder, penge);// udskriver teksten med variablerne sat i pænt format
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.VariablerMenu();// sender brugeren tilbage til opgave menu'en
        }
    }
}
