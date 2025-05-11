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
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Transparent;
            label1.Location = new Point(200, 50);
            label1.Name = "label1";
            label1.Size = new Size(491, 50);
            label1.TabIndex = 1;
            label1.Text = "Администраторски вход";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Aqua;
            label2.Location = new Point(100, 172);
            label2.Name = "label2";
            label2.Size = new Size(318, 38);
            label2.TabIndex = 2;
            label2.Text = "Потребителско име:";
            // 
            // textBoxUsernameAdmin
            // 
            textBoxUsernameAdmin.Location = new Point(490, 174);
            textBoxUsernameAdmin.Name = "textBoxUsernameAdmin";
            textBoxUsernameAdmin.Size = new Size(287, 27);
            textBoxUsernameAdmin.TabIndex = 3;
            textBoxUsernameAdmin.TextChanged += textBoxUsernameAdmin_TextChanged;
            // 
            // textBoxPasswordAdmin
            // 
            textBoxPasswordAdmin.Location = new Point(490, 269);
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
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.PaleTurquoise;
            label3.Location = new Point(278, 258);
            label3.Name = "label3";
            label3.Size = new Size(130, 38);
            label3.TabIndex = 4;
            label3.Text = "Парола:";
            label3.Click += label3_Click;
            // 
            // btnAdminLogIn
            // 
            btnAdminLogIn.BackColor = Color.Transparent;
            btnAdminLogIn.FlatStyle = FlatStyle.Flat;
            btnAdminLogIn.Font = new Font("Segoe UI Variable Display", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdminLogIn.ForeColor = Color.Thistle;
            btnAdminLogIn.Location = new Point(650, 370);
            btnAdminLogIn.Name = "btnAdminLogIn";
            btnAdminLogIn.Size = new Size(199, 64);
            btnAdminLogIn.TabIndex = 6;
            btnAdminLogIn.Text = "Вход";
            btnAdminLogIn.UseVisualStyleBackColor = false;
            btnAdminLogIn.Click += btnAdminLogIn_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Transparent;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI Variable Display", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.Pink;
            btnBack.Location = new Point(80, 370);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(199, 64);
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
            ClientSize = new Size(923, 497);
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