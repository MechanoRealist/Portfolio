using System;

namespace menu_v1.Variabler_i_udtryk
{
    class Opg1
    {
        public static void opgave1()
        {
            int var1 = 75;// en integer variable med den givne værdi af 75
            int var2 = 63;
            int var3 = 74;
            int resultat = var1 + var2 * var3;// en integer variable der udregener formlen og dernæst gæmmer det i resultat

            Console.WriteLine("75+63*74={0}", resultat);// udskriver teksten og resultet efter
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.variableUdtrykMenu();// sender brugeren tilbage til opgave menu'en
        }
    }
}
