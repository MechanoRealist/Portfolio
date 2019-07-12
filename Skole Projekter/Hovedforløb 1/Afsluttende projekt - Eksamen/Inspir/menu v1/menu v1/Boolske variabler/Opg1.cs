using System;

namespace menu_v1.Boolske_variabler
{
    class Opg1
    {
        public static void opgave1()
        {
            int var1 = 17; int var2 = 23;// to integer variabler med givne verdier
            Boolean variable = var1 > var2;// en boolean der kontrollere om var1 er størrere end var2 og bliver sandt vis den er og falsk vis den ikke er
            Console.WriteLine(variable); // udskriver boolen (her sandt)
            Console.ReadLine();// pauser programmet
            var1 = 2000;//ændre værdien af var1
            variable = var1 > var2; // opdatere boolen 
            Console.WriteLine(variable);// udskriver boolen (her falsk)
            Console.ReadLine();
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Program.Main();//sender bruger tilbage til main aka hovedmenu
        }
    }
}
