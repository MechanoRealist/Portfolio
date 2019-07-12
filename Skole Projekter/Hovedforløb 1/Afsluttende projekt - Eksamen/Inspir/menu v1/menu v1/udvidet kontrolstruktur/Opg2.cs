using System;

namespace menu_v1.udvidet_kontrolstruktur
{
    class Opg2
    {
        public static void opgave2()
        {
            int result = 0;// en integer variable med den givne værdi af 0
            int tæller = 1;
            while (result < 21)// et loop der køre så længe result er mindre end 21
            {
                Console.WriteLine("{0} * 3 = {1}", tæller, 3 * tæller);// udskriver regne stykket og resultatet i et pænt format
                result = tæller * 3;// tæller bliver ganget med 3 og gemt i resultat
                tæller++;// tælelr bliver plusset med 1
            }
            Console.WriteLine("loopet er nu stoppet");// udskriver teksten
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.kontrolMenu();// sender brugeren tilbage til opgave menu'en
        }
    }
}
