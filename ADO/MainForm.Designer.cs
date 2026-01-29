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
            this.btGallery = new System.Windows.Forms.Button(); // Nút Mới
            this.btLogout = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuImportProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.menuImportCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGallery = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.panelHeader.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();

            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.menuSystem, this.menuTools, this.menuHelp });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";

            // Menu Items (System, Tools, Help...)
            this.menuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.menuLogout, this.menuExit });
            this.menuSystem.Name = "menuSystem"; this.menuSystem.Text = "Hệ thống";
            this.menuLogout.Name = "menuLogout"; this.menuLogout.Text = "Đăng xuất"; this.menuLogout.Click += new System.EventHandler(this.btLogout_Click);
            this.menuExit.Name = "menuExit"; this.menuExit.Text = "Thoát"; this.menuExit.Click += new System.EventHandler(this.menuExit_Click);

            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.menuImportProduct, this.menuImportCustomer, this.menuGallery });
            this.menuTools.Name = "menuTools"; this.menuTools.Text = "Công cụ";
            this.menuImportProduct.Name = "menuImportProduct"; this.menuImportProduct.Text = "Nhập Excel Sản phẩm"; this.menuImportProduct.Click += new System.EventHandler(this.menuImportProduct_Click);
            this.menuImportCustomer.Name = "menuImportCustomer"; this.menuImportCustomer.Text = "Nhập Excel Khách hàng"; this.menuImportCustomer.Click += new System.EventHandler(this.menuImportCustomer_Click);
            this.menuGallery.Name = "menuGallery"; this.menuGallery.Text = "Thư viện Hình ảnh"; this.menuGallery.Click += new System.EventHandler(this.menuGallery_Click);

            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.menuAbout });
            this.menuHelp.Name = "menuHelp"; this.menuHelp.Text = "Trợ giúp";
            this.menuAbout.Name = "menuAbout"; this.menuAbout.Text = "Giới thiệu"; this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);

            // panelHeader
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 28);
            this.panelHeader.Size = new System.Drawing.Size(800, 80);
            this.panelHeader.TabIndex = 0;

            // labelTitle
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(260, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(267, 54);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "DASHBOARD";

            // 1. btCustomer
            this.btCustomer.BackColor = System.Drawing.Color.White;
            this.btCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCustomer.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btCustomer.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btCustomer.Location = new System.Drawing.Point(100, 130);
            this.btCustomer.Name = "btCustomer";
            this.btCustomer.Size = new System.Drawing.Size(280, 140);
            this.btCustomer.TabIndex = 1;
            this.btCustomer.Text = "QUẢN LÝ\nKHÁCH HÀNG";
            this.btCustomer.UseVisualStyleBackColor = false;
            this.btCustomer.Click += new System.EventHandler(this.btCustomer_Click);

            // 2. btProduct
            this.btProduct.BackColor = System.Drawing.Color.White;
            this.btProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btProduct.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btProduct.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.btProduct.Location = new System.Drawing.Point(420, 130);
            this.btProduct.Name = "btProduct";
            this.btProduct.Size = new System.Drawing.Size(280, 140);
            this.btProduct.TabIndex = 2;
            this.btProduct.Text = "QUẢN LÝ\nSẢN PHẨM";
            this.btProduct.UseVisualStyleBackColor = false;
            this.btProduct.Click += new System.EventHandler(this.btProduct_Click);

            // 3. btInvoice
            this.btInvoice.BackColor = System.Drawing.Color.White;
            this.btInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btInvoice.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btInvoice.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btInvoice.Location = new System.Drawing.Point(100, 290);
            this.btInvoice.Name = "btInvoice";
            this.btInvoice.Size = new System.Drawing.Size(280, 140);
            this.btInvoice.TabIndex = 3;
            this.btInvoice.Text = "BÁN HÀNG\n(LẬP HÓA ĐƠN)";
            this.btInvoice.UseVisualStyleBackColor = false;
            this.btInvoice.Click += new System.EventHandler(this.btInvoice_Click);

            // 4. btStats
            this.btStats.BackColor = System.Drawing.Color.White;
            this.btStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btStats.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btStats.ForeColor = System.Drawing.Color.FromArgb(124, 58, 237);
            this.btStats.Location = new System.Drawing.Point(420, 290);
            this.btStats.Name = "btStats";
            this.btStats.Size = new System.Drawing.Size(280, 140);
            this.btStats.TabIndex = 4;
            this.btStats.Text = "BÁO CÁO\nDOANH THU";
            this.btStats.UseVisualStyleBackColor = false;
            this.btStats.Click += new System.EventHandler(this.btStats_Click);

            // 5. btGallery (NÚT MỚI - THƯ VIỆN ẢNH)
            this.btGallery.BackColor = System.Drawing.Color.White;
            this.btGallery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGallery.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btGallery.ForeColor = System.Drawing.Color.FromArgb(255, 0, 100); // Màu Hồng
            this.btGallery.Location = new System.Drawing.Point(100, 450);
            this.btGallery.Name = "btGallery";
            this.btGallery.Size = new System.Drawing.Size(600, 80); // Nút dài nằm ngang
            this.btGallery.TabIndex = 5;
            this.btGallery.Text = "THƯ VIỆN HÌNH ẢNH SẢN PHẨM";
            this.btGallery.UseVisualStyleBackColor = false;
            this.btGallery.Click += new System.EventHandler(this.btGallery_Click);

            // btLogout
            this.btLogout.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btLogout.FlatAppearance.BorderSize = 0;
            this.btLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btLogout.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btLogout.Location = new System.Drawing.Point(340, 560);
            this.btLogout.Name = "btLogout";
            this.btLogout.Size = new System.Drawing.Size(120, 40);
            this.btLogout.TabIndex = 6;
            this.btLogout.Text = "Đăng xuất";
            this.btLogout.UseVisualStyleBackColor = false;
            this.btLogout.Click += new System.EventHandler(this.btLogout_Click);

            // Form MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 620); // Tăng chiều cao để chứa nút mới
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btCustomer);
            this.Controls.Add(this.btProduct);
            this.Controls.Add(this.btInvoice);
            this.Controls.Add(this.btStats);
            this.Controls.Add(this.btGallery); // Thêm nút Gallery vào Form
            this.Controls.Add(this.btLogout);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Tổng hợp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }



        private System.Windows.Forms.Button btCustomer;
        private System.Windows.Forms.Button btProduct;
        private System.Windows.Forms.Button btInvoice;
        private System.Windows.Forms.Button btStats;
        private System.Windows.Forms.Button btGallery; // Khai báo nút mới
        private System.Windows.Forms.Button btLogout;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelHeader;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuSystem;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuTools;
        private System.Windows.Forms.ToolStripMenuItem menuImportProduct;
        private System.Windows.Forms.ToolStripMenuItem menuImportCustomer;
        private System.Windows.Forms.ToolStripMenuItem menuGallery;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
    }
}