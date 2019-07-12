using System;

namespace menu_v1.Returtyper_og_parametre
{
    class Opg2
    {
        class Bil
        {
            public void tændt()// en metode der udskriver teksten under
            {
                Console.WriteLine("motoren er tændt");
            }
            public void slukket()
            {
                Console.WriteLine("motoren er slukket");
            }
            public void FillGas(double liters)
            {

                Console.WriteLine("filled tank with {0} liters of benzin", liters);// udskriver teksten i et pænt format med variablen liters på "{0}" pladsen

            }

        }
        public static void opgave2()
        {
            double liters = 2.5;// en double variable med verdien 2.5
            Bil Suzuki = new Bil();//kraere et nyt object med navnet bil
            Suzuki.FillGas(liters);// åbner fillgas metoden med suzuki's informationer
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.menu();// tager brugeren tilbage til opgave menu
        }
    }
}
