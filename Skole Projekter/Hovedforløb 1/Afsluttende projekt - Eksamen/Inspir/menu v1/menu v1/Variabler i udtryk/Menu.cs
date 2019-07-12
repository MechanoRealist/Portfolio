namespace menu_v1.Variabler_i_udtryk
{
    class Menu
    {
        public static void variableUdtrykMenu()// beskrevet i Main/hovedmenu
        {
            int valg = KonsolHjælper.Menu(true, "opgave 1", "opgave 2", "Hovedmenu");
            switch (valg)
            {
                case 1:
                    Opg1.opgave1();
                    break;
                case 2:
                    Opg2.opgave2();
                    break;
                case 3:
                    Program.Main();
                    break;
            }
        }
    }
}
