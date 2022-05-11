namespace ClientPlayer
{
    partial class PlayGame
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
            this.lbThoiGian = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbLuot = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btBatDau = new System.Windows.Forms.Button();
            this.btLac = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNut = new System.Windows.Forms.TextBox();
            this.tbDiem = new System.Windows.Forms.TextBox();
            this.tbNguoiChoi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTongNut = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbnguoi = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbThoiGian
            // 
            this.lbThoiGian.AutoSize = true;
            this.lbThoiGian.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThoiGian.ForeColor = System.Drawing.Color.Red;
            this.lbThoiGian.Location = new System.Drawing.Point(46, 64);
            this.lbThoiGian.Name = "lbThoiGian";
            this.lbThoiGian.Size = new System.Drawing.Size(0, 24);
            this.lbThoiGian.TabIndex = 34;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(181, 325);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 33;
            // 
            // tbUser
            // 
            this.tbUser.ForeColor = System.Drawing.Color.Black;
            this.tbUser.Location = new System.Drawing.Point(39, 30);
            this.tbUser.Name = "tbUser";
            this.tbUser.ReadOnly = true;
            this.tbUser.Size = new System.Drawing.Size(74, 20);
            this.tbUser.TabIndex = 32;
            this.tbUser.TextChanged += new System.EventHandler(this.tbUser_TextChanged);
            // 
            // tbLuot
            // 
            this.tbLuot.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLuot.Location = new System.Drawing.Point(359, 26);
            this.tbLuot.Multiline = true;
            this.tbLuot.Name = "tbLuot";
            this.tbLuot.ReadOnly = true;
            this.tbLuot.Size = new System.Drawing.Size(60, 46);
            this.tbLuot.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(366, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "Lượt";
            // 
            // btBatDau
            // 
            this.btBatDau.Location = new System.Drawing.Point(148, 296);
            this.btBatDau.Name = "btBatDau";
            this.btBatDau.Size = new System.Drawing.Size(75, 23);
            this.btBatDau.TabIndex = 29;
            this.btBatDau.Text = "Bắt đầu";
            this.btBatDau.UseVisualStyleBackColor = true;
            this.btBatDau.EnabledChanged += new System.EventHandler(this.btBatDau_EnabledChanged);
            this.btBatDau.Click += new System.EventHandler(this.btBatDau_Click);
            // 
            // btLac
            // 
            this.btLac.Location = new System.Drawing.Point(254, 296);
            this.btLac.Name = "btLac";
            this.btLac.Size = new System.Drawing.Size(75, 23);
            this.btLac.TabIndex = 28;
            this.btLac.Text = "Lắc";
            this.btLac.UseVisualStyleBackColor = true;
            this.btLac.Click += new System.EventHandler(this.btLac_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(395, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Nút";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(345, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Điểm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Người chơi";
            // 
            // tbNut
            // 
            this.tbNut.Location = new System.Drawing.Point(396, 149);
            this.tbNut.Multiline = true;
            this.tbNut.Name = "tbNut";
            this.tbNut.ReadOnly = true;
            this.tbNut.Size = new System.Drawing.Size(30, 129);
            this.tbNut.TabIndex = 24;
            // 
            // tbDiem
            // 
            this.tbDiem.Location = new System.Drawing.Point(348, 149);
            this.tbDiem.Multiline = true;
            this.tbDiem.Name = "tbDiem";
            this.tbDiem.ReadOnly = true;
            this.tbDiem.Size = new System.Drawing.Size(31, 129);
            this.tbDiem.TabIndex = 23;
            // 
            // tbNguoiChoi
            // 
            this.tbNguoiChoi.Location = new System.Drawing.Point(68, 149);
            this.tbNguoiChoi.Multiline = true;
            this.tbNguoiChoi.Name = "tbNguoiChoi";
            this.tbNguoiChoi.ReadOnly = true;
            this.tbNguoiChoi.Size = new System.Drawing.Size(274, 129);
            this.tbNguoiChoi.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Tổng nút";
            // 
            // tbTongNut
            // 
            this.tbTongNut.Location = new System.Drawing.Point(196, 112);
            this.tbTongNut.Name = "tbTongNut";
            this.tbTongNut.ReadOnly = true;
            this.tbTongNut.Size = new System.Drawing.Size(117, 20);
            this.tbTongNut.TabIndex = 20;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(253, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 103);
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(147, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 103);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // lbnguoi
            // 
            this.lbnguoi.AutoSize = true;
            this.lbnguoi.Location = new System.Drawing.Point(133, 130);
            this.lbnguoi.Name = "lbnguoi";
            this.lbnguoi.Size = new System.Drawing.Size(0, 13);
            this.lbnguoi.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Người chơi";
            // 
            // PlayGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 324);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbnguoi);
            this.Controls.Add(this.lbThoiGian);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.tbLuot);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btBatDau);
            this.Controls.Add(this.btLac);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNut);
            this.Controls.Add(this.tbDiem);
            this.Controls.Add(this.tbNguoiChoi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTongNut);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "PlayGame";
            this.Text = "Play Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayGame_FormClosing);
            this.Load += new System.EventHandler(this.PlayGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbThoiGian;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbLuot;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btBatDau;
        private System.Windows.Forms.Button btLac;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNut;
        private System.Windows.Forms.TextBox tbDiem;
        private System.Windows.Forms.TextBox tbNguoiChoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTongNut;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbnguoi;
        private System.Windows.Forms.Label label6;
    }
}