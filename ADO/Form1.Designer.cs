namespace ADO
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            btRead = new Button();
            btNew = new Button();
            btEdit = new Button();
            btDelete = new Button();
            btExit = new Button();
            btSearch = new Button();
            tbSearch = new TextBox();
            label5 = new Label();
            dgvCustomer = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colDob = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            gbInfo = new GroupBox();
            btBrowse = new Button();
            pbAvatar = new PictureBox();
            label4 = new Label();
            tbPhone = new TextBox();
            dtpDob = new DateTimePicker();
            label3 = new Label();
            label2 = new Label();
            tbName = new TextBox();
            label1 = new Label();
            tbId = new TextBox();
            gbList = new GroupBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).BeginInit();
            gbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbAvatar).BeginInit();
            gbList.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(37, 99, 235);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1100, 60);
            panelHeader.TabIndex = 10;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(20, 15);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(322, 37);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "QUẢN LÝ KHÁCH HÀNG";
            // 
            // gbInfo
            // 
            gbInfo.BackColor = Color.White;
            gbInfo.Controls.Add(btBrowse);
            gbInfo.Controls.Add(pbAvatar);
            gbInfo.Controls.Add(label4);
            gbInfo.Controls.Add(tbPhone);
            gbInfo.Controls.Add(dtpDob);
            gbInfo.Controls.Add(label3);
            gbInfo.Controls.Add(label2);
            gbInfo.Controls.Add(tbName);
            gbInfo.Controls.Add(label1);
            gbInfo.Controls.Add(tbId);
            gbInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gbInfo.ForeColor = Color.FromArgb(71, 85, 105);
            gbInfo.Location = new Point(20, 80);
            gbInfo.Name = "gbInfo";
            gbInfo.Size = new Size(320, 520);
            gbInfo.TabIndex = 3;
            gbInfo.TabStop = false;
            gbInfo.Text = "Thông Tin Chi Tiết";
            // 
            // btBrowse
            // 
            btBrowse.BackColor = Color.FromArgb(226, 232, 240);
            btBrowse.FlatAppearance.BorderSize = 0;
            btBrowse.FlatStyle = FlatStyle.Flat;
            btBrowse.Font = new Font("Segoe UI", 9F);
            btBrowse.Location = new Point(90, 430);
            btBrowse.Name = "btBrowse";
            btBrowse.Size = new Size(140, 30);
            btBrowse.TabIndex = 9;
            btBrowse.Text = "Chọn hình ảnh";
            btBrowse.UseVisualStyleBackColor = false;
            btBrowse.Click += btBrowse_Click;
            // 
            // pbAvatar
            // 
            pbAvatar.BackColor = Color.FromArgb(241, 245, 249);
            pbAvatar.BorderStyle = BorderStyle.FixedSingle;
            pbAvatar.Location = new Point(90, 240);
            pbAvatar.Name = "pbAvatar";
            pbAvatar.Size = new Size(140, 180);
            pbAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            pbAvatar.TabIndex = 8;
            pbAvatar.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F);
            label4.Location = new Point(170, 170);
            label4.Name = "label4";
            label4.Size = new Size(100, 20);
            label4.TabIndex = 6;
            label4.Text = "Số điện thoại:";
            // 
            // tbPhone
            // 
            tbPhone.Font = new Font("Segoe UI", 10F);
            tbPhone.Location = new Point(170, 195);
            tbPhone.Name = "tbPhone";
            tbPhone.Size = new Size(130, 30);
            tbPhone.TabIndex = 7;
            // 
            // dtpDob
            // 
            dtpDob.Font = new Font("Segoe UI", 10F);
            dtpDob.Format = DateTimePickerFormat.Short;
            dtpDob.Location = new Point(20, 195);
            dtpDob.Name = "dtpDob";
            dtpDob.Size = new Size(130, 30);
            dtpDob.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(20, 170);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 4;
            label3.Text = "Ngày sinh:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(20, 105);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 2;
            label2.Text = "Họ và tên:";
            // 
            // tbName
            // 
            tbName.Font = new Font("Segoe UI", 10F);
            tbName.Location = new Point(20, 130);
            tbName.Name = "tbName";
            tbName.Size = new Size(280, 30);
            tbName.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(20, 40);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã KH:";
            // 
            // tbId
            // 
            tbId.Font = new Font("Segoe UI", 10F);
            tbId.Location = new Point(20, 65);
            tbId.Name = "tbId";
            tbId.Size = new Size(280, 30);
            tbId.TabIndex = 1;
            // 
            // gbList
            // 
            gbList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbList.Controls.Add(dgvCustomer);
            gbList.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gbList.ForeColor = Color.FromArgb(71, 85, 105);
            gbList.Location = new Point(360, 125);
            gbList.Name = "gbList";
            gbList.Size = new Size(710, 400);
            gbList.TabIndex = 4;
            gbList.TabStop = false;
            gbList.Text = "Danh Sách Khách Hàng";
            // 
            // dgvCustomer
            // 
            dgvCustomer.AllowUserToAddRows = false;
            dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomer.BackgroundColor = Color.White;
            dgvCustomer.BorderStyle = BorderStyle.None;
            dgvCustomer.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCustomer.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCustomer.ColumnHeadersHeight = 40;
            dgvCustomer.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colDob, colPhone });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(71, 85, 105);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(30, 64, 175);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvCustomer.DefaultCellStyle = dataGridViewCellStyle2;
            dgvCustomer.Dock = DockStyle.Fill;
            dgvCustomer.EnableHeadersVisualStyles = false;
            dgvCustomer.GridColor = Color.FromArgb(241, 245, 249);
            dgvCustomer.Location = new Point(3, 26);
            dgvCustomer.MultiSelect = false;
            dgvCustomer.Name = "dgvCustomer";
            dgvCustomer.ReadOnly = true;
            dgvCustomer.RowHeadersVisible = false;
            dgvCustomer.RowHeadersWidth = 51;
            dgvCustomer.RowTemplate.Height = 35;
            dgvCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomer.Size = new Size(704, 371);
            dgvCustomer.TabIndex = 0;
            dgvCustomer.CellClick += dgvCustomer_CellClick;
            dgvCustomer.CellContentClick += dgvCustomer_CellContentClick;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colName
            // 
            colName.HeaderText = "HỌ TÊN";
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colDob
            // 
            colDob.HeaderText = "NGÀY SINH";
            colDob.Name = "colDob";
            colDob.ReadOnly = true;
            // 
            // colPhone
            // 
            colPhone.HeaderText = "SỐ ĐIỆN THOẠI";
            colPhone.Name = "colPhone";
            colPhone.ReadOnly = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(71, 85, 105);
            label5.Location = new Point(360, 85);
            label5.Name = "label5";
            label5.Size = new Size(78, 20);
            label5.TabIndex = 0;
            label5.Text = "Tìm kiếm:";
            // 
            // tbSearch
            // 
            tbSearch.Font = new Font("Segoe UI", 10F);
            tbSearch.Location = new Point(445, 80);
            tbSearch.Name = "tbSearch";
            tbSearch.PlaceholderText = "Nhập tên hoặc mã để tìm...";
            tbSearch.Size = new Size(400, 30);
            tbSearch.TabIndex = 1;
            // 
            // btSearch
            // 
            btSearch.BackColor = Color.FromArgb(51, 65, 85);
            btSearch.FlatAppearance.BorderSize = 0;
            btSearch.FlatStyle = FlatStyle.Flat;
            btSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btSearch.ForeColor = Color.White;
            btSearch.Location = new Point(855, 80);
            btSearch.Name = "btSearch";
            btSearch.Size = new Size(100, 30);
            btSearch.TabIndex = 2;
            btSearch.Text = "TÌM KIẾM";
            btSearch.UseVisualStyleBackColor = false;
            btSearch.Click += btSearch_Click;
            // 
            // btRead
            // 
            btRead.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btRead.BackColor = Color.FromArgb(37, 99, 235);
            btRead.FlatAppearance.BorderSize = 0;
            btRead.FlatStyle = FlatStyle.Flat;
            btRead.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btRead.ForeColor = Color.White;
            btRead.Location = new Point(550, 545);
            btRead.Name = "btRead";
            btRead.Size = new Size(100, 40);
            btRead.TabIndex = 5;
            btRead.Text = "LÀM MỚI";
            btRead.UseVisualStyleBackColor = false;
            btRead.Click += btRead_Click;
            // 
            // btNew
            // 
            btNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btNew.BackColor = Color.FromArgb(22, 163, 74);
            btNew.FlatAppearance.BorderSize = 0;
            btNew.FlatStyle = FlatStyle.Flat;
            btNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btNew.ForeColor = Color.White;
            btNew.Location = new Point(660, 545);
            btNew.Name = "btNew";
            btNew.Size = new Size(100, 40);
            btNew.TabIndex = 6;
            btNew.Text = "THÊM MỚI";
            btNew.UseVisualStyleBackColor = false;
            btNew.Click += btNew_Click;
            // 
            // btEdit
            // 
            btEdit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btEdit.BackColor = Color.FromArgb(234, 179, 8);
            btEdit.FlatAppearance.BorderSize = 0;
            btEdit.FlatStyle = FlatStyle.Flat;
            btEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btEdit.ForeColor = Color.White;
            btEdit.Location = new Point(770, 545);
            btEdit.Name = "btEdit";
            btEdit.Size = new Size(100, 40);
            btEdit.TabIndex = 7;
            btEdit.Text = "CẬP NHẬT";
            btEdit.UseVisualStyleBackColor = false;
            btEdit.Click += btEdit_Click;
            // 
            // btDelete
            // 
            btDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btDelete.BackColor = Color.FromArgb(220, 38, 38);
            btDelete.FlatAppearance.BorderSize = 0;
            btDelete.FlatStyle = FlatStyle.Flat;
            btDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btDelete.ForeColor = Color.White;
            btDelete.Location = new Point(880, 545);
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(100, 40);
            btDelete.TabIndex = 8;
            btDelete.Text = "XÓA BỎ";
            btDelete.UseVisualStyleBackColor = false;
            btDelete.Click += btDelete_Click;
            // 
            // btExit
            // 
            btExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btExit.BackColor = Color.FromArgb(148, 163, 184);
            btExit.FlatAppearance.BorderSize = 0;
            btExit.FlatStyle = FlatStyle.Flat;
            btExit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btExit.ForeColor = Color.White;
            btExit.Location = new Point(990, 545);
            btExit.Name = "btExit";
            btExit.Size = new Size(90, 40);
            btExit.TabIndex = 9;
            btExit.Text = "THOÁT";
            btExit.UseVisualStyleBackColor = false;
            btExit.Click += btExit_Click;
            // 
            // Form1
            // 
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1100, 620);
            Controls.Add(panelHeader);
            Controls.Add(label5);
            Controls.Add(tbSearch);
            Controls.Add(btSearch);
            Controls.Add(gbInfo);
            Controls.Add(gbList);
            Controls.Add(btRead);
            Controls.Add(btNew);
            Controls.Add(btEdit);
            Controls.Add(btDelete);
            Controls.Add(btExit);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống Quản lý Khách hàng";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCustomer).EndInit();
            gbInfo.ResumeLayout(false);
            gbInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbAvatar).EndInit();
            gbList.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btRead, btNew, btEdit, btDelete, btExit, btBrowse, btSearch;
        private System.Windows.Forms.TextBox tbId, tbName, tbPhone, tbSearch;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.PictureBox pbAvatar;
        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId, colName, colDob, colPhone;
        private System.Windows.Forms.GroupBox gbInfo, gbList;
        private System.Windows.Forms.Label label1, label2, label3, label4, label5, labelTitle;
        private System.Windows.Forms.Panel panelHeader;
    }
}