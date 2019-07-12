using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrydsOgBolle
{
    class Program
    {
        enum feldt //Enumerator for de enheder der kan være i kryds og bolle.
        {
            tom, kryds, bolle
        }
        static feldt[,] spilbræt = new feldt[3, 3]; //Et 2D array for spilbrættets logik
        static void Main(string[] args)
        {
            for (int x = 0; x < spilbræt.GetLength(0); x++) //Fylder hele arrayet med tom.
            {
                for (int y = 0; y < spilbræt.GetLength(1); y++)
                {
                    spilbræt[x, y] = feldt.tom;
                }
            }
            feldt vinder = feldt.tom; //Spillet starter uden nogen vinder.
            
            
            Ramme(); //Tegner rammen i konsollen.
            Console.SetCursorPosition(0, 1);
            Console.Write("\"0\" giver turen videre!"); //Det er ikke en bug det er en feature.
            Console.SetCursorPosition(0, 0);
            feldt tur = feldt.kryds; //Kryds starter altid.
            Console.Write("Kryds tur: ");
            int input; //Input variabel.
            while (vinder == feldt.tom) //Loop sikrer man har tastet et tal.
            {
                bool tast = true;
                do
                {
                    try
                    {
                        input = Convert.ToInt32(Console.ReadKey().KeyChar.ToString());
                        tast = false;
                    }
                    catch
                    { input = 0; }
                } while (tast);
                
                switch(input) //Switch case for array koordinater, konsol koordinater og tur.
                {
                    case 1:
                        Mark(0, 0, 8, 6, tur);
                        break;
                    case 2:
                        Mark(1, 0, 14, 6, tur);
                        break;
                    case 3:
                        Mark(2, 0, 20, 6, tur);
                        break;
                    case 4:
                        Mark(0, 1, 8, 10, tur);
                        break;
                    case 5:
                        Mark(1, 1, 14, 10, tur);
                        break;
                    case 6:
                        Mark(2, 1, 20, 10, tur);
                        break;
                    case 7:
                        Mark(0, 2, 8, 14, tur);
                        break;
                    case 8:
                        Mark(1, 2, 14, 14, tur);
                        break;
                    case 9:
                        Mark(2, 2, 20, 14, tur);
                        break;
                    default:
                        break;
                }
                Blank();
                if (tur == feldt.kryds) //Skifter til den andens tur.
                {
                    Console.Write("Bolles tur: ");
                    tur = feldt.bolle;
                }
                else
                {
                    Console.Write("Kryds tur: ");
                    tur = feldt.kryds;
                }
                vinder = HarVundet(spilbræt); //Sender spilbrættet til at tjekke om nogen har vundet.
            }
            Blank();
            if(vinder == feldt.kryds)
            {
                Console.WriteLine("Kryds har vundet!");
            }
            if (vinder == feldt.bolle)
            {
                Console.WriteLine("Bolle har vundet!");
            }
            Console.ReadKey();
        }
        static void Blank() //Gør så første række i konsollen er blank.
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, 0);
        }
        static void Mark(int arrayV, int arrayH, int consoleV, int consoleH, feldt tur) //Sættet et mærke på spilbrættet.
        {
            spilbræt[arrayV, arrayH] = tur;
            if (tur == feldt.kryds) Kryds(consoleV, consoleH);
            if (tur == feldt.bolle) Bolle(consoleV, consoleH);
        }
        static feldt HarVundet(feldt[,] brædt) 
        {
            feldt vinder = feldt.tom;
            if (vinder == feldt.tom)
            {
                vinder = RowsAndColumns(brædt, true); //Tjekker rækker.
            }
            if (vinder == feldt.tom)
            {
                vinder = RowsAndColumns(brædt, false); //Tjekker kolonner.
            }
            if (vinder == feldt.tom) //Tjekker diagonalerne.
            {
                if ((brædt[0, 0] == brædt[1, 1] && brædt[1, 1] == brædt[2, 2]) && brædt[0,0] != feldt.tom)
                {
                    vinder = brædt[0, 0];
                }
            }
            if (vinder == feldt.tom)
            {
                if ((brædt[2, 0] == brædt[1, 1] && brædt[1, 1] == brædt[0, 2]) && brædt[2, 0] != feldt.tom)
                {
                    vinder = brædt[2, 0];
                }
            }
            return vinder;
        }
        static feldt RowsAndColumns(feldt[,] brædt, bool rows) //Når den ser et kryds lægger den 1 til count og når den ser en bolle trækker den 1 fra count.
        {
            int count = 0;
            feldt vinder = feldt.tom;
            for (int x = 0; x < brædt.GetLength(0); x++)
            {
                count = 0;
                for (int y = 0; y < brædt.GetLength(1); y++)
                {
                    if (rows)
                    {
                        if (brædt[x, y] == feldt.tom)
                        {
                            break;
                        }
                        if (brædt[x, y] == feldt.kryds)
                        {
                            count++;
                        }
                        if (brædt[x, y] == feldt.bolle)
                        {
                            count--;
                        }
                    }
                    else
                    {
                        if (brædt[y, x] == feldt.tom)
                        {
                            break;
                        }
                        if (brædt[y, x] == feldt.kryds)
                        {
                            count++;
                        }
                        if (brædt[y, x] == feldt.bolle)
                        {
                            count--;
                        }
                    }
                }
                if (count > 2) vinder = feldt.kryds;
                if (count < -2) vinder = feldt.bolle;
            }
            return vinder;
        }
        static void Ramme()
        {
            int v = 5, h = 5;
            Console.SetCursorPosition(v, h);
            Console.Write("┌─────┬─────┬─────┐");  
            Console.SetCursorPosition(v, h + 1);
            Console.Write("│     │     │     │"); 
            Console.SetCursorPosition(v, h + 2);
            Console.Write("│  1  │  2  │  3  │"); 
            Console.SetCursorPosition(v, h + 3);
            Console.Write("│     │     │     │"); 
            Console.SetCursorPosition(v, h + 4);
            Console.Write("├─────┼─────┼─────┤"); 
            Console.SetCursorPosition(v, h + 5);
            Console.Write("│     │     │     │");
            Console.SetCursorPosition(v, h + 6);
            Console.Write("│  4  │  5  │  6  │"); 
            Console.SetCursorPosition(v, h + 7);
            Console.Write("│     │     │     │");
            Console.SetCursorPosition(v, h + 8);
            Console.Write("├─────┼─────┼─────┤");
            Console.SetCursorPosition(v, h + 9);
            Console.Write("│     │     │     │");
            Console.SetCursorPosition(v, h + 10);
            Console.Write("│  7  │  8  │  9  │");
            Console.SetCursorPosition(v, h + 11);
            Console.Write("│     │     │     │");
            Console.SetCursorPosition(v, h + 12);
            Console.Write("└─────┴─────┴─────┘");
        }
        static void Kryds(int v, int h)
        {
            Console.SetCursorPosition(v, h);
            Console.Write("X");
            Console.SetCursorPosition(v - 1, h + 1);
            Console.Write("X X");
            Console.SetCursorPosition(v, h + 2);
            Console.Write("X");
        }
        static void Bolle(int v, int h)
        {
            Console.SetCursorPosition(v, h);
            Console.Write("O");
            Console.SetCursorPosition(v - 1, h + 1);
            Console.Write("O O");
            Console.SetCursorPosition(v, h + 2);
            Console.Write("O");
        }

    }
}