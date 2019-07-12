using System;

namespace menu_v1.udvidet_kontrolstruktur
{
    class Opg5
    {
        public static void opgave5()
        {
            double konto = 0;//en double variable med den givne værdi af 0
            double rente = 0;
            Console.WriteLine("hvor meget står der på din konto");// udskriver teksten
            konto = Convert.ToDouble(Console.ReadLine());//konvertere brugeresns input til double og gememr den i konto variablen
            if (konto <= 25000)// en statement der kontrollerer om konto er mindre eller lig 25000
            {
                rente = 0.25;
                Console.WriteLine("du har {0} på kontoen og din rente er dermed {1}% og det giver {2:n2}kr årligt.", konto, rente, konto * rente / 100);
            }
            else if (konto > 25000 && konto <= 149999)// kontrollere om konto er størere end 25000 OG mindre end 149999
            {
                rente = 1.25;
                Console.WriteLine("du har {0} på kontoen og din rente er dermed {1}% og det giver {2:n2}kr årligt.", konto, rente, konto * rente / 100);

            }
            else if (konto > 150000)
            {
                Console.WriteLine("du har {0} på kontoen og din rente er dermed {1}% på de første 150,000kr og 0,5 på resten {2:n2}", konto, rente, (150000 * 1.25 / 100) + (konto - 150000) * 0.5 / 100);
            }
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.kontrolMenu();// sender brugeren tilbage til opgave menu'en
        }
    }
}
