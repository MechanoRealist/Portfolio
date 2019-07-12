using System;

namespace menu_v1.udvidet_kontrolstruktur
{
    class Opg1
    {
        public static void opgave1()
        {
            int result;// en integer variable uden given værdi
            for (int i = 1; i <= 21; i++)// et loop der køre 20 gange
            {
                result = i * 3;//i bliver ganget emd 3 og gemt i resultat variablen
                Console.WriteLine(i * 3);// udskriver regne stykket
                if (result == 21)// en statement der kontrolere om result har ramt 21
                {
                    Console.WriteLine("du ramte 21 loopet er nu stoppet");// udskriver teksten

                    break;// stopper loopet
                }

            }
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.kontrolMenu();// sender brugeren tilbage til opgave menu'en
        }
    }
}
