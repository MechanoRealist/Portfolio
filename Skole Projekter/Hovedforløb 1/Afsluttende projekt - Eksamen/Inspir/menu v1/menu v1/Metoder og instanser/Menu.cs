namespace menu_v1.Metoder_og_instanser
{
    class Menu
    {
        public static void menu()
        {// forklaret i main/hovedmenu'en
            KonsolHjælper.ClearMain();
            int valg = KonsolHjælper.Menu(false, "opgave 1", "opgave 2", "Hovedmenu");
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
