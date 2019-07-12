using System;
using System.Linq;


namespace menu_v1.Arrays
{
    class Opg1
    {

        public static void array()
        {
            int[] test = { -2, -1, 0, 10 };// et integer array med 4 gvne verdier
            int[] test2 = new int[3];// et integer array med 4 pladser til verdier derk an gives senere
            Console.WriteLine("højste tal {0}\nLavste tal {1}", test.Max(), test.Min());//udskriver lavste og højste tal i pænt format
            for (int i = 0; i < 4; i++)// et loop der vil køre en total af 5 gange
            {
                Console.WriteLine(test[i]);//udskriver test hvor i starter i 0 og vær gang loopet er gået i gennem plusser den og udskriver næste tal i arrayet
            }
            Console.ReadLine();//pauser programmet så brugeren kan se hvad der står
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Program.Main();// sender brugeren tilbage til main aka hovedmenuen
        }

    }
}
