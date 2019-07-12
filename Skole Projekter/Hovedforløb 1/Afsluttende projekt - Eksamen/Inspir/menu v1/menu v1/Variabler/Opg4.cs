using System;

namespace menu_v1.Variabler
{
    class Opg4
    {
        public static void opgave4()
        {
            double kage = 23.56;// en double variable med dne givne værdi af 23,56
            double øl = 34.67;
            double pølse = 65.34;
            Console.WriteLine("kage\t{0}\nøl\t{1}\npølse\t{2}\ni alt\t{3}", kage, øl, pølse, kage + øl + pølse);// udskriver alle variablerne i pænt format og lægger dem sammen til et resultat på sidste linje
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.VariablerMenu();// sender brugeren tilbage til opgave menu'en
        }
    }
}
