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

using NKH.MindSqualls;
using NKH.MindSqualls.MotorControl;

//Redigeret af Frederik Tor Nessling på Hold 21088183d03 i Frederikssund
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        bool isConnectedToBrick;
        bool motorControlActive;
        McNxtBrick McBrick;

        McNxtMotor McMotorA;
        McNxtMotor McMotorB;
        McNxtMotor McMotorC;
        // Syncronize the two motors.
        McNxtMotorSync McMotorPair;

        NxtBrick brick;

        NxtMotor motorA;
        NxtMotor motorB;
        NxtMotor motorC;

        //Default input in COM port Textbox 'COMportInput'
        string WatermarkText = "3";

        //Graphics
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

        int speed;
        int upArrow;
        int downArrow;
        int leftArrow;
        int rightArrow;
        int rightMotor;
        int leftMotor;

        public Form1()
        {
            InitializeComponent();
            COMportInput.ForeColor = SystemColors.GrayText;
            COMportInput.Text = WatermarkText;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            isConnectedToBrick = false;
            motorControlActive = false;
            this.TB_Speed.ValueChanged += new EventHandler(Speed_Changed);
            speed = TB_Speed.Value;
            LB_Speed.Text = "Speed: " + TB_Speed.Value;
            #region Graphics objects
            image = new Bitmap(arrowKeyDisplay.Width, arrowKeyDisplay.Height);
            arrowKeyDisplay.Image = image;
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
            arrowEraser = new Pen(arrowKeyDisplay.BackColor);
            arrowEraser.Width = 3;
            arrowEraser.StartCap = lineCap;
            arrowEraser.CustomEndCap = arrowCap;
            middleOfPicture = new Point(arrowKeyDisplay.Width / 2, arrowKeyDisplay.Height / 2);
            upStart = new Point(middleOfPicture.X, middleOfPicture.Y - 5);
            upEnd = new Point(middleOfPicture.X, 10);
            downStart = new Point(middleOfPicture.X, middleOfPicture.Y + 5);
            downEnd = new Point(middleOfPicture.X, arrowKeyDisplay.Height - 10);
            leftStart = new Point(arrowKeyDisplay.Width / 2 - 5, arrowKeyDisplay.Height / 2);
            leftEnd = new Point(10, arrowKeyDisplay.Height / 2);
            rightStart = new Point(arrowKeyDisplay.Width / 2 + 5, arrowKeyDisplay.Height / 2);
            rightEnd = new Point(arrowKeyDisplay.Width - 10, middleOfPicture.Y);
            #endregion
        }

        //Brick connection procedure logic
        private void button_connect_Click(object sender, EventArgs e)
        {
            if (!isConnectedToBrick)
            {
                byte COMport = byte.Parse(COMportInput.Text);

                if (RB_McRXE.Checked)
                {
                    //Create Motor Control NXT Brick and Bluetooth use USB to communicate with it.
                    if (RB_Bluetooth.Checked)
                    {
                        McBrick = new McNxtBrick(NxtCommLinkType.Bluetooth, COMport);
                    }
                    //Create Motor Control NXT Brick, and use USB to communicate with it.
                    if (RB_USB.Checked)
                    {
                        brick = new McNxtBrick(NxtCommLinkType.USB, COMport);
                    }
                    // Create a Motor Control motor.
                    McMotorA = new McNxtMotor();
                    McMotorB = new McNxtMotor();
                    McMotorC = new McNxtMotor();

                    //Synched motors
                    McMotorPair = new McNxtMotorSync(McMotorB, McMotorC);

                    // Attach it to port A of the NXT brick.
                    McBrick.MotorA = McMotorA;
                    McBrick.MotorB = McMotorB;
                    McBrick.MotorC = McMotorC;


                    // Connect to the NXT.
                    McBrick.Connect();

                    if (!McBrick.IsMotorControlRunning())
                        McBrick.StartMotorControl();
                    motorControlActive = true;


                }
                else
                {
                    //Create NXT Brick and Bluetooth use USB to communicate with it.
                    if (RB_Bluetooth.Checked)
                    {
                        NxtBrick brick = new NxtBrick(NxtCommLinkType.Bluetooth, COMport);
                    }
                    // Create a NXT brick, and use USB to communicate with it.
                    if (RB_USB.Checked)
                    {
                        NxtBrick brick = new NxtBrick(NxtCommLinkType.USB, COMport);
                    }
                    // Create a motor.
                    motorA = new NxtMotor();
                    motorB = new NxtMotor();
                    motorC = new NxtMotor();

                    // Attach it to port A of the NXT brick.
                    brick.MotorA = motorA;
                    brick.MotorB = motorB;
                    brick.MotorC = motorC;

                    // Connect to the NXT.
                    brick.Connect();
                }
                ConnectedText.Visible = true;
                isConnectedToBrick = true;
            }
        }
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Disconnect from the NXT.
            if (brick != null)
            {
                if (brick.IsConnected)
                {
                    brick.Disconnect();
                }
            }
            if (McBrick != null)
            {
                if (McBrick.IsConnected)
                {
                    McBrick.Disconnect();
                }
            }
        }

        #region Arrowkey control
        //Key capture
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

        //Key pressed down analysis
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrow = speed;
                    g.DrawLine(arrowPen, upStart, upEnd);
                    break;
                case Keys.Down:
                    downArrow = speed;
                    g.DrawLine(arrowPen, downStart, downEnd);
                    break;
                case Keys.Left:
                    leftArrow = speed;
                    g.DrawLine(arrowPen, leftStart, leftEnd);
                    break;
                case Keys.Right:
                    rightArrow = speed;
                    g.DrawLine(arrowPen, rightStart, rightEnd);
                    break;
                default:
                    break;
            }
            arrowKeyDisplay.Refresh();
            //Mortor logic for arrow button control

            rightMotor = upArrow - downArrow + leftArrow / 2;
            leftMotor = upArrow - downArrow + rightArrow / 2;
            if(rightMotor < 0 || leftMotor < 0)
            {
                rightMotor = -speed + rightArrow / 2;
                leftMotor = -speed + leftArrow / 2;
            }
            if(rightMotor > 0 && leftMotor > 0)
            {
                rightMotor = speed - rightArrow / 2;
                leftMotor = speed - leftArrow / 2;
            }

            Console.WriteLine("Left: " + leftMotor + " Right: " + rightMotor);
            if(isConnectedToBrick)
            {
                MotorCommand();
            }
            
        }

        //Key released analysis
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Up:
                    upArrow = 0;
                    g.DrawLine(arrowEraser, upStart, upEnd);
                    break;
                case Keys.Down:
                    downArrow = 0;
                    g.DrawLine(arrowEraser, downStart, downEnd);
                    break;
                case Keys.Left:
                    leftArrow = 0;
                    g.DrawLine(arrowEraser, leftStart, leftEnd);
                    break;
                case Keys.Right:
                    rightArrow = 0;
                    g.DrawLine(arrowEraser, rightStart, rightEnd);
                    break;
                default:
                    break;
            }
            arrowKeyDisplay.Refresh();
            //Motor reset logic
            rightMotor = upArrow + downArrow + leftArrow;
            leftMotor = upArrow + downArrow + rightArrow;
            if (isConnectedToBrick)
            {
                MotorCommand();
            }
        }

        //Command sender to brick
        private void MotorCommand()
        {
            if(rightMotor == 0 && leftMotor == 0)
            {
                McMotorPair.Brake();
                McMotorPair.Idle();
            } else
            {
                if (motorControlActive)
                {
                    McMotorB.RunAndCoast((sbyte)rightMotor, 0);
                    McMotorC.RunAndCoast((sbyte)leftMotor, 0);
                }
                else
                {
                    motorB.Run((sbyte)rightMotor, 0);
                    motorC.Run((sbyte)leftMotor, 0);
                }
                
            }
        }
        #endregion
    
        #region Fine control buttons
        private void button_left_Click(object sender, EventArgs e)
        {
            //Run right motor
            if (isConnectedToBrick)
            {
                if (RB_McRXE.Checked)
                {
                    McMotorB.Run(50, 100);
                }
                else
                {
                    motorB.Run(50, 90);
                }
            }
        }

        private void button_right_Click(object sender, EventArgs e)
        {
            //Run left motor
            if (isConnectedToBrick)
            {
                if (RB_McRXE.Checked)
                {
                    McMotorC.Run(50, 180);
                }
                else
                {
                    motorC.Run(50, 90);
                }
            }
        }

        private void button_forward_Click(object sender, EventArgs e)
        {
            //Run both motors
            if (isConnectedToBrick)
            {
                if (RB_McRXE.Checked)
                {
                    McMotorPair.Run(50, 180, 0);

                }
                else
                {
                    motorB.Run(50, 180);
                    motorC.Run(50, 100);
                }
            }
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            //Reverse both motors
            if (isConnectedToBrick)
            {
                if (RB_McRXE.Checked)
                {
                    McMotorPair.Run(-50, 180, 0);
                }
                else
                {
                    motorB.Run(-50, 90);
                    motorC.Run(-50, 90);
                }
            }
        }
        #endregion

        #region Graphics code
        private void COMportInput_Enter(object sender, EventArgs e)
        {
            if(COMportInput.Text == WatermarkText)
            {
                COMportInput.Text = "";
                COMportInput.ForeColor = SystemColors.WindowText;
            }
        }
        private void COMportInput_Leave(object sender, EventArgs e)
        {
            if(COMportInput.TextLength == 0)
            {
                COMportInput.Text = WatermarkText;
                COMportInput.ForeColor = SystemColors.GrayText;
            }
        }

        //Speed slider
        private void Speed_Changed(object sender, EventArgs e)
        {
            speed = TB_Speed.Value;
            LB_Speed.Text = "Speed: " + speed;
        }
        #endregion

        private void button_GO_Click(object sender, EventArgs e)
        {
            sbyte sbPower = 0;
            int iPower = 0;
            uint uigrader = 0;
            long lgrader = 0;
            string message = "";
            string caption_sbyte = "Fejl i power indtastningen";
            bool KraftReady = false;
            bool GradReady = false;

            DialogResult result;

            // Læs http://www.mindsqualls.net/QuickStart_2_0.aspx for mere...

            if (!sbyte.TryParse(textBox1.Text, out sbPower))
            {
                if (int.TryParse(textBox1.Text, out iPower))
                {
                    if (iPower < 0)
                        message = "Motor kraft tallet er for lille! Tallet skal være mellem -128 og 127!";
                    else
                        message = "Motor kraft tallet er for stort! Tallet skal være mellem -128 og 127!";
                }
                else
                    message = "Der skal stå et heltal i 'Motor kraft' feltet! Tallet skal være mellem -128 og 127!";

                MessageBoxButtons buttons = MessageBoxButtons.OK;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption_sbyte, buttons);

                KraftReady = false;
            }
            else
                KraftReady = true;

            if (!uint.TryParse(textBox2.Text, out uigrader))
            {
                if (long.TryParse(textBox2.Text, out lgrader))
                {
                    if (lgrader < 0)
                        message = "Motor grad tallet er for lille! Tallet skal være mellem 0 og 4,294,967,295!";
                    else
                        message = "Motor grad tallet er for stort! Tallet skal være mellem 0 og 4,294,967,295!";
                }
                else
                    message = "Der skal stå et heltal i 'Motor grad' feltet! Tallet skal være mellem 0 og 4,294,967,295!";

                MessageBoxButtons buttons = MessageBoxButtons.OK;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption_sbyte, buttons);

                GradReady = false;
            }
            else
                GradReady = true;

            // Power står i textbox1 og degrees står i textbox2
            //           if (sbyte.Parse(textBox1.Text) < 0 || sbyte.Parse(textBox1.Text) < 0)

            if (KraftReady && GradReady)
                if(motorControlActive)
                {
                    McMotorA.Run(sbyte.Parse(textBox1.Text), uint.Parse(textBox2.Text));
                } else
                {
                    motorA.Run(sbyte.Parse(textBox1.Text), uint.Parse(textBox2.Text));
                }
        }
    }
}
