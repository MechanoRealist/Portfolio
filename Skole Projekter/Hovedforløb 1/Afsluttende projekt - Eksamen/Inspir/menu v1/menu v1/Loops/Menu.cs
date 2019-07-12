namespace menu_v1.loops
{
    class Menu
    {
        public static void loopsMenu()
        {//forklaret i main/hoved menu
            int valg = KonsolHjælper.Menu(true, "opgave 1", "opgave 2", "opgave 3", "opgave 4", "opgave 5", "opgave 6", "opgave 7", "opgave 8", "opgave 9", "Hovedmenu");
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
                    Opg7.opgave7();
                    break;
                case 8:
                    Opg8.opgave8();
                    break;
                case 9:
                    Opg9.opgave9();
                    break;
                case 10:
                    Program.Main();
                    break;
            }
        }
    }
}
