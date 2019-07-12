namespace menu_v1.udvidet_kontrolstruktur
{
    class Menu
    {
        public static void kontrolMenu()// forklarret i main/hovedmenu'en
        {
            int valg = KonsolHjælper.Menu(true, "opgave 1", "opgave 2", "opgave 3", "opgave 4", "opgave 5", "Hovedmenu");
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
                    Program.Main();
                    break;
            }
        }
    }
}
