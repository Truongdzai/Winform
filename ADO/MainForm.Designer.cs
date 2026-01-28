namespace ADO
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btCustomer = new System.Windows.Forms.Button();
            this.btProduct = new System.Windows.Forms.Button();
            this.btInvoice = new System.Windows.Forms.Button();
            this.btStats = new System.Windows.Forms.Button();
            this.btLogout = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();

            // Header
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Size = new System.Drawing.Size(800, 80);
            this.panelHeader.TabIndex = 0;

            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(260, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(267, 54);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "DASHBOARD";

            // 1. btCustomer (Khách hàng) - Góc trên trái
            this.btCustomer.BackColor = System.Drawing.Color.White;
            this.btCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCustomer.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btCustomer.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btCustomer.Location = new System.Drawing.Point(100, 120);
            this.btCustomer.Name = "btCustomer";
            this.btCustomer.Size = new System.Drawing.Size(280, 160);
            this.btCustomer.TabIndex = 1;
            this.btCustomer.Text = "QUẢN LÝ\nKHÁCH HÀNG";
            this.btCustomer.UseVisualStyleBackColor = false;
            this.btCustomer.Click += new System.EventHandler(this.btCustomer_Click);

            // 2. btProduct (Sản phẩm) - Góc trên phải
            this.btProduct.BackColor = System.Drawing.Color.White;
            this.btProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btProduct.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btProduct.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12); // Màu Cam
            this.btProduct.Location = new System.Drawing.Point(420, 120);
            this.btProduct.Name = "btProduct";
            this.btProduct.Size = new System.Drawing.Size(280, 160);
            this.btProduct.TabIndex = 2;
            this.btProduct.Text = "QUẢN LÝ\nSẢN PHẨM";
            this.btProduct.UseVisualStyleBackColor = false;
            this.btProduct.Click += new System.EventHandler(this.btProduct_Click);

            // 3. btInvoice (Bán hàng) - Góc dưới trái
            this.btInvoice.BackColor = System.Drawing.Color.White;
            this.btInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btInvoice.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btInvoice.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74); // Màu Xanh lá
            this.btInvoice.Location = new System.Drawing.Point(100, 310);
            this.btInvoice.Name = "btInvoice";
            this.btInvoice.Size = new System.Drawing.Size(280, 160);
            this.btInvoice.TabIndex = 3;
            this.btInvoice.Text = "BÁN HÀNG\n(LẬP HÓA ĐƠN)";
            this.btInvoice.UseVisualStyleBackColor = false;
            this.btInvoice.Click += new System.EventHandler(this.btInvoice_Click);

            // 4. btStats (Thống kê - MỚI) - Góc dưới phải
            this.btStats.BackColor = System.Drawing.Color.White;
            this.btStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btStats.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btStats.ForeColor = System.Drawing.Color.FromArgb(124, 58, 237); // Màu Tím
            this.btStats.Location = new System.Drawing.Point(420, 310);
            this.btStats.Name = "btStats";
            this.btStats.Size = new System.Drawing.Size(280, 160);
            this.btStats.TabIndex = 4;
            this.btStats.Text = "BÁO CÁO\nDOANH THU";
            this.btStats.UseVisualStyleBackColor = false;
            this.btStats.Click += new System.EventHandler(this.btStats_Click);

            // btLogout
            this.btLogout.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btLogout.FlatAppearance.BorderSize = 0;
            this.btLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btLogout.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btLogout.Location = new System.Drawing.Point(340, 500);
            this.btLogout.Name = "btLogout";
            this.btLogout.Size = new System.Drawing.Size(120, 40);
            this.btLogout.TabIndex = 5;
            this.btLogout.Text = "Đăng xuất";
            this.btLogout.UseVisualStyleBackColor = false;
            this.btLogout.Click += new System.EventHandler(this.btLogout_Click);

            // Form MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.btCustomer);
            this.Controls.Add(this.btProduct);
            this.Controls.Add(this.btInvoice);
            this.Controls.Add(this.btStats); // Thêm nút Thống kê
            this.Controls.Add(this.btLogout);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Tổng hợp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
        }



        private System.Windows.Forms.Button btCustomer;
        private System.Windows.Forms.Button btProduct;
        private System.Windows.Forms.Button btInvoice;
        private System.Windows.Forms.Button btStats;
        private System.Windows.Forms.Button btLogout;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelHeader;
    }
}