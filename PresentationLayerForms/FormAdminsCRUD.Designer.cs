namespace PresentationLayerForms
{
    partial class FormAdminsCRUD
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
            tabControlAdmin = new TabControl();
            tabAddAdmin = new TabPage();
            txtPassword = new TextBox();
            btnAddAdmin = new Button();
            lblPassword = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            tabManageAdmins = new TabPage();
            flowAdmins = new FlowLayoutPanel();
            btnAdminMenu = new Button();
            btnHome = new Button();
            label1 = new Label();
            tabControlAdmin.SuspendLayout();
            tabAddAdmin.SuspendLayout();
            tabManageAdmins.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlAdmin
            // 
            tabControlAdmin.Controls.Add(tabAddAdmin);
            tabControlAdmin.Controls.Add(tabManageAdmins);
            tabControlAdmin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            tabControlAdmin.Location = new Point(133, 103);
            tabControlAdmin.Name = "tabControlAdmin";
            tabControlAdmin.SelectedIndex = 0;
            tabControlAdmin.Size = new Size(1159, 349);
            tabControlAdmin.TabIndex = 0;
            // 
            // tabAddAdmin
            // 
            tabAddAdmin.Controls.Add(label1);
            tabAddAdmin.Controls.Add(txtPassword);
            tabAddAdmin.Controls.Add(btnAddAdmin);
            tabAddAdmin.Controls.Add(lblPassword);
            tabAddAdmin.Controls.Add(txtUsername);
            tabAddAdmin.Controls.Add(lblUsername);
            tabAddAdmin.Location = new Point(4, 37);
            tabAddAdmin.Name = "tabAddAdmin";
            tabAddAdmin.Padding = new Padding(3);
            tabAddAdmin.Size = new Size(1151, 308);
            tabAddAdmin.TabIndex = 0;
            tabAddAdmin.Text = "Добави";
            tabAddAdmin.UseVisualStyleBackColor = true;
            tabAddAdmin.Click += tabAddAdmin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(455, 215);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(351, 34);
            txtPassword.TabIndex = 4;
            // 
            // btnAddAdmin
            // 
            btnAddAdmin.Font = new Font("Segoe UI Variable Text", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddAdmin.ForeColor = Color.Coral;
            btnAddAdmin.Location = new Point(904, 228);
            btnAddAdmin.Name = "btnAddAdmin";
            btnAddAdmin.Size = new Size(202, 55);
            btnAddAdmin.TabIndex = 3;
            btnAddAdmin.Text = "Добави";
            btnAddAdmin.UseVisualStyleBackColor = true;
            btnAddAdmin.Click += btnAddAdmin_Click;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            lblPassword.ForeColor = Color.DarkGreen;
            lblPassword.Location = new Point(257, 211);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(127, 38);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Парола:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(455, 140);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(351, 34);
            txtUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            lblUsername.ForeColor = Color.DarkGreen;
            lblUsername.Location = new Point(87, 140);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(297, 38);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Потребителско име:";
            // 
            // tabManageAdmins
            // 
            tabManageAdmins.Controls.Add(flowAdmins);
            tabManageAdmins.Location = new Point(4, 37);
            tabManageAdmins.Name = "tabManageAdmins";
            tabManageAdmins.Padding = new Padding(3);
            tabManageAdmins.Size = new Size(1151, 308);
            tabManageAdmins.TabIndex = 1;
            tabManageAdmins.Text = "Виж администратори";
            tabManageAdmins.UseVisualStyleBackColor = true;
            // 
            // flowAdmins
            // 
            flowAdmins.AutoScroll = true;
            flowAdmins.Location = new Point(6, 8);
            flowAdmins.Name = "flowAdmins";
            flowAdmins.Size = new Size(1139, 294);
            flowAdmins.TabIndex = 0;
            // 
            // btnAdminMenu
            // 
            btnAdminMenu.BackColor = Color.Transparent;
            btnAdminMenu.FlatStyle = FlatStyle.Flat;
            btnAdminMenu.Font = new Font("Segoe UI Variable Display", 13.8F, FontStyle.Bold);
            btnAdminMenu.ForeColor = Color.DarkGreen;
            btnAdminMenu.Location = new Point(780, 472);
            btnAdminMenu.Margin = new Padding(3, 4, 3, 4);
            btnAdminMenu.Name = "btnAdminMenu";
            btnAdminMenu.Size = new Size(347, 77);
            btnAdminMenu.TabIndex = 14;
            btnAdminMenu.Text = "Администраторско меню";
            btnAdminMenu.UseVisualStyleBackColor = false;
            btnAdminMenu.Click += btnAdminMenu_Click;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.Transparent;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI Variable Display", 13.8F, FontStyle.Bold);
            btnHome.ForeColor = Color.DarkGreen;
            btnHome.Location = new Point(341, 472);
            btnHome.Margin = new Padding(3, 4, 3, 4);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(347, 77);
            btnHome.TabIndex = 13;
            btnHome.Text = "Начално меню";
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold | FontStyle.Italic);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(341, 32);
            label1.Name = "label1";
            label1.Size = new Size(508, 46);
            label1.TabIndex = 29;
            label1.Text = "Добави нов администратор";
            // 
            // FormAdminsCRUD
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.FormAdminsCRUD;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1420, 572);
            Controls.Add(btnAdminMenu);
            Controls.Add(btnHome);
            Controls.Add(tabControlAdmin);
            Name = "FormAdminsCRUD";
            Text = "New admin";
            Load += FormAdminsCRUD_Load;
            tabControlAdmin.ResumeLayout(false);
            tabAddAdmin.ResumeLayout(false);
            tabAddAdmin.PerformLayout();
            tabManageAdmins.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlAdmin;
        private TabPage tabAddAdmin;
        private TabPage tabManageAdmins;
        private Button btnAddAdmin;
        private Label lblPassword;
        private TextBox txtUsername;
        private Label lblUsername;
        private TextBox txtPassword;
        private FlowLayoutPanel flowAdmins;
        private Button btnAdminMenu;
        private Button btnHome;
        private Label label1;
    }
}