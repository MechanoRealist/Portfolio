using System;

namespace Autorepairshop_Case
{
    public static class ConsoleHelper
    {
        public static int Menu(bool canCancel, int prline,int y,int x, params string[] options)
        {

            int startX = x;// a int to set the start point of the menu options
            int startY = y;
            int optionsPrLine = prline;// picks how many options there is pr line
            const int spacing = 40;

            int currentChoice = 0;// the start choice is 0 in te menu

            ConsoleKey key;// a consolekey variable with no data entered

            Console.CursorVisible = false;// makes the type-cursor invisible

            do// a do while statement that will keep running til enter is presed on hte keyboard
            {
                Program.MenuBottom.Clear();
                for (int i = 0; i < options.Length; i++)//a for loop that will run as many times as there is options
                {
                    Console.SetCursorPosition(startX + (i % optionsPrLine) * spacing, startY + i / optionsPrLine);// sets the cursor position on the chosen option via a math formula

                    if (i == currentChoice)// / a if statement that checks if the option chosen is existing and if so runs the code below
                    {
                        Console.BackgroundColor = ConsoleColor.Red;// changes the background of the chosen option
                    }
                    Console.Write(options[i]);// write the rest of the options with no background color

                    Console.ResetColor();// resets the console color to black and white
                }


                key = Console.ReadKey(true).Key;//reads what key is pressed and inputs it into the key variable

                switch (key)// a switch case to controll what key was pressed
                {
                    case ConsoleKey.LeftArrow:// the case of pressen left arrowkey 
                        {
                            if (currentChoice % optionsPrLine > 0)//controlls that u dont try to go out of the options u have
                                currentChoice--;// minuses 1 from the curren choise so u go one spot left in the menu
                            break;// end current case
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (currentChoice % optionsPrLine < optionsPrLine - 1)
                                currentChoice++;
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            if (currentChoice >= optionsPrLine)
                                currentChoice -= optionsPrLine;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (currentChoice + optionsPrLine < options.Length)
                                currentChoice += optionsPrLine;
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            if (canCancel)
                                return -1;
                            break;
                        }
                }
            } while (key != ConsoleKey.Enter);
            Console.CursorVisible = true;// makes the cursor visable again
            return currentChoice;//returns the current choice
        }
        

        public static void DrawVertical(int topNode, int bottomNode, int horizontal, char symbol)
        {
            for (int i = topNode; i < bottomNode; i++)
            {
                Console.SetCursorPosition(horizontal, i);
                Console.Write(symbol);
            }
        }
        public static void DrawHorizontal(int leftNode, int rightNode, int vertical, char symbol) // prints a string between two points horizontally 
        {
            Console.SetCursorPosition(leftNode, vertical);
            Console.WriteLine(new string(symbol, rightNode - leftNode));
        }
        public static void DrawSingle(int left, int top, char symbol)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(symbol);
        }

        public static void PrintLines(int left, int top, int spacing, params string[] lines) // prints lines from starting-point with defined spacing
        {
            for (int i = 0; i < lines.Length; i++)
            {
                Console.SetCursorPosition(left, top + i * spacing);
                Console.Write(lines[i]);
            }
        }

        public static void ClearBox(int left, int top, int width, int lines) // overwriting rectangular area of the console window with spacing
        {
            string clearLine = new string(' ', width);
            for (int i = 0; i < lines; i++)
            {
                Console.SetCursorPosition(left, top + i);
                Console.Write(clearLine);
            }
        }
    }
}
