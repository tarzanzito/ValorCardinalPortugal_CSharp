namespace WindowsFormsApp1
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
            this.buttonConvert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.textBoxDescr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMaxDec = new System.Windows.Forms.TextBox();
            this.textBoxMaxInt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(298, 12);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonConvert.Size = new System.Drawing.Size(70, 24);
            this.buttonConvert.TabIndex = 1;
            this.buttonConvert.Text = "Converte";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Valor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Extenso:";
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(69, 15);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(223, 20);
            this.textBoxValue.TabIndex = 0;
            this.textBoxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxValue.Enter += new System.EventHandler(this.textBoxValue_Enter);
            // 
            // textBoxDescr
            // 
            this.textBoxDescr.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxDescr.Location = new System.Drawing.Point(66, 50);
            this.textBoxDescr.Multiline = true;
            this.textBoxDescr.Name = "textBoxDescr";
            this.textBoxDescr.ReadOnly = true;
            this.textBoxDescr.Size = new System.Drawing.Size(577, 107);
            this.textBoxDescr.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "   Max int:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "* Max dec:";
            // 
            // textBoxMaxDec
            // 
            this.textBoxMaxDec.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxMaxDec.Location = new System.Drawing.Point(70, 45);
            this.textBoxMaxDec.Name = "textBoxMaxDec";
            this.textBoxMaxDec.ReadOnly = true;
            this.textBoxMaxDec.Size = new System.Drawing.Size(187, 20);
            this.textBoxMaxDec.TabIndex = 6;
            this.textBoxMaxDec.Text = "99999999999999999999999999.99";
            this.textBoxMaxDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxMaxInt
            // 
            this.textBoxMaxInt.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxMaxInt.Location = new System.Drawing.Point(70, 19);
            this.textBoxMaxInt.Name = "textBoxMaxInt";
            this.textBoxMaxInt.ReadOnly = true;
            this.textBoxMaxInt.Size = new System.Drawing.Size(187, 20);
            this.textBoxMaxInt.TabIndex = 7;
            this.textBoxMaxInt.Text = "79228162514264337593543950335";
            this.textBoxMaxInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Info;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxMaxInt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxMaxDec);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(365, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 115);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "C# - limites da vairiavel do tipo \'decimal\'";
            this.groupBox1.Visible = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(18, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(239, 35);
            this.label5.TabIndex = 8;
            this.label5.Text = "* acima deste valor existe arredondamentos da parte docimal";
            // 
            // buttonInfo
            // 
            this.buttonInfo.Location = new System.Drawing.Point(374, 12);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(22, 23);
            this.buttonInfo.TabIndex = 9;
            this.buttonInfo.Text = "I";
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.buttonConvert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 168);
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxDescr);
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonConvert);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.TextBox textBoxDescr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMaxDec;
        private System.Windows.Forms.TextBox textBoxMaxInt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonInfo;
    }
}

