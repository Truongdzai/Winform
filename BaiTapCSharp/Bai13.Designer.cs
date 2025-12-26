namespace WinFormsApp_Article
{
    partial class Bai13
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
            cb_Faculty.Location = new Point(81, 34);
            cb_Faculty.Name = "cb_Faculty";
            cb_Faculty.Size = new Size(629, 28);
            cb_Faculty.TabIndex = 0;
            // 
            // tbDisplay
            // 
            tbDisplay.Location = new Point(81, 97);
            tbDisplay.Name = "tbDisplay";
            tbDisplay.Size = new Size(629, 27);
            tbDisplay.TabIndex = 1;
            // 
            // btOK
            // 
            btOK.Location = new Point(505, 170);
            btOK.Name = "btOK";
            btOK.Size = new Size(92, 45);
            btOK.TabIndex = 2;
            btOK.Text = "OK";
            btOK.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            btCancel.Location = new Point(618, 170);
            btCancel.Name = "btCancel";
            btCancel.Size = new Size(92, 45);
            btCancel.TabIndex = 3;
            btCancel.Text = "Clear";
            btCancel.UseVisualStyleBackColor = true;
            btCancel.Click += btClear_Click;
            // 
            // Bai13
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btCancel);
            Controls.Add(btOK);
            Controls.Add(tbDisplay);
            Controls.Add(cb_Faculty);
            Name = "Bai13";
            Text = "Form1";
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