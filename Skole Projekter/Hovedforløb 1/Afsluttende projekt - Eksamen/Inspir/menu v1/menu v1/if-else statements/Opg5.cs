using System;

namespace menu_v1.if_else_statements
{
    class Opg5
    {
        public static void opgave5()
        {
            while (true)
            {
                string navn; string password; string brugernavn;// 3 string variabler uden givne verdier
                Console.WriteLine("skriv dit navn");//udskriver teksten
                brugernavn = Console.ReadLine().ToLower();// gemmer brugeresn svar og alt i lower case
                if (brugernavn == "haax")//kontrolere brugernavnet er korrekt
                {
                    Console.WriteLine("skriv din kode");
                    password = Console.ReadLine();
                    if (password == "wtf")
                    {
                        Console.WriteLine("skriv dit navn");
                        navn = Console.ReadLine();
                        if (navn == "rasmus")
                        {
                            Console.WriteLine("Velkommen {0}", navn);
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("koden var forkert start forfra og prøv igen");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("brugernavn var forkertstart forfra og prøv igen");
                    break;
                }
            }
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.statementsMenu();
        }
    }
}
