using System;




namespace menu_v1.Metoder_og_instanser
{
    class Opg2
    {
        class Bog
        {
            public string Navn;// public string variable der uden given værdi
            public double Pris;//public double variable uden given værdi
            public void PrintInfo()// methode der udskriver navn og pris på objectet der blvier smidt ind
            {
                Console.WriteLine("din bog ved navn {1}. koster {0}", Pris, Navn);
            }
            public bool HarRåd(double pris, double penge)// en metode der kontrolere om brugeren har penge nok til bogen
            {
                if (Pris < penge)
                {
                    Console.WriteLine("Du har råd til {0} den kostede {1}", Navn, Pris);
                    return true;
                }
                else
                {
                    Console.WriteLine("du har ikke råd til {0} som kostede {1}", Navn, Pris);
                    return false;
                }
            }
        }
        public static void opgave2()
        {
            double penge;
            Console.WriteLine("hvor mange penge har du med i butikken?");// udskriver linjen og sætter cursor på næste linje
            penge = Convert.ToDouble(Console.ReadLine());//konvertere string til double og gemmer den i penge variablen
            Bog Sherlock = new Bog();// kraere et nyt object ved navn sherlock
            Sherlock.Navn = "Sherlock Holmes";
            Sherlock.Pris = 150;
            Sherlock.HarRåd(Sherlock.Pris, penge);
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.menu();// tager brugeren tilbage til opgave menu
        }
    }
}


