namespace WinFormsApp_Article
{
    partial class Bai09
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
            btLuu = new Button();
            btCong = new Button();
            btNhan = new Button();
            btThoat = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 26);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 0;
            label1.Text = "Số X";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 128);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 1;
            label2.Text = "Kết Quả";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 82);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 2;
            label3.Text = "Số Y";
            // 
            // tbSoX
            // 
            tbSoX.Location = new Point(111, 23);
            tbSoX.Name = "tbSoX";
            tbSoX.Size = new Size(575, 27);
            tbSoX.TabIndex = 3;
            // 
            // tbSoY
            // 
            tbSoY.Location = new Point(111, 79);
            tbSoY.Name = "tbSoY";
            tbSoY.Size = new Size(575, 27);
            tbSoY.TabIndex = 4;
            // 
            // tbKetQua
            // 
            tbKetQua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbKetQua.Location = new Point(113, 139);
            tbKetQua.Multiline = true;
            tbKetQua.Name = "tbKetQua";
            tbKetQua.Size = new Size(573, 257);
            tbKetQua.TabIndex = 5;
            // 
            // btLuu
            // 
            btLuu.Location = new Point(27, 402);
            btLuu.Name = "btLuu";
            btLuu.Size = new Size(97, 34);
            btLuu.TabIndex = 6;
            btLuu.Text = "Lưu";
            btLuu.UseVisualStyleBackColor = true;
            btLuu.Click += this.btLuu_Click;
            // 
            // btCong
            // 
            btCong.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btCong.Location = new Point(358, 404);
            btCong.Name = "btCong";
            btCong.Size = new Size(97, 34);
            btCong.TabIndex = 7;
            btCong.Text = "Cộng";
            btCong.UseVisualStyleBackColor = true;
            // 
            // btNhan
            // 
            btNhan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btNhan.Location = new Point(473, 404);
            btNhan.Name = "btNhan";
            btNhan.Size = new Size(97, 34);
            btNhan.TabIndex = 8;
            btNhan.Text = "Nhân";
            btNhan.UseVisualStyleBackColor = true;
            // 
            // btThoat
            // 
            btThoat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btThoat.Location = new Point(589, 404);
            btThoat.Name = "btThoat";
            btThoat.Size = new Size(97, 34);
            btThoat.TabIndex = 9;
            btThoat.Text = "Thoát";
            btThoat.UseVisualStyleBackColor = true;
            // 
            // Bai09
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btThoat);
            Controls.Add(btNhan);
            Controls.Add(btCong);
            Controls.Add(btLuu);
            Controls.Add(tbKetQua);
            Controls.Add(tbSoY);
            Controls.Add(tbSoX);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Bai09";
            Text = "Form1";
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
        private Button btLuu;
        private Button btCong;
        private Button btNhan;
        private Button btThoat;
    }
}