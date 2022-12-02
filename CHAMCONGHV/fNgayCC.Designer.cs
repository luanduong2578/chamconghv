namespace CHAMCONGHV
{
    partial class fNgayCC
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
            this.dtpkNgayCC = new System.Windows.Forms.DateTimePicker();
            this.cbbKP = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDongY = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txbmk = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày làm việc:";
            // 
            // dtpkNgayCC
            // 
            this.dtpkNgayCC.CustomFormat = "dd/MM/yyyy";
            this.dtpkNgayCC.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkNgayCC.Location = new System.Drawing.Point(98, 11);
            this.dtpkNgayCC.Name = "dtpkNgayCC";
            this.dtpkNgayCC.Size = new System.Drawing.Size(86, 20);
            this.dtpkNgayCC.TabIndex = 1;
            // 
            // cbbKP
            // 
            this.cbbKP.FormattingEnabled = true;
            this.cbbKP.Location = new System.Drawing.Point(98, 38);
            this.cbbKP.Name = "cbbKP";
            this.cbbKP.Size = new System.Drawing.Size(275, 21);
            this.cbbKP.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chọn khoa:";
            // 
            // btnDongY
            // 
            this.btnDongY.Location = new System.Drawing.Point(109, 99);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(75, 23);
            this.btnDongY.TabIndex = 3;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.UseVisualStyleBackColor = true;
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(191, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Kết thúc";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txbmk
            // 
            this.txbmk.Location = new System.Drawing.Point(98, 64);
            this.txbmk.Name = "txbmk";
            this.txbmk.PasswordChar = '*';
            this.txbmk.Size = new System.Drawing.Size(275, 20);
            this.txbmk.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mật khẩu:";
            // 
            // fNgayCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 134);
            this.Controls.Add(this.txbmk);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnDongY);
            this.Controls.Add(this.cbbKP);
            this.Controls.Add(this.dtpkNgayCC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "fNgayCC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Điểm danh Học viên";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpkNgayCC;
        private System.Windows.Forms.ComboBox cbbKP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDongY;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txbmk;
        private System.Windows.Forms.Label label3;
    }
}

