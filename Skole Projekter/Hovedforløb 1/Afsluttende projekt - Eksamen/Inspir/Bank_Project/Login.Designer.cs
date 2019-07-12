namespace Bank_Project
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            this.idBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.passBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loginKnap = new System.Windows.Forms.Button();
            this.lukKnap = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(100, 38);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(172, 22);
            this.idBox.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // passBox
            // 
            this.passBox.Location = new System.Drawing.Point(100, 81);
            this.passBox.Name = "passBox";
            this.passBox.Size = new System.Drawing.Size(172, 22);
            this.passBox.TabIndex = 2;
            this.passBox.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Account Nr:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password:";
            // 
            // loginKnap
            // 
            this.loginKnap.Location = new System.Drawing.Point(48, 116);
            this.loginKnap.Name = "loginKnap";
            this.loginKnap.Size = new System.Drawing.Size(178, 64);
            this.loginKnap.TabIndex = 5;
            this.loginKnap.Text = "Login";
            this.loginKnap.UseVisualStyleBackColor = true;
            this.loginKnap.Click += new System.EventHandler(this.LoginKnap_Click);
            // 
            // lukKnap
            // 
            this.lukKnap.BackColor = System.Drawing.Color.Red;
            this.lukKnap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.lukKnap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lukKnap.Location = new System.Drawing.Point(256, 2);
            this.lukKnap.Name = "lukKnap";
            this.lukKnap.Size = new System.Drawing.Size(26, 26);
            this.lukKnap.TabIndex = 6;
            this.lukKnap.Text = "X";
            this.lukKnap.UseVisualStyleBackColor = false;
            this.lukKnap.Click += new System.EventHandler(this.LukKnap_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Login";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(284, 192);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lukKnap);
            this.Controls.Add(this.loginKnap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passBox);
            this.Controls.Add(this.idBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox idBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox passBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button loginKnap;
        private System.Windows.Forms.Button lukKnap;
        private System.Windows.Forms.Label label3;
    }
}

