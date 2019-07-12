using System;

namespace menu_v1.Gennemløb_af_arrays
{
    class Opg1
    {
        public static void garray()
        {
            int[] test = { 5, 4, 3, 7, 5, 3 };// et integer array med 6 givne værdier
            for (int i = 0; i < test.Length; i++)//et loop der køre så længe der stadig er tal i test arrayet
            {
                Console.WriteLine(test[i]);// udskriver den plads der svare til i fra arrayet
            }
            string[] text = new string[6];// et string array der har 6 pladser men ingen givne værdier
            for (int i = 0; i < 6; i++)
            {
                text[i] = "linje ";// gæmmer teksten i array pladsen der svare til i
                text[i] += Convert.ToString(i);// tilføjer tallet svarene til i på samme plads som linjen over
                Console.WriteLine(text[i]);// udskriver det tekst der er på pladsen der svare til i. i string arrayet
            }
            Console.ReadLine();//pauser programmet og afventer brugers respons
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" opgave delen af consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Program.Main();// sender brugeren tilbage til hovedmenu
        }
    }
}
