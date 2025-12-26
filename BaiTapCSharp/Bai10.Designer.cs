namespace WinFormsApp_Article
{
    partial class Bai10
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
            tbDisplay = new TextBox();
            bt0 = new Button();
            bt1 = new Button();
            bt2 = new Button();
            bt3 = new Button();
            btMul = new Button();
            btDot = new Button();
            btEquals = new Button();
            btPlus = new Button();
            SuspendLayout();
            // 
            // tbDisplay
            // 
            tbDisplay.Location = new Point(300, 95);
            tbDisplay.Multiline = true;
            tbDisplay.Name = "tbDisplay";
            tbDisplay.Size = new Size(478, 70);
            tbDisplay.TabIndex = 0;
            // 
            // bt0
            // 
            bt0.Location = new Point(300, 180);
            bt0.Name = "bt0";
            bt0.Size = new Size(98, 69);
            bt0.TabIndex = 1;
            bt0.Text = "0";
            bt0.UseVisualStyleBackColor = true;
            // 
            // bt1
            // 
            bt1.Location = new Point(428, 180);
            bt1.Name = "bt1";
            bt1.Size = new Size(98, 69);
            bt1.TabIndex = 2;
            bt1.Text = "1";
            bt1.UseVisualStyleBackColor = true;
            // 
            // bt2
            // 
            bt2.Location = new Point(555, 180);
            bt2.Name = "bt2";
            bt2.Size = new Size(98, 69);
            bt2.TabIndex = 3;
            bt2.Text = "2";
            bt2.UseVisualStyleBackColor = true;
            // 
            // bt3
            // 
            bt3.Location = new Point(680, 180);
            bt3.Name = "bt3";
            bt3.Size = new Size(98, 69);
            bt3.TabIndex = 4;
            bt3.Text = "3";
            bt3.UseVisualStyleBackColor = true;
            // 
            // btMul
            // 
            btMul.Location = new Point(428, 271);
            btMul.Name = "btMul";
            btMul.Size = new Size(98, 69);
            btMul.TabIndex = 5;
            btMul.Text = "*";
            btMul.UseVisualStyleBackColor = true;
            // 
            // btDot
            // 
            btDot.Location = new Point(555, 271);
            btDot.Name = "btDot";
            btDot.Size = new Size(98, 69);
            btDot.TabIndex = 6;
            btDot.Text = ".";
            btDot.UseVisualStyleBackColor = true;
            // 
            // btEquals
            // 
            btEquals.Location = new Point(680, 271);
            btEquals.Name = "btEquals";
            btEquals.Size = new Size(98, 69);
            btEquals.TabIndex = 7;
            btEquals.Text = "=";
            btEquals.UseVisualStyleBackColor = true;
            // 
            // btPlus
            // 
            btPlus.Location = new Point(300, 271);
            btPlus.Name = "btPlus";
            btPlus.Size = new Size(98, 69);
            btPlus.TabIndex = 8;
            btPlus.Text = "+";
            btPlus.UseVisualStyleBackColor = true;
            // 
            // Bai10
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btPlus);
            Controls.Add(btEquals);
            Controls.Add(btDot);
            Controls.Add(btMul);
            Controls.Add(bt3);
            Controls.Add(bt2);
            Controls.Add(bt1);
            Controls.Add(bt0);
            Controls.Add(tbDisplay);
            Name = "Bai10";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbDisplay;
        private Button bt0;
        private Button bt1;
        private Button bt2;
        private Button bt3;
        private Button btMul;
        private Button btDot;
        private Button btEquals;
        private Button btPlus;
    }
}