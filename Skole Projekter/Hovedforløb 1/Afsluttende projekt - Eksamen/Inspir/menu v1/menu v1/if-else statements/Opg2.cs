using System;

namespace menu_v1.if_else_statements
{
    class Opg2
    {

        public static void opgave2()
        {
            int alder;// en integer variable uden given værdi
            Console.WriteLine("hvor gammel er du");// udskriver teksten
            alder = Convert.ToInt32(Console.ReadLine());//convertere stringen brugeren har skrevet til integer(heltal) og gemmer det i int alder

            if (alder > 57)//kontrollere om alder er størere end 57 vis ja kør koden under
            {
                Console.WriteLine("du for gammel");
            }
            else if (alder == 22)//kontrollere om alder er det samme som 22 vis ja kør koden
            {
                Console.WriteLine("du har den perfecte alder");
            }
            else// vis de if og else if fejler køre den automatisk denne kode men er en af de andre blevet kørt springer den over her
            {
                Console.WriteLine("du ikke for gammel");
            }
            Console.ReadLine();
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.statementsMenu();
        }
    }

}
