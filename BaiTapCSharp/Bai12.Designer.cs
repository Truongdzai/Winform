namespace WinFormsApp_Article
{
    partial class Bai12
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
            cb_Faculty = new ComboBox();
            tbDisplay = new TextBox();
            btOK = new Button();
            btCancel = new Button();
            SuspendLayout();
            // 
            // cb_Faculty
            // 
            cb_Faculty.FormattingEnabled = true;
            cb_Faculty.Items.AddRange(new object[] { "Công nghệ thông tin", "Kế toán", "Cơ khí", "Điện", "Hóa" });
            cb_Faculty.Location = new Point(32, 38);
            cb_Faculty.Name = "cb_Faculty";
            cb_Faculty.Size = new Size(719, 28);
            cb_Faculty.TabIndex = 0;
            cb_Faculty.SelectedIndexChanged += cb_Faculty_SelectedIndexChanged;
            // 
            // tbDisplay
            // 
            tbDisplay.Location = new Point(35, 93);
            tbDisplay.Name = "tbDisplay";
            tbDisplay.Size = new Size(712, 27);
            tbDisplay.TabIndex = 1;
            // 
            // btOK
            // 
            btOK.Location = new Point(557, 219);
            btOK.Name = "btOK";
            btOK.Size = new Size(98, 48);
            btOK.TabIndex = 2;
            btOK.Text = "OK";
            btOK.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            btCancel.Location = new Point(677, 219);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(95, 48);
            btCancel.TabIndex = 3;
            btCancel.Text = "Cancel";
            btCancel.UseVisualStyleBackColor = true;
            btCancel.Click += this.btCancel_Click;
            // 
            // Bai12
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btCancel);
            Controls.Add(btOK);
            Controls.Add(tbDisplay);
            Controls.Add(cb_Faculty);
            Name = "Bai12";
            Text = "Form1";
            Load += Bai12_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cb_Faculty;
        private TextBox tbDisplay;
        private Button btOK;
        private Button btCancel;
    }
}