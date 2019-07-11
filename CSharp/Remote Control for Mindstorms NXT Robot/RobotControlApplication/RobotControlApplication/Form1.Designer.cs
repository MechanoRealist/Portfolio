namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_GO = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_left = new System.Windows.Forms.Button();
            this.button_right = new System.Windows.Forms.Button();
            this.button_forward = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.COMportInput = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.RB_Bluetooth = new System.Windows.Forms.RadioButton();
            this.RB_USB = new System.Windows.Forms.RadioButton();
            this.ConnectedText = new System.Windows.Forms.Label();
            this.RB_DirectCommand = new System.Windows.Forms.RadioButton();
            this.RB_McRXE = new System.Windows.Forms.RadioButton();
            this.ConnectionTypeGroup = new System.Windows.Forms.GroupBox();
            this.CommandTypeGroup = new System.Windows.Forms.GroupBox();
            this.TB_Speed = new System.Windows.Forms.TrackBar();
            this.LB_Speed = new System.Windows.Forms.Label();
            this.arrowKeyDisplay = new System.Windows.Forms.PictureBox();
            this.Piltast = new System.Windows.Forms.Label();
            this.ConnectionTypeGroup.SuspendLayout();
            this.CommandTypeGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowKeyDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(188, 262);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.MaxLength = 4;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(119, 22);
            this.textBox1.TabIndex = 4;
            this.textBox1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_GO
            // 
            this.button_GO.Location = new System.Drawing.Point(95, 326);
            this.button_GO.Margin = new System.Windows.Forms.Padding(4);
            this.button_GO.Name = "button_GO";
            this.button_GO.Size = new System.Drawing.Size(292, 28);
            this.button_GO.TabIndex = 6;
            this.button_GO.Text = "GO!!!";
            this.button_GO.UseVisualStyleBackColor = true;
            this.button_GO.Click += new System.EventHandler(this.button_GO_Click);
            this.button_GO.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 265);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Motor kraft";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 297);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Motor grader";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(188, 294);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(119, 22);
            this.textBox2.TabIndex = 5;
            this.textBox2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(161, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "TEC LEGO-golf";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button_left
            // 
            this.button_left.Location = new System.Drawing.Point(45, 110);
            this.button_left.Margin = new System.Windows.Forms.Padding(4);
            this.button_left.Name = "button_left";
            this.button_left.Size = new System.Drawing.Size(133, 28);
            this.button_left.TabIndex = 1;
            this.button_left.Text = "Venstre";
            this.button_left.UseVisualStyleBackColor = true;
            this.button_left.Click += new System.EventHandler(this.button_left_Click);
            this.button_left.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_right
            // 
            this.button_right.Location = new System.Drawing.Point(350, 110);
            this.button_right.Margin = new System.Windows.Forms.Padding(4);
            this.button_right.Name = "button_right";
            this.button_right.Size = new System.Drawing.Size(133, 28);
            this.button_right.TabIndex = 2;
            this.button_right.Text = "Højre";
            this.button_right.UseVisualStyleBackColor = true;
            this.button_right.Click += new System.EventHandler(this.button_right_Click);
            this.button_right.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_forward
            // 
            this.button_forward.Location = new System.Drawing.Point(188, 74);
            this.button_forward.Margin = new System.Windows.Forms.Padding(4);
            this.button_forward.Name = "button_forward";
            this.button_forward.Size = new System.Drawing.Size(133, 28);
            this.button_forward.TabIndex = 0;
            this.button_forward.Text = "Frem";
            this.button_forward.UseVisualStyleBackColor = true;
            this.button_forward.Click += new System.EventHandler(this.button_forward_Click);
            this.button_forward.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_back
            // 
            this.button_back.Location = new System.Drawing.Point(188, 149);
            this.button_back.Margin = new System.Windows.Forms.Padding(4);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(133, 28);
            this.button_back.TabIndex = 3;
            this.button_back.Text = "Tilbage";
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            this.button_back.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(315, 265);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "(-128 - 127)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(315, 297);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "(0 - 4.294.967.295)";
            // 
            // COMportInput
            // 
            this.COMportInput.Location = new System.Drawing.Point(438, 33);
            this.COMportInput.Name = "COMportInput";
            this.COMportInput.Size = new System.Drawing.Size(62, 22);
            this.COMportInput.TabIndex = 12;
            this.COMportInput.Enter += new System.EventHandler(this.COMportInput_Enter);
            this.COMportInput.Leave += new System.EventHandler(this.COMportInput_Leave);
            this.COMportInput.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(350, 30);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(82, 25);
            this.button_connect.TabIndex = 13;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            this.button_connect.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(425, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "COM Port #";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 17);
            this.label7.TabIndex = 15;
            // 
            // RB_Bluetooth
            // 
            this.RB_Bluetooth.AutoSize = true;
            this.RB_Bluetooth.Checked = true;
            this.RB_Bluetooth.Location = new System.Drawing.Point(12, 23);
            this.RB_Bluetooth.Name = "RB_Bluetooth";
            this.RB_Bluetooth.Size = new System.Drawing.Size(89, 21);
            this.RB_Bluetooth.TabIndex = 17;
            this.RB_Bluetooth.TabStop = true;
            this.RB_Bluetooth.Text = "Bluetooth";
            this.RB_Bluetooth.UseVisualStyleBackColor = true;
            this.RB_Bluetooth.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // RB_USB
            // 
            this.RB_USB.AutoSize = true;
            this.RB_USB.Location = new System.Drawing.Point(12, 50);
            this.RB_USB.Name = "RB_USB";
            this.RB_USB.Size = new System.Drawing.Size(57, 21);
            this.RB_USB.TabIndex = 18;
            this.RB_USB.Text = "USB";
            this.RB_USB.UseVisualStyleBackColor = true;
            this.RB_USB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // ConnectedText
            // 
            this.ConnectedText.AutoSize = true;
            this.ConnectedText.Location = new System.Drawing.Point(425, 58);
            this.ConnectedText.Name = "ConnectedText";
            this.ConnectedText.Size = new System.Drawing.Size(79, 17);
            this.ConnectedText.TabIndex = 19;
            this.ConnectedText.Text = "Connected!";
            this.ConnectedText.Visible = false;
            // 
            // RB_DirectCommand
            // 
            this.RB_DirectCommand.AutoSize = true;
            this.RB_DirectCommand.Location = new System.Drawing.Point(14, 15);
            this.RB_DirectCommand.Name = "RB_DirectCommand";
            this.RB_DirectCommand.Size = new System.Drawing.Size(140, 21);
            this.RB_DirectCommand.TabIndex = 20;
            this.RB_DirectCommand.Text = "Direct Commands";
            this.RB_DirectCommand.UseVisualStyleBackColor = true;
            this.RB_DirectCommand.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // RB_McRXE
            // 
            this.RB_McRXE.AutoSize = true;
            this.RB_McRXE.Checked = true;
            this.RB_McRXE.Location = new System.Drawing.Point(166, 15);
            this.RB_McRXE.Name = "RB_McRXE";
            this.RB_McRXE.Size = new System.Drawing.Size(146, 21);
            this.RB_McRXE.TabIndex = 21;
            this.RB_McRXE.TabStop = true;
            this.RB_McRXE.Text = "Motor Control RXE";
            this.RB_McRXE.UseVisualStyleBackColor = true;
            this.RB_McRXE.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // ConnectionTypeGroup
            // 
            this.ConnectionTypeGroup.Controls.Add(this.label7);
            this.ConnectionTypeGroup.Controls.Add(this.RB_Bluetooth);
            this.ConnectionTypeGroup.Controls.Add(this.RB_USB);
            this.ConnectionTypeGroup.Location = new System.Drawing.Point(16, 11);
            this.ConnectionTypeGroup.Name = "ConnectionTypeGroup";
            this.ConnectionTypeGroup.Size = new System.Drawing.Size(123, 91);
            this.ConnectionTypeGroup.TabIndex = 22;
            this.ConnectionTypeGroup.TabStop = false;
            // 
            // CommandTypeGroup
            // 
            this.CommandTypeGroup.BackColor = System.Drawing.SystemColors.Control;
            this.CommandTypeGroup.Controls.Add(this.RB_DirectCommand);
            this.CommandTypeGroup.Controls.Add(this.RB_McRXE);
            this.CommandTypeGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CommandTypeGroup.Location = new System.Drawing.Point(81, 361);
            this.CommandTypeGroup.Name = "CommandTypeGroup";
            this.CommandTypeGroup.Size = new System.Drawing.Size(318, 45);
            this.CommandTypeGroup.TabIndex = 23;
            this.CommandTypeGroup.TabStop = false;
            // 
            // TB_Speed
            // 
            this.TB_Speed.Location = new System.Drawing.Point(45, 199);
            this.TB_Speed.Maximum = 100;
            this.TB_Speed.Name = "TB_Speed";
            this.TB_Speed.Size = new System.Drawing.Size(420, 56);
            this.TB_Speed.SmallChange = 0;
            this.TB_Speed.TabIndex = 24;
            this.TB_Speed.TickFrequency = 10;
            this.TB_Speed.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.TB_Speed.Value = 50;
            this.TB_Speed.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // LB_Speed
            // 
            this.LB_Speed.AutoSize = true;
            this.LB_Speed.Location = new System.Drawing.Point(51, 179);
            this.LB_Speed.Name = "LB_Speed";
            this.LB_Speed.Size = new System.Drawing.Size(97, 17);
            this.LB_Speed.TabIndex = 25;
            this.LB_Speed.Text = "Speed: #Error";
            // 
            // arrowKeyDisplay
            // 
            this.arrowKeyDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.arrowKeyDisplay.Location = new System.Drawing.Point(462, 257);
            this.arrowKeyDisplay.Name = "arrowKeyDisplay";
            this.arrowKeyDisplay.Size = new System.Drawing.Size(140, 140);
            this.arrowKeyDisplay.TabIndex = 26;
            this.arrowKeyDisplay.TabStop = false;
            this.arrowKeyDisplay.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // Piltast
            // 
            this.Piltast.AutoSize = true;
            this.Piltast.Location = new System.Drawing.Point(486, 237);
            this.Piltast.Name = "Piltast";
            this.Piltast.Size = new System.Drawing.Size(92, 17);
            this.Piltast.TabIndex = 27;
            this.Piltast.Text = "Piltast styring";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 425);
            this.Controls.Add(this.Piltast);
            this.Controls.Add(this.arrowKeyDisplay);
            this.Controls.Add(this.LB_Speed);
            this.Controls.Add(this.TB_Speed);
            this.Controls.Add(this.CommandTypeGroup);
            this.Controls.Add(this.ConnectionTypeGroup);
            this.Controls.Add(this.ConnectedText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.COMportInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_forward);
            this.Controls.Add(this.button_right);
            this.Controls.Add(this.button_left);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_GO);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "LEGO golf";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            this.ConnectionTypeGroup.ResumeLayout(false);
            this.ConnectionTypeGroup.PerformLayout();
            this.CommandTypeGroup.ResumeLayout(false);
            this.CommandTypeGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowKeyDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_GO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_left;
        private System.Windows.Forms.Button button_right;
        private System.Windows.Forms.Button button_forward;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox COMportInput;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton RB_Bluetooth;
        private System.Windows.Forms.RadioButton RB_USB;
        private System.Windows.Forms.Label ConnectedText;
        private System.Windows.Forms.RadioButton RB_DirectCommand;
        private System.Windows.Forms.RadioButton RB_McRXE;
        private System.Windows.Forms.GroupBox ConnectionTypeGroup;
        private System.Windows.Forms.GroupBox CommandTypeGroup;
        private System.Windows.Forms.TrackBar TB_Speed;
        private System.Windows.Forms.Label LB_Speed;
        private System.Windows.Forms.PictureBox arrowKeyDisplay;
        private System.Windows.Forms.Label Piltast;
    }
}

