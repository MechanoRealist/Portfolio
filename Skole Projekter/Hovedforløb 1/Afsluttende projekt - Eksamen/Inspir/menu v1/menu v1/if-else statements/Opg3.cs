using System;

namespace menu_v1.if_else_statements
{
    class Opg3
    {
        public static void opgave3()
        {
            int alder;// en integer variable uden given værdi
            Console.WriteLine("hvor gammel er du");// udskriver teksten
            alder = Convert.ToInt32(Console.ReadLine());//convertere stringen brugeren har skrevet til integer(heltal) og gemmer det i int alder
            if (alder > 60)//kontrollere om alder er størere end 60 vis ja kørere koden under
            {
                Console.WriteLine("du for gammel");
            }
            else if (alder > 49 && alder < 61)// kontrollere om tallet er størere end 49 og mindre end 61 (mellem og inkluderet 50-60)
            {
                Console.WriteLine("du hverken for gammel eller for ung");
            }
            else if (alder < 50)
            {
                Console.WriteLine("du for ung");
            }
            Console.ReadLine();//pauser programmet og venter på brugers respons
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.statementsMenu();// sender brugeren tilbage til opgave menu'en
        }
    }
}
