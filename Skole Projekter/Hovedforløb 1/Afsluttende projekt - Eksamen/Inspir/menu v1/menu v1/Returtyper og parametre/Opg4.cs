using System;

namespace menu_v1.Returtyper_og_parametre
{
    class Opg4
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
            public void FillGas(double liters, bool isDiesel)// en metode der tager imod en double og en bool værdi
            {
                if (isDiesel)// vis boolen isdiesl er tru køre den kodne under og vis ikke køre den else functionen
                {
                    Console.WriteLine("filled tank with {0} liters of Diesel", liters);
                }
                else
                {
                    Console.WriteLine("filled tank with {0} liters of benzin", liters);
                }
            }
            public double RemainingGas(double liters, bool isDiesel)
            {
                if (isDiesel)
                {
                    Console.WriteLine("filled tank with {0} liters of Diesel", liters);
                }
                else
                {
                    Console.WriteLine("filled tank with {0} liters of Benzin", liters);
                }
                return liters;
            }
        }
        public static void opgave4()
        {
            double liters = 2.5;// en double variable med verdien 2.5
            Bil Suzuki = new Bil();//kraere et nyt object med navnet bil
            Suzuki.RemainingGas(liters, true);// sender suzukis informationer og consolen til remaininggas metoden
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.menu();// tager brugeren tilbage til opgave menu
        }
    }
}
