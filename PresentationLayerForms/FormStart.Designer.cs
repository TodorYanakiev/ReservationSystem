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
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(159, 56);
            label1.Name = "label1";
            label1.Size = new Size(575, 38);
            label1.TabIndex = 0;
            label1.Text = "Запазете специалния си момент с нас!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(259, 106);
            label2.Name = "label2";
            label2.Size = new Size(372, 38);
            label2.TabIndex = 1;
            label2.Text = "Вашата маса Ви очаква!";
            // 
            // btnUser
            // 
            btnUser.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUser.ForeColor = SystemColors.HotTrack;
            btnUser.Location = new Point(317, 211);
            btnUser.Name = "btnUser";
            btnUser.Size = new Size(251, 100);
            btnUser.TabIndex = 2;
            btnUser.Text = "Резервирай своята маса сега!";
            btnUser.UseVisualStyleBackColor = true;
            btnUser.Click += btnUser_Click;
            // 
            // btnAdmin
            // 
            btnAdmin.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdmin.ForeColor = SystemColors.HotTrack;
            btnAdmin.Location = new Point(283, 341);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(311, 65);
            btnAdmin.TabIndex = 3;
            btnAdmin.Text = "Влез като Администратор";
            btnAdmin.UseVisualStyleBackColor = true;
            btnAdmin.Click += button2_Click;
            // 
            // FormStart
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(923, 497);
            Controls.Add(btnAdmin);
            Controls.Add(btnUser);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormStart";
            Text = "Form1";
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
