namespace WinFormsApp_Article
{
    partial class Bai30
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tbId = new TextBox();
            tbName = new TextBox();
            ckGender = new CheckBox();
            cboClass = new ComboBox();
            pbAvatar = new PictureBox();
            btBrowse = new Button();
            dgvData = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colClass = new DataGridViewTextBoxColumn();
            colGender = new DataGridViewCheckBoxColumn();
            btAdd = new Button();
            btEdit = new Button();
            btDelete = new Button();
            btSave = new Button();
            tbSearch = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pbAvatar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 30);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 15;
            label1.Text = "Mã SV";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 70);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 14;
            label2.Text = "Họ tên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 110);
            label3.Name = "label3";
            label3.Size = new Size(34, 20);
            label3.TabIndex = 13;
            label3.Text = "Lớp";
            // 
            // label4
            // 
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 0;
            // 
            // tbId
            // 
            tbId.Location = new Point(100, 27);
            tbId.Name = "tbId";
            tbId.Size = new Size(150, 27);
            tbId.TabIndex = 12;
            // 
            // tbName
            // 
            tbName.Location = new Point(100, 67);
            tbName.Name = "tbName";
            tbName.Size = new Size(200, 27);
            tbName.TabIndex = 11;
            // 
            // ckGender
            // 
            ckGender.AutoSize = true;
            ckGender.Location = new Point(100, 150);
            ckGender.Name = "ckGender";
            ckGender.Size = new Size(63, 24);
            ckGender.TabIndex = 9;
            ckGender.Text = "Nam";
            ckGender.UseVisualStyleBackColor = true;
            // 
            // cboClass
            // 
            cboClass.FormattingEnabled = true;
            cboClass.Items.AddRange(new object[] { "CNTT K15", "Kinh Tế K16", "Ngoại Ngữ K14" });
            cboClass.Location = new Point(100, 107);
            cboClass.Name = "cboClass";
            cboClass.Size = new Size(150, 28);
            cboClass.TabIndex = 10;
            // 
            // pbAvatar
            // 
            pbAvatar.BorderStyle = BorderStyle.FixedSingle;
            pbAvatar.Location = new Point(330, 27);
            pbAvatar.Name = "pbAvatar";
            pbAvatar.Size = new Size(120, 150);
            pbAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            pbAvatar.TabIndex = 8;
            pbAvatar.TabStop = false;
            // 
            // btBrowse
            // 
            btBrowse.Location = new Point(330, 183);
            btBrowse.Name = "btBrowse";
            btBrowse.Size = new Size(120, 30);
            btBrowse.TabIndex = 7;
            btBrowse.Text = "Chọn ảnh...";
            btBrowse.UseVisualStyleBackColor = true;
            btBrowse.Click += btBrowse_Click;
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colClass, colGender });
            dgvData.Location = new Point(30, 280);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersWidth = 51;
            dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvData.Size = new Size(600, 250);
            dgvData.TabIndex = 6;
            dgvData.RowEnter += dgvData_RowEnter;
            // 
            // colId
            // 
            colId.DataPropertyName = "Id";
            colId.HeaderText = "Mã SV";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colName
            // 
            colName.DataPropertyName = "Name";
            colName.HeaderText = "Họ Tên";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 200;
            // 
            // colClass
            // 
            colClass.DataPropertyName = "ClassName";
            colClass.HeaderText = "Lớp";
            colClass.MinimumWidth = 6;
            colClass.Name = "colClass";
            colClass.ReadOnly = true;
            // 
            // colGender
            // 
            colGender.DataPropertyName = "Gender";
            colGender.HeaderText = "Nam";
            colGender.MinimumWidth = 6;
            colGender.Name = "colGender";
            colGender.ReadOnly = true;
            colGender.Width = 60;
            // 
            // btAdd
            // 
            btAdd.Location = new Point(30, 230);
            btAdd.Name = "btAdd";
            btAdd.Size = new Size(80, 35);
            btAdd.TabIndex = 5;
            btAdd.Text = "Thêm";
            btAdd.Click += btAdd_Click;
            // 
            // btEdit
            // 
            btEdit.Location = new Point(120, 230);
            btEdit.Name = "btEdit";
            btEdit.Size = new Size(80, 35);
            btEdit.TabIndex = 4;
            btEdit.Text = "Sửa";
            btEdit.Click += btEdit_Click;
            // 
            // btDelete
            // 
            btDelete.Location = new Point(210, 230);
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(80, 35);
            btDelete.TabIndex = 3;
            btDelete.Text = "Xóa";
            btDelete.Click += btDelete_Click;
            // 
            // btSave
            // 
            btSave.BackColor = Color.LightGreen;
            btSave.Enabled = false;
            btSave.Location = new Point(330, 230);
            btSave.Name = "btSave";
            btSave.Size = new Size(120, 35);
            btSave.TabIndex = 2;
            btSave.Text = "LƯU";
            btSave.UseVisualStyleBackColor = false;
            btSave.Click += btSave_Click;
            // 
            // tbSearch
            // 
            tbSearch.Location = new Point(470, 50);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(160, 27);
            tbSearch.TabIndex = 1;
            tbSearch.TextChanged += tbSearch_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(470, 27);
            label5.Name = "label5";
            label5.Size = new Size(73, 20);
            label5.TabIndex = 0;
            label5.Text = "Tìm kiếm:";
            // 
            // Bai30
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(660, 550);
            Controls.Add(label5);
            Controls.Add(tbSearch);
            Controls.Add(btSave);
            Controls.Add(btDelete);
            Controls.Add(btEdit);
            Controls.Add(btAdd);
            Controls.Add(dgvData);
            Controls.Add(btBrowse);
            Controls.Add(pbAvatar);
            Controls.Add(ckGender);
            Controls.Add(cboClass);
            Controls.Add(tbName);
            Controls.Add(tbId);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Bai30";
            Text = "Quản lý Sinh Viên Full";
            Load += Bai30_Load;
            ((System.ComponentModel.ISupportInitialize)pbAvatar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1, label2, label3, label4, label5;
        private System.Windows.Forms.TextBox tbId, tbName, tbSearch;
        private System.Windows.Forms.CheckBox ckGender;
        private System.Windows.Forms.ComboBox cboClass;
        private System.Windows.Forms.PictureBox pbAvatar;
        private System.Windows.Forms.Button btBrowse, btAdd, btEdit, btDelete, btSave;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId, colName, colClass;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colGender;
    }
}