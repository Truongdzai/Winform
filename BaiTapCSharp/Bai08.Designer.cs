namespace WinFormsApp_Article
{
    partial class Bai08
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tbSoX = new TextBox();
            tbSoY = new TextBox();
            tbKetQua = new TextBox();
            btCong = new Button();
            btNhan = new Button();
            btThoat = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(111, 85);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 0;
            label1.Text = "Số X";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(111, 146);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 1;
            label2.Text = "Số Y";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(111, 205);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 2;
            label3.Text = "Kết Quả";
            // 
            // tbSoX
            // 
            tbSoX.Location = new Point(200, 78);
            tbSoX.Name = "tbSoX";
            tbSoX.Size = new Size(467, 27);
            tbSoX.TabIndex = 3;
            // 
            // tbSoY
            // 
            tbSoY.Location = new Point(200, 143);
            tbSoY.Name = "tbSoY";
            tbSoY.Size = new Size(467, 27);
            tbSoY.TabIndex = 4;
            // 
            // tbKetQua
            // 
            tbKetQua.Location = new Point(200, 202);
            tbKetQua.Name = "tbKetQua";
            tbKetQua.Size = new Size(467, 27);
            tbKetQua.TabIndex = 5;
            // 
            // btCong
            // 
            btCong.Location = new Point(111, 257);
            btCong.Name = "btCong";
            btCong.Size = new Size(103, 50);
            btCong.TabIndex = 6;
            btCong.Text = "Cộng";
            btCong.UseVisualStyleBackColor = true;
            // 
            // btNhan
            // 
            btNhan.Location = new Point(238, 257);
            btNhan.Name = "btNhan";
            btNhan.Size = new Size(103, 50);
            btNhan.TabIndex = 7;
            btNhan.Text = "Nhân";
            btNhan.UseVisualStyleBackColor = true;
            // 
            // btThoat
            // 
            btThoat.Location = new Point(564, 257);
            btThoat.Name = "btThoat";
            btThoat.Size = new Size(103, 50);
            btThoat.TabIndex = 8;
            btThoat.Text = "Thoát";
            btThoat.UseVisualStyleBackColor = true;
            // 
            // Bai08
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btThoat);
            Controls.Add(btNhan);
            Controls.Add(btCong);
            Controls.Add(tbKetQua);
            Controls.Add(tbSoY);
            Controls.Add(tbSoX);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Bai08";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Bai08_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbSoX;
        private TextBox tbSoY;
        private TextBox tbKetQua;
        private Button btCong;
        private Button btNhan;
        private Button btThoat;
    }
}