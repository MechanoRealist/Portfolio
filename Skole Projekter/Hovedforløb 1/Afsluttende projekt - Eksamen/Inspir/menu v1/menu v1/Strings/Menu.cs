namespace menu_v1.Strings
{
    class Menu
    {
        public static void stringsMenu()//forklaret i main/hovedmenu
        {
            KonsolHjælper.ClearMain();
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
