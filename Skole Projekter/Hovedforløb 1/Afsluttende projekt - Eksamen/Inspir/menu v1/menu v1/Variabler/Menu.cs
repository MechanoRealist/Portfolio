using System;

namespace menu_v1.Variabler
{
    class Menu
    {
        public static void VariablerMenu()// forkalret i main/hovedmenu'en
        {
            KonsolHjælper.ClearMain();
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("du har nu følgene valgmuligheder");
            int valg = KonsolHjælper.Menu(true, "opgave 1", "opgave 2", "opgave 3", "opgave 4", "opgave 5", "opgave 6", "Hovedmenu");
            switch (valg)
            {
                case 1:
                    Opg1.opgave1();
                    break;
                case 2:
                    Opg2.opgave2();
                    break;
                case 3:
                    Opg3.opgave3();
                    break;
                case 4:
                    Opg4.opgave4();
                    break;
                case 5:
                    Opg5.opgave5();
                    break;
                case 6:
                    Opg6.opgave6();
                    break;
                case 7:
                    Program.Main();
                    break;
            }
        }
    }
}
