using System;

namespace menu_v1.Returtyper_og_parametre
{
    class Opg1
    {

        class Bil
        {
            public void tændt()// methode til at udksrive teksten under
            {
                Console.WriteLine("motoren er tændt");
            }
            public void slukket()
            {
                Console.WriteLine("motoren er slukket");
            }

        }
        public static void opgave1()
        {
            Bil Suzuki = new Bil();// kraerere et nyt object med navnet suzuki
            Suzuki.tændt();//sender bruger til tændt metoden som udskriver "motoren er tændt"
            Suzuki.slukket();
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.menu();// tager brugeren tilbage til opgave menu
        }

    }
}
