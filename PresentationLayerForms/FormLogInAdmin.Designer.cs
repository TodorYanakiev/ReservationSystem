namespace PresentationLayerForms
{
    partial class FormLogInAdmin
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
            label1 = new Label();
            label2 = new Label();
            textBoxUsernameAdmin = new TextBox();
            textBoxPasswordAdmin = new TextBox();
            label3 = new Label();
            btnAdminLogIn = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Transparent;
            label1.Location = new Point(413, 46);
            label1.Name = "label1";
            label1.Size = new Size(580, 60);
            label1.TabIndex = 1;
            label1.Text = "Администраторски вход";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Aqua;
            label2.Location = new Point(231, 170);
            label2.Name = "label2";
            label2.Size = new Size(447, 54);
            label2.TabIndex = 2;
            label2.Text = "Потребителско име:";
            // 
            // textBoxUsernameAdmin
            // 
            textBoxUsernameAdmin.Location = new Point(787, 197);
            textBoxUsernameAdmin.Name = "textBoxUsernameAdmin";
            textBoxUsernameAdmin.Size = new Size(287, 27);
            textBoxUsernameAdmin.TabIndex = 3;
            textBoxUsernameAdmin.TextChanged += textBoxUsernameAdmin_TextChanged;
            // 
            // textBoxPasswordAdmin
            // 
            textBoxPasswordAdmin.Location = new Point(787, 309);
            textBoxPasswordAdmin.Name = "textBoxPasswordAdmin";
            textBoxPasswordAdmin.PasswordChar = '*';
            textBoxPasswordAdmin.Size = new Size(287, 27);
            textBoxPasswordAdmin.TabIndex = 5;
            textBoxPasswordAdmin.TextChanged += textBoxPasswordAdmin_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.PaleTurquoise;
            label3.Location = new Point(494, 282);
            label3.Name = "label3";
            label3.Size = new Size(184, 54);
            label3.TabIndex = 4;
            label3.Text = "Парола:";
            label3.Click += label3_Click;
            // 
            // btnAdminLogIn
            // 
            btnAdminLogIn.BackColor = Color.Transparent;
            btnAdminLogIn.FlatStyle = FlatStyle.Flat;
            btnAdminLogIn.Font = new Font("Segoe UI Variable Display", 22.2F, FontStyle.Bold);
            btnAdminLogIn.ForeColor = Color.Thistle;
            btnAdminLogIn.Location = new Point(980, 439);
            btnAdminLogIn.Name = "btnAdminLogIn";
            btnAdminLogIn.Size = new Size(299, 89);
            btnAdminLogIn.TabIndex = 6;
            btnAdminLogIn.Text = "Вход";
            btnAdminLogIn.UseVisualStyleBackColor = false;
            btnAdminLogIn.Click += btnAdminLogIn_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Transparent;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI Variable Display", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.Pink;
            btnBack.Location = new Point(205, 439);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(299, 89);
            btnBack.TabIndex = 7;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // FormLogInAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.FormLogInAdmin;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1420, 572);
            Controls.Add(btnBack);
            Controls.Add(btnAdminLogIn);
            Controls.Add(textBoxPasswordAdmin);
            Controls.Add(label3);
            Controls.Add(textBoxUsernameAdmin);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormLogInAdmin";
            Text = "FormLogInAdmin";
            Load += FormLogInAdmin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBoxUsernameAdmin;
        private TextBox textBoxPasswordAdmin;
        private Label label3;
        private Button btnAdminLogIn;
        private Button btnBack;
    }
}