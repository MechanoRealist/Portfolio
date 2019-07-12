using System;

namespace menu_v1.Instancevariabler
{
    class Opg1
    {
        class Bog
        {
            public string Navn;// en public string variable til brug flere steder i dette namespace
            public double Pris;// en public double variable til brug flere steder i dette namespace
            public void PrintInfo()//en metode til at udskrive navn og pris på bøger
            {
                Console.WriteLine("din bog ved navn {1}. koster {0}", Pris, Navn);// udskriver navn og pris i et pænt format
            }

            public bool HarRåd(double Penge)// en methode der retunere en sand/falsk verdi alt efter om man har råd til bogen eller ej
            {
                if (Pris < Penge)// en if statement der kontrollere om Pris er mindre end Penge og vis den er køre koden under
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
        public static void opgave1()
        {
            double Penge;
            Console.WriteLine("hvor mange penge har du med i butikken?");
            Penge = Convert.ToDouble(Console.ReadLine());// konvertere stringen brugeren skriver til en dopuble værdig og gemmer den i Penge
            Bog Sherlock = new Bog();//kreaere et nyt bog object
            Sherlock.Navn = "Sherlock Holmes";//navngiver det nye object
            Sherlock.Pris = 150;//pris sætter det nye object
            Sherlock.PrintInfo();//udskriver informationen om det nye object (pris og navn på bogen)
            Sherlock.HarRåd(Penge);//kontrollere om brugeren har råd til bogen
            Console.ReadLine();//pauser programmet og venter på brugers input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Program.Main();
        }
    }
}
