using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ArrowKey_Arrows_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Image image;
        Graphics g;
        AdjustableArrowCap arrowCap;
        LineCap lineCap;
        Pen arrowPen;
        Pen arrowEraser;
        Point middleOfPicture;
        Point upStart;
        Point upEnd;
        Point downStart;
        Point downEnd;
        Point leftStart;
        Point leftEnd;
        Point rightStart;
        Point rightEnd;

        private void Form1_Load(object sender, EventArgs e)
        {
            image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = image;
            g = Graphics.FromImage(image);
            arrowCap = new AdjustableArrowCap(2, 1, true);
            arrowCap.BaseCap = LineCap.Round;
            arrowCap.StrokeJoin = LineJoin.Bevel;
            arrowCap.BaseInset = 5;
            arrowCap.WidthScale = 3;
            lineCap = new LineCap();
            arrowPen = new Pen(Color.Black);
            arrowPen.Width = 3;
            arrowPen.StartCap = lineCap;
            arrowPen.CustomEndCap = arrowCap;
            arrowEraser = new Pen(pictureBox1.BackColor);
            arrowEraser.Width = 3;
            arrowEraser.StartCap = lineCap;
            arrowEraser.CustomEndCap = arrowCap;
            middleOfPicture = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            upStart = new Point(middleOfPicture.X, middleOfPicture.Y - 5);
            upEnd = new Point(middleOfPicture.X, 10);
            downStart = new Point(middleOfPicture.X, middleOfPicture.Y + 5);
            downEnd = new Point(middleOfPicture.X, pictureBox1.Height - 10);
            leftStart = new Point(pictureBox1.Width / 2 - 5, pictureBox1.Height / 2);
            leftEnd = new Point(10, pictureBox1.Height / 2);
            rightStart = new Point(pictureBox1.Width / 2 + 5, pictureBox1.Height / 2);
            rightEnd = new Point(pictureBox1.Width - 10, middleOfPicture.Y);
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    LB_UP.Visible = true;
                    g.DrawLine(arrowPen, upStart, upEnd);
                    pictureBox1.Refresh();
                    break;
                case Keys.Down:
                    LB_DOWN.Visible = true;
                    g.DrawLine(arrowPen, downStart, downEnd);
                    pictureBox1.Refresh();
                    break;
                case Keys.Left:
                    LB_LEFT.Visible = true;
                    g.DrawLine(arrowPen, leftStart, leftEnd);
                    this.Refresh();
                    break;
                case Keys.Right:
                    LB_RIGHT.Visible = true;
                    g.DrawLine(arrowPen, rightStart, rightEnd);
                    pictureBox1.Refresh();
                    break;
                default:
                    break;
            }

        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    LB_UP.Visible = false;
                    g.DrawLine(arrowEraser, upStart, upEnd);
                    pictureBox1.Refresh();
                    break;
                case Keys.Down:
                    LB_DOWN.Visible = false;
                    g.DrawLine(arrowEraser, downStart, downEnd);
                    pictureBox1.Refresh();
                    break;
                case Keys.Left:
                    LB_LEFT.Visible = false;
                    g.DrawLine(arrowEraser, leftStart, leftEnd);
                    pictureBox1.Refresh();
                    break;
                case Keys.Right:
                    LB_RIGHT.Visible = false;
                    g.DrawLine(arrowEraser, rightStart, rightEnd);
                    pictureBox1.Refresh();
                    break;
                default:
                    break;
            }
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
                default:
                    break;
            }
        }

        
    }
}
