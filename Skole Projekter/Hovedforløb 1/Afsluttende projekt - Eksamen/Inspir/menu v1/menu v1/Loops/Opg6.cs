using System;

namespace menu_v1.loops
{
    class Opg6
    {
        public static void opgave6()
        {
            Console.WriteLine("hvilken tabel skal vi bruge");// udskriver teksten i ""
            int tabel = Convert.ToInt32(Console.ReadLine());// en int der automatisk konvertere og gemmer brugerens input i tabel variablen
            for (int i = 1; i < 11; i++)//et loop der køre 10 gange
            {
                Console.WriteLine("{0, 4} * {2} = {1, 5}", i, i * tabel, tabel);// udskriver regne stykket brugeren har bedt om og resultatet af vert regne stykke
            }
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.loopsMenu();// tager brugeren tilbage til opgave menu
        }
    }
}
