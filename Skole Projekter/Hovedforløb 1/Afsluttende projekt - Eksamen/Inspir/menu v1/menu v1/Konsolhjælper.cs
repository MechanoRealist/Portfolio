using System;

namespace menu_v1
{
    public class KonsolHjælper
    {
        public static int Menu(bool canCancel, params string[] muligheder)
        {
            const int startX = 10;// en constant integer variable med den faste værdi af 10
            const int startY = 25;
            const int MulighederprLinje = 4;
            const int Mellemrum = 25;
            ClearMenu();

            int nuværendeValg = 0;// en integer variable med en given værdi af 0 (første værdi i menuen)

            ConsoleKey key;// en consolekey variable uden given værdi til senere brug i methoden

            Console.CursorVisible = false;// gør så man ikke can se hvor cursor er og dermed ikke kan se hvor consolen er i gang med at skrive

            do// en do while statement der køre indtil brugeren trykker på enter
            {

                for (int i = 0; i < muligheder.Length; i++)//et for loop der køre lige så længe som der er muligheder tilbage
                {
                    Console.SetCursorPosition(startX + (i % MulighederprLinje) * Mellemrum, startY + i / MulighederprLinje);// sætter cursor på den valgte genstan udregnet af formlen

                    if (i == nuværendeValg)// en if statement der kontrollere om i er på en valgmulighed og vis den er udføre koden under
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;// skifter baggrunds farven på den valgte genstan
                    }
                    Console.Write(muligheder[i]);// udskriver alle mulighederne en efter en som loopet køre igennem

                    Console.ResetColor();// sætter farven tilbage til normal sort baggrund med hvid tekst
                }

                key = Console.ReadKey(true).Key;//læser hvilken tast brugeren trykker på og gæmmer det i Key variablen

                switch (key)// en switch case der kigger efter hvilken værdi der er gæmt i Key
                {
                    case ConsoleKey.LeftArrow:// en case som køre vis brugeren trykkede på pil til venstre
                        {
                            if (nuværendeValg % MulighederprLinje > 0)// en if statement der kontrollere at brugeren ikke går ud fra menu mulighederne vis dne ikke gør kørere den linjen under
                                nuværendeValg--;// minuser en i nuværenevalg variablen og dermed går en mulighed tilbage
                            break;// afslutter nuværende case
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (nuværendeValg % MulighederprLinje < MulighederprLinje - 1)
                                nuværendeValg++;
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            if (nuværendeValg >= MulighederprLinje)
                                nuværendeValg -= MulighederprLinje;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (nuværendeValg + MulighederprLinje < muligheder.Length)
                                nuværendeValg += MulighederprLinje;
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            if (canCancel)// vis menuen har modtaget en true variable på canCancel's plads da man sendte dne hertil vil du have mulighed for at lukke programmet automatisk
                                return -1;// reutrnere en værdi af -1 hviket ikke er en mulighed i menuens switch case i Program/menu.cs filerne og programemt vildermed bare lukke ned
                            break;
                        }
                }
            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;// sætter cursor som synlig igen så brugeren kan se hvor han skriver igen
            ClearMain();// en hjemme lavet console.clear lavet til at cleare opgave delen af mit template
            return nuværendeValg + 1;//værdien i nuværendeValg bliver nu plusset med et da hele menuen startedede i 0 og vores switch cases er lavet uden en 0 mulighed
        }
        public static void drawFrame()// en methode lavet til at tegne template layout
        {
            for (int i = 0; i < Console.WindowWidth; i++)// et loop der køre lige så længe som vinduet er langt
            {
                Console.SetCursorPosition(40, 0);// sætter cursor positionen ca i midten af skæmen på linje 0
                Console.WriteLine("Hej og Velkommen til mine Opgaver");// udskriver teksten i consolen
                Console.SetCursorPosition(i, 1);// sætter positionen af cursår det sted på skærmen som loopet er nået til på linje 1
                Console.Write("_");// udskriver øverste "barriere" og mærkere hvor opgaverne bliver vist og hvor min overskrift står
                Console.SetCursorPosition(i, 24);
                Console.Write("_");
            }
            Console.SetCursorPosition(0, 2);
        }
        public static void ClearMain()// en metode lavet til at at tømme "Program området" af consollen
        {
            Console.CursorVisible = false;
            for (int i = 2; i < 24; i++)// loopet vil køre fra linje 2 og til den rammer linje 24
            {
                for (int d = 0; d < Console.WindowWidth; d++)
                {
                    Console.SetCursorPosition(d, i);
                    Console.Write(" ");

                }
            }
            Console.CursorVisible = true;
            Console.SetCursorPosition(0, 2);// sætter skrive positionen tilbage til linje 2 så programemt er klar til at udskrive diverse opgaver
        }
        public static void ClearMenu()// en metode til at tømme menu delen af consol vinduet som ligger mellem line 25 og 29
        {
            for (int i = 25; i < 29; i++)
            {
                for (int d = 0; d < Console.WindowWidth; d++)
                {
                    Console.SetCursorPosition(d, i);
                    Console.Write(" ");

                }
            }
            Console.SetCursorPosition(0, 2);
        }
    }
}
