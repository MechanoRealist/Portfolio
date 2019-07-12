namespace Bank_Project
{
    partial class KontoMenu
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
            this.lukKnap = new System.Windows.Forms.Button();
            this.hævKnap = new System.Windows.Forms.Button();
            this.logudKnap = new System.Windows.Forms.Button();
            this.indsætKnap = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lukKnap
            // 
            this.lukKnap.BackColor = System.Drawing.Color.Red;
            this.lukKnap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.lukKnap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lukKnap.Location = new System.Drawing.Point(422, 2);
            this.lukKnap.Name = "lukKnap";
            this.lukKnap.Size = new System.Drawing.Size(25, 24);
            this.lukKnap.TabIndex = 6;
            this.lukKnap.Text = "X";
            this.lukKnap.UseVisualStyleBackColor = false;
            this.lukKnap.Click += new System.EventHandler(this.LukKnap_Click);
            // 
            // hævKnap
            // 
            this.hævKnap.Location = new System.Drawing.Point(12, 69);
            this.hævKnap.Name = "hævKnap";
            this.hævKnap.Size = new System.Drawing.Size(146, 71);
            this.hævKnap.TabIndex = 7;
            this.hævKnap.Text = "Withdraw";
            this.hævKnap.UseVisualStyleBackColor = true;
            this.hævKnap.Click += new System.EventHandler(this.HævKnap_Click);
            // 
            // logudKnap
            // 
            this.logudKnap.Location = new System.Drawing.Point(316, 107);
            this.logudKnap.Name = "logudKnap";
            this.logudKnap.Size = new System.Drawing.Size(119, 33);
            this.logudKnap.TabIndex = 7;
            this.logudKnap.Text = "Logout";
            this.logudKnap.UseVisualStyleBackColor = true;
            this.logudKnap.Click += new System.EventHandler(this.LogudKnap_Click);
            // 
            // indsætKnap
            // 
            this.indsætKnap.Location = new System.Drawing.Point(164, 69);
            this.indsætKnap.Name = "indsætKnap";
            this.indsætKnap.Size = new System.Drawing.Size(146, 71);
            this.indsætKnap.TabIndex = 7;
            this.indsætKnap.Text = "Insert";
            this.indsætKnap.UseVisualStyleBackColor = true;
            this.indsætKnap.Click += new System.EventHandler(this.IndsætKnap_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "User Menu";
            // 
            // KontoMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 179);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.indsætKnap);
            this.Controls.Add(this.logudKnap);
            this.Controls.Add(this.hævKnap);
            this.Controls.Add(this.lukKnap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KontoMenu";
            this.Text = "KontoMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button lukKnap;
        private System.Windows.Forms.Button hævKnap;
        private System.Windows.Forms.Button logudKnap;
        private System.Windows.Forms.Button indsætKnap;
        private System.Windows.Forms.Label label1;
    }
}