using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autorepairshop_Case
{
    class Program
    {
        //Properties that can be used in the entire program
        public static int HalfWindowWidth // automatic math to calculate mid window
        {
            get { return Console.WindowWidth / 2; }
        }
        public static int TwoThirdsWindowHieght // automatic math to calculate 2/3rd of the window
        {
            get { return Console.WindowHeight / 3 * 2; } 
        }
        public static MenuBox MenuLeft { get; set; } // 3 windows in a window
        public static MenuBox MenuRight { get; set; }
        public static MenuBox MenuBottom { get; set; }
        public static List<Customer> Customers { get; set; } // list containing customer-objects
        public static List<Car> Cars { get; set; }
        public static List<CarServicing> CarServicings { get; set; }
        public static void Main()
        {
            MenuLeft = new MenuBox { LeftBoundary = 0, RightBoundary = HalfWindowWidth - 1, TopBoundary = 0, BottomBoundary = TwoThirdsWindowHieght - 1 }; // defining the coordinates of the 3 windows
            MenuRight = new MenuBox { LeftBoundary = HalfWindowWidth + 1, RightBoundary = Console.WindowWidth, TopBoundary = 0, BottomBoundary = TwoThirdsWindowHieght - 1 };
            MenuBottom = new MenuBox { LeftBoundary = 0, RightBoundary = Console.WindowWidth, TopBoundary = TwoThirdsWindowHieght + 2, BottomBoundary = Console.WindowHeight - 1 };
            Program.MenuRight.Clear(); // fill the box with 'space' (emptying the field)
            Program.MenuLeft.Clear();
            Customers = Customer.GetList(); // getting lists from DB
            Cars = Car.GetList();
            CarServicings = CarServicing.GetList();

            DrawFrame(); 
            int menuChoice = ConsoleHelper.Menu(false, 3, MenuBottom.TopBoundary + 2, MenuBottom.LeftBoundary + 10, "Edit/Read Cars", "Edit/Read Customers", "Edit/Read Servicings"); // options for MAIN menu
            switch (menuChoice)
            {
                case 0:
                    Car.Menu();
                    break;
                case 1:
                    Customer.Menu();
                    break;
                case 2:
                    CarServicing.Menu();
                    break;
            }

            Console.WriteLine("U made it to the end somehow");
            Console.ReadLine();
        }

        public static void DrawFrame() // drawing the graphical part of the interface
        {
            ConsoleHelper.DrawHorizontal(0, Console.WindowWidth, TwoThirdsWindowHieght, '─');
            ConsoleHelper.DrawVertical(0, TwoThirdsWindowHieght, HalfWindowWidth, '│');
            ConsoleHelper.DrawSingle(HalfWindowWidth, TwoThirdsWindowHieght, '┴');
            Console.SetCursorPosition(0, 0);
        }
    }
}
