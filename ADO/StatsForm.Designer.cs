namespace ADO
{
    partial class StatsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.btView = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvStats = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCust = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStats)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();

            // Header
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(124, 58, 237); // Màu Tím
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Size = new System.Drawing.Size(900, 60);

            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(20, 15);
            this.labelTitle.Text = "BÁO CÁO DOANH THU";

            // Panel Filter (Chọn ngày)
            this.panelFilter.BackColor = System.Drawing.Color.White;
            this.panelFilter.Controls.Add(this.btView);
            this.panelFilter.Controls.Add(this.dtpTo);
            this.panelFilter.Controls.Add(this.label2);
            this.panelFilter.Controls.Add(this.dtpFrom);
            this.panelFilter.Controls.Add(this.label1);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Size = new System.Drawing.Size(900, 70);

            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 25);
            this.label1.Text = "Từ ngày:";

            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(100, 22);
            this.dtpFrom.Size = new System.Drawing.Size(120, 27);

            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 25);
            this.label2.Text = "Đến ngày:";

            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(330, 22);
            this.dtpTo.Size = new System.Drawing.Size(120, 27);

            this.btView.BackColor = System.Drawing.Color.FromArgb(124, 58, 237);
            this.btView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btView.ForeColor = System.Drawing.Color.White;
            this.btView.Location = new System.Drawing.Point(480, 20);
            this.btView.Size = new System.Drawing.Size(120, 32);
            this.btView.Text = "XEM BÁO CÁO";
            this.btView.UseVisualStyleBackColor = false;
            this.btView.Click += new System.EventHandler(this.btView_Click);

            // GridView
            this.dgvStats.AllowUserToAddRows = false;
            this.dgvStats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStats.BackgroundColor = System.Drawing.Color.White;
            this.dgvStats.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStats.ColumnHeadersHeight = 35;
            this.dgvStats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colId, this.colDate, this.colCust, this.colTotal });

            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvStats.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;

            this.dgvStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStats.EnableHeadersVisualStyles = false;
            this.dgvStats.ReadOnly = true;
            this.dgvStats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.colId.HeaderText = "Mã Hóa Đơn"; this.colId.Name = "colId";
            this.colDate.HeaderText = "Ngày Lập"; this.colDate.Name = "colDate";
            this.colCust.HeaderText = "Khách Hàng"; this.colCust.Name = "colCust";
            this.colTotal.HeaderText = "Tổng Tiền"; this.colTotal.Name = "colTotal";

            // Panel Bottom (Tổng kết)
            this.panelBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelBottom.Controls.Add(this.lblTotalRevenue);
            this.panelBottom.Controls.Add(this.label3);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Size = new System.Drawing.Size(900, 60);

            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(500, 15);
            this.label3.Text = "TỔNG DOANH THU:";

            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.Red;
            this.lblTotalRevenue.Location = new System.Drawing.Point(680, 12);
            this.lblTotalRevenue.Text = "0 VNĐ";

            // Form StatsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.dgvStats);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelHeader);
            this.Name = "StatsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê doanh thu";
            this.Load += new System.EventHandler(this.StatsForm_Load);

            this.panelHeader.ResumeLayout(false); this.panelHeader.PerformLayout();
            this.panelFilter.ResumeLayout(false); this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStats)).EndInit();
            this.panelBottom.ResumeLayout(false); this.panelBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelHeader, panelFilter, panelBottom;
        private System.Windows.Forms.Label labelTitle, label1, label2, label3, lblTotalRevenue;
        private System.Windows.Forms.DateTimePicker dtpFrom, dtpTo;
        private System.Windows.Forms.Button btView;
        private System.Windows.Forms.DataGridView dgvStats;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId, colDate, colCust, colTotal;
    }
}