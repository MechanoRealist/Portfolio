namespace ArrowKey_Arrows_Test
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
            this.LB_UP = new System.Windows.Forms.Label();
            this.LB_RIGHT = new System.Windows.Forms.Label();
            this.LB_DOWN = new System.Windows.Forms.Label();
            this.LB_LEFT = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LB_UP
            // 
            this.LB_UP.AutoSize = true;
            this.LB_UP.Location = new System.Drawing.Point(87, 22);
            this.LB_UP.Name = "LB_UP";
            this.LB_UP.Size = new System.Drawing.Size(27, 17);
            this.LB_UP.TabIndex = 0;
            this.LB_UP.Text = "UP";
            this.LB_UP.Visible = false;
            this.LB_UP.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // LB_RIGHT
            // 
            this.LB_RIGHT.AutoSize = true;
            this.LB_RIGHT.Location = new System.Drawing.Point(134, 80);
            this.LB_RIGHT.Name = "LB_RIGHT";
            this.LB_RIGHT.Size = new System.Drawing.Size(51, 17);
            this.LB_RIGHT.TabIndex = 1;
            this.LB_RIGHT.Text = "RIGHT";
            this.LB_RIGHT.Visible = false;
            this.LB_RIGHT.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // LB_DOWN
            // 
            this.LB_DOWN.AutoSize = true;
            this.LB_DOWN.Location = new System.Drawing.Point(74, 123);
            this.LB_DOWN.Name = "LB_DOWN";
            this.LB_DOWN.Size = new System.Drawing.Size(52, 17);
            this.LB_DOWN.TabIndex = 2;
            this.LB_DOWN.Text = "DOWN";
            this.LB_DOWN.Visible = false;
            this.LB_DOWN.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // LB_LEFT
            // 
            this.LB_LEFT.AutoSize = true;
            this.LB_LEFT.Location = new System.Drawing.Point(23, 80);
            this.LB_LEFT.Name = "LB_LEFT";
            this.LB_LEFT.Size = new System.Drawing.Size(42, 17);
            this.LB_LEFT.TabIndex = 3;
            this.LB_LEFT.Text = "LEFT";
            this.LB_LEFT.Visible = false;
            this.LB_LEFT.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(290, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 140);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(290, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 5;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(164, 18);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(110, 21);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(62, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 41);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 330);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LB_LEFT);
            this.Controls.Add(this.LB_DOWN);
            this.Controls.Add(this.LB_RIGHT);
            this.Controls.Add(this.LB_UP);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "TEST1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LB_UP;
        private System.Windows.Forms.Label LB_RIGHT;
        private System.Windows.Forms.Label LB_DOWN;
        private System.Windows.Forms.Label LB_LEFT;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button1;
    }
}

