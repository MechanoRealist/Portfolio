namespace Kørselsbog
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
            this.components = new System.ComponentModel.Container();
            this.fuldNavn_TB = new System.Windows.Forms.TextBox();
            this.nummerplade_TB = new System.Windows.Forms.TextBox();
            this.kilometer_TB = new System.Windows.Forms.TextBox();
            this.startDate_DTP = new System.Windows.Forms.DateTimePicker();
            this.endDate_LB = new System.Windows.Forms.Label();
            this.search_BTN = new System.Windows.Forms.Button();
            this.update_BTN = new System.Windows.Forms.Button();
            this.medarbejderKørselTabel = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.fuldNavn_RB = new System.Windows.Forms.RadioButton();
            this.nummerplade_RB = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.endDate_DTP = new System.Windows.Forms.DateTimePicker();
            this.kilometer_RB = new System.Windows.Forms.RadioButton();
            this.startDate_RB = new System.Windows.Forms.RadioButton();
            this.showAll_RB = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.medarbejderKørselTabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fuldNavn_TB
            // 
            this.fuldNavn_TB.Location = new System.Drawing.Point(16, 50);
            this.fuldNavn_TB.MaxLength = 60;
            this.fuldNavn_TB.Name = "fuldNavn_TB";
            this.fuldNavn_TB.Size = new System.Drawing.Size(221, 20);
            this.fuldNavn_TB.TabIndex = 0;
            // 
            // nummerplade_TB
            // 
            this.nummerplade_TB.Location = new System.Drawing.Point(305, 50);
            this.nummerplade_TB.MaxLength = 20;
            this.nummerplade_TB.Name = "nummerplade_TB";
            this.nummerplade_TB.Size = new System.Drawing.Size(221, 20);
            this.nummerplade_TB.TabIndex = 1;
            // 
            // kilometer_TB
            // 
            this.kilometer_TB.Location = new System.Drawing.Point(305, 99);
            this.kilometer_TB.Name = "kilometer_TB";
            this.kilometer_TB.Size = new System.Drawing.Size(221, 20);
            this.kilometer_TB.TabIndex = 2;
            // 
            // startDate_DTP
            // 
            this.startDate_DTP.Location = new System.Drawing.Point(16, 99);
            this.startDate_DTP.Name = "startDate_DTP";
            this.startDate_DTP.Size = new System.Drawing.Size(221, 20);
            this.startDate_DTP.TabIndex = 3;
            this.startDate_DTP.Value = new System.DateTime(2019, 4, 2, 8, 0, 58, 0);
            this.startDate_DTP.CloseUp += new System.EventHandler(this.startDatePickedCheck);
            // 
            // endDate_LB
            // 
            this.endDate_LB.AutoSize = true;
            this.endDate_LB.Location = new System.Drawing.Point(13, 129);
            this.endDate_LB.Name = "endDate_LB";
            this.endDate_LB.Size = new System.Drawing.Size(51, 13);
            this.endDate_LB.TabIndex = 6;
            this.endDate_LB.Text = "Slut Dato";
            // 
            // search_BTN
            // 
            this.search_BTN.Location = new System.Drawing.Point(305, 141);
            this.search_BTN.Name = "search_BTN";
            this.search_BTN.Size = new System.Drawing.Size(101, 33);
            this.search_BTN.TabIndex = 9;
            this.search_BTN.Text = "Søg i databasen";
            this.search_BTN.UseVisualStyleBackColor = true;
            this.search_BTN.Click += new System.EventHandler(this.search_BTN_Click);
            // 
            // update_BTN
            // 
            this.update_BTN.Location = new System.Drawing.Point(412, 141);
            this.update_BTN.Name = "update_BTN";
            this.update_BTN.Size = new System.Drawing.Size(101, 33);
            this.update_BTN.TabIndex = 9;
            this.update_BTN.Text = "Gem ændringer";
            this.update_BTN.UseVisualStyleBackColor = true;
            this.update_BTN.Click += new System.EventHandler(this.update_BTN_Click);
            // 
            // medarbejderKørselTabel
            // 
            this.medarbejderKørselTabel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.medarbejderKørselTabel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.medarbejderKørselTabel.Location = new System.Drawing.Point(12, 212);
            this.medarbejderKørselTabel.Name = "medarbejderKørselTabel";
            this.medarbejderKørselTabel.Size = new System.Drawing.Size(554, 316);
            this.medarbejderKørselTabel.TabIndex = 10;
            // 
            // fuldNavn_RB
            // 
            this.fuldNavn_RB.AutoSize = true;
            this.fuldNavn_RB.Location = new System.Drawing.Point(16, 27);
            this.fuldNavn_RB.Name = "fuldNavn_RB";
            this.fuldNavn_RB.Size = new System.Drawing.Size(80, 17);
            this.fuldNavn_RB.TabIndex = 11;
            this.fuldNavn_RB.Text = "Fulde Navn";
            this.fuldNavn_RB.UseVisualStyleBackColor = true;
            // 
            // nummerplade_RB
            // 
            this.nummerplade_RB.AutoSize = true;
            this.nummerplade_RB.Location = new System.Drawing.Point(305, 27);
            this.nummerplade_RB.Name = "nummerplade_RB";
            this.nummerplade_RB.Size = new System.Drawing.Size(90, 17);
            this.nummerplade_RB.TabIndex = 11;
            this.nummerplade_RB.Text = "Nummerplade";
            this.nummerplade_RB.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.endDate_DTP);
            this.panel1.Controls.Add(this.kilometer_RB);
            this.panel1.Controls.Add(this.startDate_RB);
            this.panel1.Controls.Add(this.showAll_RB);
            this.panel1.Controls.Add(this.nummerplade_RB);
            this.panel1.Controls.Add(this.update_BTN);
            this.panel1.Controls.Add(this.fuldNavn_RB);
            this.panel1.Controls.Add(this.search_BTN);
            this.panel1.Controls.Add(this.endDate_LB);
            this.panel1.Controls.Add(this.startDate_DTP);
            this.panel1.Controls.Add(this.kilometer_TB);
            this.panel1.Controls.Add(this.nummerplade_TB);
            this.panel1.Controls.Add(this.fuldNavn_TB);
            this.panel1.Location = new System.Drawing.Point(14, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(552, 192);
            this.panel1.TabIndex = 12;
            // 
            // endDate_DTP
            // 
            this.endDate_DTP.Location = new System.Drawing.Point(16, 145);
            this.endDate_DTP.Name = "endDate_DTP";
            this.endDate_DTP.Size = new System.Drawing.Size(221, 20);
            this.endDate_DTP.TabIndex = 14;
            this.endDate_DTP.Value = new System.DateTime(2019, 4, 2, 8, 1, 14, 0);
            this.endDate_DTP.CloseUp += new System.EventHandler(this.endDatePickedCheck);
            // 
            // kilometer_RB
            // 
            this.kilometer_RB.AutoSize = true;
            this.kilometer_RB.Location = new System.Drawing.Point(305, 76);
            this.kilometer_RB.Name = "kilometer_RB";
            this.kilometer_RB.Size = new System.Drawing.Size(162, 17);
            this.kilometer_RB.TabIndex = 13;
            this.kilometer_RB.Text = "Kørt mere end antal kilometer";
            this.kilometer_RB.UseVisualStyleBackColor = true;
            // 
            // startDate_RB
            // 
            this.startDate_RB.AutoSize = true;
            this.startDate_RB.Location = new System.Drawing.Point(16, 76);
            this.startDate_RB.Name = "startDate_RB";
            this.startDate_RB.Size = new System.Drawing.Size(73, 17);
            this.startDate_RB.TabIndex = 12;
            this.startDate_RB.Text = "Start Dato";
            this.startDate_RB.UseVisualStyleBackColor = true;
            // 
            // showAll_RB
            // 
            this.showAll_RB.AutoSize = true;
            this.showAll_RB.Checked = true;
            this.showAll_RB.Location = new System.Drawing.Point(16, 4);
            this.showAll_RB.Name = "showAll_RB";
            this.showAll_RB.Size = new System.Drawing.Size(53, 17);
            this.showAll_RB.TabIndex = 12;
            this.showAll_RB.TabStop = true;
            this.showAll_RB.Text = "Vis alt";
            this.showAll_RB.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 540);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.medarbejderKørselTabel);
            this.Name = "Form1";
            this.Text = "Kørselsbog";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.medarbejderKørselTabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox fuldNavn_TB;
        private System.Windows.Forms.TextBox nummerplade_TB;
        private System.Windows.Forms.TextBox kilometer_TB;
        private System.Windows.Forms.DateTimePicker startDate_DTP;
        private System.Windows.Forms.Label endDate_LB;
        private System.Windows.Forms.Button search_BTN;
        private System.Windows.Forms.Button update_BTN;
        private System.Windows.Forms.DataGridView medarbejderKørselTabel;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.RadioButton fuldNavn_RB;
        private System.Windows.Forms.RadioButton nummerplade_RB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker endDate_DTP;
        private System.Windows.Forms.RadioButton kilometer_RB;
        private System.Windows.Forms.RadioButton showAll_RB;
        private System.Windows.Forms.RadioButton startDate_RB;
    }
}

