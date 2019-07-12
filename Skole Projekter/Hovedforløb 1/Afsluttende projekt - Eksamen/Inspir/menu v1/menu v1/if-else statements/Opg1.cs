using System;

namespace menu_v1.if_else_statements
{
    class Opg1
    {
        public static void opgave1()
        {
            int tal1 = 42;//en integer variable med en given værdi
            int tal2 = 64;
            int resultat = tal1 + tal2;// en integer variable med resultatet af regnestykket
            if (resultat > 100)// vis resultat er mere end 100 udfør koden under            
                Console.WriteLine("summen er større end 100");//udskriver teksten
            
            else if (resultat == 100)// vis resultatet er det samme som 100 kør koden under
                Console.WriteLine("summen er 100");

            else            
                Console.WriteLine("summen er mindre end 100");
            
            Console.ReadLine();
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.statementsMenu();
        }
    }
}
