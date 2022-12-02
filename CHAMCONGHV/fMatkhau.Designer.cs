namespace CHAMCONGHV
{
    partial class fMatkhau
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
            this.txbmkcu = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnDongY = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbmkm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbKPMK = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txbmkcu
            // 
            this.txbmkcu.Location = new System.Drawing.Point(108, 53);
            this.txbmkcu.Name = "txbmkcu";
            this.txbmkcu.PasswordChar = '*';
            this.txbmkcu.Size = new System.Drawing.Size(275, 20);
            this.txbmkcu.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(200, 113);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Kết thúc";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDongY
            // 
            this.btnDongY.Location = new System.Drawing.Point(118, 113);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(75, 23);
            this.btnDongY.TabIndex = 9;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.UseVisualStyleBackColor = true;
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mật khẩu cũ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Khoa phòng:";
            // 
            // txbmkm
            // 
            this.txbmkm.Location = new System.Drawing.Point(108, 79);
            this.txbmkm.Name = "txbmkm";
            this.txbmkm.PasswordChar = '*';
            this.txbmkm.Size = new System.Drawing.Size(275, 20);
            this.txbmkm.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mật khẩu mới:";
            // 
            // txbKPMK
            // 
            this.txbKPMK.Enabled = false;
            this.txbKPMK.Location = new System.Drawing.Point(108, 27);
            this.txbKPMK.Name = "txbKPMK";
            this.txbKPMK.Size = new System.Drawing.Size(275, 20);
            this.txbKPMK.TabIndex = 12;
            // 
            // fMatkhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 139);
            this.Controls.Add(this.txbKPMK);
            this.Controls.Add(this.txbmkm);
            this.Controls.Add(this.txbmkcu);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnDongY);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "fMatkhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý người dùng";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbmkcu;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnDongY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbmkm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbKPMK;
    }
}