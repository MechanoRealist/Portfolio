using System;

namespace menu_v1.if_else_statements
{
    class Opg7
    {
        public static void opgave7()
        {
            int alder;// en integer variable uden given værdi
            Console.Title = "Festen";//sætter titlen på programmet
            Console.WriteLine("skriv din alder");//udskriver teksten
            alder = Convert.ToInt32(Console.ReadLine());//convertere stringen til int og gemmer det i alder
            if (alder > 18)//kontrollere om alder er mere end 18
            {
                Coctail();
            }
            else
            {
                sodavan();
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            KonsolHjælper.drawFrame();// en methode der tegner framen til menu og opgaver
            KonsolHjælper.ClearMain();// min personificerede clear som fylder det midterse af mit vindue med mellemrum dermed "tømmer" consolen
            KonsolHjælper.ClearMenu();// min personificerede clear som fylder det nederste af mit vindue med mellemrum dermed "tømmer" menu delen af consolen
            Menu.statementsMenu();// sender brugeren tilbage til emne menu'en
        }
        static void Coctail()// en metode der kontroler hvilken farve brugeren vælger og sætter baggrunden til den farve
        {
            string farve;//en string variable til senere brug af brugeren uden given værdi
            Console.WriteLine("hvilken farve vil ud have (rød, grøn, brå, gul)");// udskriver teksten med spørgsmål til brugeren
            farve = Console.ReadLine();// gemmer brugeren svar i string variablen farve
            if (farve == "rød")
            {
                Console.BackgroundColor = ConsoleColor.Red;// ændre baggrunds farven til rød

                Console.Clear();// sørger for vinduet er tomt så hele vinduet skifter farve
                KonsolHjælper.drawFrame();// efter en console.clear skal jeg gen tegne min frame
            }
            if (farve == "blå")
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Clear();
                KonsolHjælper.drawFrame();
            }
            if (farve == "grøn")
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Clear();
                KonsolHjælper.drawFrame();
            }
            if (farve == "gul")
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Clear();
                KonsolHjælper.drawFrame();
            }
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("velkommen til coctailbaren");
            Console.ReadLine();
        }
        static void sodavan()
        {
            string farve;
            Console.WriteLine("hvilken farve vil ud have (rød, grøn, brå, gul)");
            farve = Console.ReadLine();
            if (farve == "rød")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Clear();
                KonsolHjælper.drawFrame();
            }
            if (farve == "blå")
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Clear();
                KonsolHjælper.drawFrame();
            }
            if (farve == "grøn")
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Clear();
                KonsolHjælper.drawFrame();
            }
            if (farve == "gul")
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Clear();
                KonsolHjælper.drawFrame();
            }
            Console.WriteLine("Velkommen til sodavandsbaren");
            Console.ReadLine();
        }
    }
}
