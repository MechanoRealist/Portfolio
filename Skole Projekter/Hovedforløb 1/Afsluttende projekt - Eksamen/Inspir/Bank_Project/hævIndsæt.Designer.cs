namespace Bank_Project
{
    partial class hævIndsæt
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
            this.label1 = new System.Windows.Forms.Label();
            this.saldo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.beløbBox = new System.Windows.Forms.TextBox();
            this.beløbKnap = new System.Windows.Forms.Button();
            this.lukKnap = new System.Windows.Forms.Button();
            this.windowName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saldo:";
            // 
            // saldo
            // 
            this.saldo.AutoSize = true;
            this.saldo.Location = new System.Drawing.Point(68, 46);
            this.saldo.Name = "saldo";
            this.saldo.Size = new System.Drawing.Size(60, 17);
            this.saldo.TabIndex = 1;
            this.saldo.Text = "<Saldo>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Amount:";
            // 
            // beløbBox
            // 
            this.beløbBox.Location = new System.Drawing.Point(71, 83);
            this.beløbBox.Name = "beløbBox";
            this.beløbBox.Size = new System.Drawing.Size(114, 22);
            this.beløbBox.TabIndex = 3;
            // 
            // beløbKnap
            // 
            this.beløbKnap.Location = new System.Drawing.Point(71, 146);
            this.beløbKnap.Name = "beløbKnap";
            this.beløbKnap.Size = new System.Drawing.Size(114, 48);
            this.beløbKnap.TabIndex = 4;
            this.beløbKnap.Text = "<BeløbKnap>";
            this.beløbKnap.UseVisualStyleBackColor = true;
            this.beløbKnap.Click += new System.EventHandler(this.BeløbKnap_Click);
            // 
            // lukKnap
            // 
            this.lukKnap.BackColor = System.Drawing.Color.Red;
            this.lukKnap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.lukKnap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lukKnap.Location = new System.Drawing.Point(205, 4);
            this.lukKnap.Name = "lukKnap";
            this.lukKnap.Size = new System.Drawing.Size(20, 23);
            this.lukKnap.TabIndex = 5;
            this.lukKnap.Text = "X";
            this.lukKnap.UseVisualStyleBackColor = false;
            this.lukKnap.Click += new System.EventHandler(this.LukKnap_Click);
            // 
            // windowName
            // 
            this.windowName.AutoSize = true;
            this.windowName.Location = new System.Drawing.Point(68, 10);
            this.windowName.Name = "windowName";
            this.windowName.Size = new System.Drawing.Size(110, 17);
            this.windowName.TabIndex = 6;
            this.windowName.Text = "<WindowName>";
            // 
            // hævIndsæt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(237, 216);
            this.Controls.Add(this.windowName);
            this.Controls.Add(this.lukKnap);
            this.Controls.Add(this.beløbKnap);
            this.Controls.Add(this.beløbBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.saldo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "hævIndsæt";
            this.Text = "KontoHæv";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label saldo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox beløbBox;
        private System.Windows.Forms.Button beløbKnap;
        private System.Windows.Forms.Button lukKnap;
        private System.Windows.Forms.Label windowName;
    }
}