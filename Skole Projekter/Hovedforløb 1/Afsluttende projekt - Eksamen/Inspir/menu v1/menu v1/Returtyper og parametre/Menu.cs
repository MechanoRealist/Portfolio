namespace menu_v1.Returtyper_og_parametre
{
    class Menu
    {
        public static void menu()
        {//forkalret i main/hovedmenu
            int valg = KonsolHjælper.Menu(true, "opgave 1", "opgave 2", "opgave 3", "opgave 4", "Hovedmenu");
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
                    Program.Main();
                    break;
            }
        }
    }
}
