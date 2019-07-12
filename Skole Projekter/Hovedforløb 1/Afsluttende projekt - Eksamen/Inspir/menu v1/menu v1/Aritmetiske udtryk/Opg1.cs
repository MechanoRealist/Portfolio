using System;

namespace menu_v1.Aritmetiske_udtryk
{
    class Opg1
    {
        public static void aritmetik()
        {
            int variable1 = 2 + 1 * 2; // en int der gemmer resultatet af regnestykket
            int variable2 = (2 + 1) * 2;
            double variable3 = 5.0 / 2;// en doublle variable der gør det samme som integersne
            int variable4 = 8 % 3;
            int variable5 = 1 - 5;
            Console.WriteLine("2+1*2={0}\n(2+1)*2={1}\n5/2={2}\n8%3={3}\n1-5={4}", variable1, variable2, variable3, variable4, variable5);//en linje der udksriver tekst for mig i et pænt format
            Console.ReadLine();// pauser programmet så brugeren kan se hvad der står
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Program.Main();// sender programmet tilbage til main aka hoved menuen
        }
    }
}
