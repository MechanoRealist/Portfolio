using System;

namespace menu_v1.if_else_statements
{
    class Opg4
    {
        public static void opgave4()
        {
            string navn; string password; string brugernavn;// 3 string variabler uden givne verdier
            Console.WriteLine("skriv dit navn");//udskriver teksten
            navn = Console.ReadLine().ToLower();// gemmer brugeresn svar og alt i lower case
            Console.WriteLine("skriv dit bruger navn");
            brugernavn = Console.ReadLine().ToLower();
            Console.WriteLine("skriv din kode");
            password = Console.ReadLine().ToLower();

            if (password == "wtf" && navn == "rasmus" && brugernavn == "haax")// controllere om kode brugernavn og navn 
            {
                Console.WriteLine("Velkommen {0}", brugernavn);
            }
            else
            {
                Console.WriteLine("brugernavn og eller kode er forkert");
            }
            Console.ReadLine();
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.statementsMenu();
        }
    }
}
