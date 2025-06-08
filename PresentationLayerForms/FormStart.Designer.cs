namespace PresentationLayerForms
{
    partial class FormStart
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            btnUser = new Button();
            btnAdmin = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold | FontStyle.Italic);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(125, 47);
            label1.Name = "label1";
            label1.Size = new Size(808, 54);
            label1.TabIndex = 0;
            label1.Text = "Запазете специалния си момент с нас!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Bold | FontStyle.Italic);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(260, 115);
            label2.Name = "label2";
            label2.Size = new Size(525, 54);
            label2.TabIndex = 1;
            label2.Text = "Вашата маса Ви очаква!";
            label2.Click += label2_Click;
            // 
            // btnUser
            // 
            btnUser.BackColor = Color.Transparent;
            btnUser.FlatAppearance.MouseOverBackColor = Color.Silver;
            btnUser.FlatStyle = FlatStyle.Flat;
            btnUser.Font = new Font("Segoe UI Variable Display", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnUser.ForeColor = Color.DarkOrange;
            btnUser.ImageAlign = ContentAlignment.TopRight;
            btnUser.Location = new Point(279, 218);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(493, 105);
            btnUser.TabIndex = 2;
            btnUser.Text = "Резервирай своята маса сега!";
            btnUser.UseVisualStyleBackColor = false;
            btnUser.Click += btnUser_Click;
            // 
            // btnAdmin
            // 
            btnAdmin.BackColor = Color.Transparent;
            btnAdmin.FlatStyle = FlatStyle.Flat;
            btnAdmin.Font = new Font("Segoe UI Variable Display", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnAdmin.ForeColor = Color.SteelBlue;
            btnAdmin.Location = new Point(315, 353);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(437, 99);
            btnAdmin.TabIndex = 3;
            btnAdmin.Text = "Влез като Администратор";
            btnAdmin.UseVisualStyleBackColor = false;
            btnAdmin.Click += btnAdmin_Click;
            // 
            // FormStart
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources.FormStart;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1420, 572);
            Controls.Add(btnAdmin);
            Controls.Add(btnUser);
            Controls.Add(label2);
            Controls.Add(label1);
            DoubleBuffered = true;
            Name = "FormStart";
            Text = "Form1";
            Load += FormStart_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnUser;
        private Button btnAdmin;
    }
}
