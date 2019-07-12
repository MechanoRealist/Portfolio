using System;

namespace menu_v1.udvidet_kontrolstruktur
{
    class Opg4
    {
        public static void opgave4()
        {
            double inkomst = 100000;//en double variable med den givne værdi af 100000
            double procent = 0;
            Console.WriteLine("skriv din indkomst");// udskriver teksten i consol vinduet
            inkomst = Convert.ToDouble(Console.ReadLine());// konvertere string til double og gemmer brugerens input i inkomst variablen
            KonsolHjælper.ClearMain();// min personificerede Console.Clear(); som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            if (inkomst < 41999)// en statement der kontrollere om inkomst er mindre end 49999 og vis den er udføre linjen under
            {
                Console.WriteLine("du betaler ikke skat");
            }
            else if (inkomst > 42000 && inkomst <= 279999)
            {
                procent = 30;
                Console.WriteLine("du skal betale {0}% i skat som svare til {1}kr.", procent, inkomst / 100 * procent);
            }
            else if (inkomst > 280000 && inkomst <= 389999)
            {
                procent = 36;
                Console.WriteLine("du skal betale {0}% i skat som svare til {1}kr.", procent, inkomst / 100 * procent);
            }
            else if (inkomst >= 390000)
            {
                procent = 51;
                Console.WriteLine("du skal betale {0}% i skat som svare til {1}kr.", procent, inkomst / 100 * procent);
            }
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.kontrolMenu();// sender brugeren tilbage til opgave menu'en
        }
    }
}
