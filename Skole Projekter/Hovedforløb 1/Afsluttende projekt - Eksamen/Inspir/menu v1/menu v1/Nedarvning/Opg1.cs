using System;

namespace menu_v1.Nedarvning
{
    class Opg1
    {
        public class Furniture
        {

            public class chair
            {
                public string navn;// en public string variable uden given værdi
                public int vægt;// en public integer variable uden given værdi
                public void PrintInfo()//en methode til at udskrive møblets navn og vægt
                {
                    Console.WriteLine("Møblet {0} vejer {1}kg.", navn, vægt);
                }
            }
            public class computer//class magen til chair klassen der er til at kontrollere computerens vægt og navn
            {
                public string navn;
                public int vægt;
                public void PrintInfo()
                {
                    Console.WriteLine("Computeren {0} vejer {1}kg.", navn, vægt);
                }
            }
        }
        public static void nedarvning()// en metode
        {
            Console.SetCursorPosition(0, 2);
            Furniture.chair stol1 = new Furniture.chair();// generere et nyt object ved navn stol1
            Furniture.computer pc1 = new Furniture.computer();
            pc1.navn = "gerda";//sætter navn på pc1 objectet til gerda
            pc1.vægt = 5;//sætter vægten på pc1 til 5
            stol1.navn = "Magnus Rasmussen";
            stol1.vægt = 10;
            pc1.PrintInfo();//udskriver informationen om pc1
            stol1.PrintInfo();
            Console.ReadLine();// pauser programmet og venter på brugerens input
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Program.Main();//sender brugeren tilbage til hovedmenu
        }
    }
}
