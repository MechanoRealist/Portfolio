using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autorepairshop_Case
{
    class MenuBox
    {
        public int LeftBoundary { get; set; }
        public int RightBoundary { get; set; }
        public int TopBoundary { get; set; }
        public int BottomBoundary { get; set; }

        public int Width
        {
            get { return RightBoundary - LeftBoundary; }
        }

        public int Height
        {
            get { return BottomBoundary - TopBoundary; }
        }

        public void Clear()
        {
            ConsoleHelper.ClearBox(LeftBoundary, TopBoundary, Width, Height);
        }

        public void PrintContent(string[] content)
        {
            for (int i = 0; i < content.Length; i++) // loop through string-array. checking for too long strings
            {
                if (content[i].Length > Width)
                {
                    content[i] = content[i].Substring(0, Width); // cuts the string into correct length
                }
            }
            ConsoleHelper.PrintLines(LeftBoundary, TopBoundary, 2, content); // making sure of the lines are printed in the correct position
        }
    }
}
