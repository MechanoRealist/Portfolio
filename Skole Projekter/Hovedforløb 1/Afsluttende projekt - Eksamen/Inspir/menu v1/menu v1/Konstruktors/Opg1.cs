using System;

namespace menu_v1.Konstruktors
{
    class Opg1
    {
        public static void opgave1()
        {
            int pris = 200;
            string navn = "Test bog";
            double Penge;
            Console.WriteLine("hvor mange penge har du med i butikken?");
            Penge = Convert.ToDouble(Console.ReadLine());// konvertere stringen brugeren skriver til en dopuble værdig og gemmer den i Penge
            Bog Sherlock = new Bog();//kreaere et nyt bog object
            Sherlock.Navn = "Sherlock Holmes";//navngiver det nye object
            Sherlock.Pris = 150;//pris sætter det nye object
            Sherlock.PrintInfo();//udskriver informationen om det nye object (pris og navn på bogen)
            Sherlock.HarRåd(Penge);//kontrollere om brugeren har råd til bogen
            Bog bog1 = new Bog();
            Bog bog2 = new Bog();
            bog1.bog(pris, navn);
            bog2.bog(navn);
            bog1.PrintInfo();
            bog2.PrintInfo();
            Console.ReadLine();// pauser og afventer brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Program.Main();// sænder brugeren tilbage til hovedmenu'en
            

        }
    }
    class Bog
    {
        public string Navn;
        public double Pris;
        public void PrintInfo()
        {
            Console.WriteLine("din bog ved navn {1}. koster {0}", Pris, Navn);
        }
        public bool HarRåd(double penge)
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
        public void bog(int pris, string navn)// en get/set metode med 2 variabler
        {
            Navn = navn;
            Pris = pris;
        }
        public void bog(string titel)//en get/set metode med 1 variable
        {
            Navn = titel;
            Pris = 0;
        }
    }
}
