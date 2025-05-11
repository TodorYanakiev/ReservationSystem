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
            tabControlAdmin.SuspendLayout();
            tabAddAdmin.SuspendLayout();
            tabManageAdmins.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlAdmin
            // 
            tabControlAdmin.Controls.Add(tabAddAdmin);
            tabControlAdmin.Controls.Add(tabManageAdmins);
            tabControlAdmin.Location = new Point(0, 0);
            tabControlAdmin.Margin = new Padding(3, 2, 3, 2);
            tabControlAdmin.Name = "tabControlAdmin";
            tabControlAdmin.SelectedIndex = 0;
            tabControlAdmin.Size = new Size(463, 328);
            tabControlAdmin.TabIndex = 0;
            // 
            // tabAddAdmin
            // 
            tabAddAdmin.Controls.Add(txtPassword);
            tabAddAdmin.Controls.Add(btnAddAdmin);
            tabAddAdmin.Controls.Add(lblPassword);
            tabAddAdmin.Controls.Add(txtUsername);
            tabAddAdmin.Controls.Add(lblUsername);
            tabAddAdmin.Location = new Point(4, 24);
            tabAddAdmin.Margin = new Padding(3, 2, 3, 2);
            tabAddAdmin.Name = "tabAddAdmin";
            tabAddAdmin.Padding = new Padding(3, 2, 3, 2);
            tabAddAdmin.Size = new Size(455, 300);
            tabAddAdmin.TabIndex = 0;
            tabAddAdmin.Text = "Добави";
            tabAddAdmin.UseVisualStyleBackColor = true;
            tabAddAdmin.Click += tabAddAdmin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(74, 96);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(110, 23);
            txtPassword.TabIndex = 4;
            // 
            // btnAddAdmin
            // 
            btnAddAdmin.Location = new Point(7, 147);
            btnAddAdmin.Margin = new Padding(3, 2, 3, 2);
            btnAddAdmin.Name = "btnAddAdmin";
            btnAddAdmin.Size = new Size(222, 22);
            btnAddAdmin.TabIndex = 3;
            btnAddAdmin.Text = "Add new admin";
            btnAddAdmin.UseVisualStyleBackColor = true;
            btnAddAdmin.Click += btnAddAdmin_Click;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(5, 101);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(93, 40);
            txtUsername.Margin = new Padding(3, 2, 3, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(110, 23);
            txtUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(7, 40);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(63, 15);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username:";
            // 
            // tabManageAdmins
            // 
            tabManageAdmins.Controls.Add(flowAdmins);
            tabManageAdmins.Location = new Point(4, 24);
            tabManageAdmins.Margin = new Padding(3, 2, 3, 2);
            tabManageAdmins.Name = "tabManageAdmins";
            tabManageAdmins.Padding = new Padding(3, 2, 3, 2);
            tabManageAdmins.Size = new Size(455, 300);
            tabManageAdmins.TabIndex = 1;
            tabManageAdmins.Text = "Виж администратори";
            tabManageAdmins.UseVisualStyleBackColor = true;
            // 
            // flowAdmins
            // 
            flowAdmins.AutoScroll = true;
            flowAdmins.Location = new Point(7, 6);
            flowAdmins.Margin = new Padding(3, 2, 3, 2);
            flowAdmins.Name = "flowAdmins";
            flowAdmins.Size = new Size(427, 293);
            flowAdmins.TabIndex = 0;
            // 
            // btnAdminMenu
            // 
            btnAdminMenu.Location = new Point(285, 458);
            btnAdminMenu.Name = "btnAdminMenu";
            btnAdminMenu.Size = new Size(121, 38);
            btnAdminMenu.TabIndex = 14;
            btnAdminMenu.Text = "Меню на администратор";
            btnAdminMenu.UseVisualStyleBackColor = true;
            btnAdminMenu.Click += btnAdminMenu_Click;
            // 
            // btnHome
            // 
            btnHome.Location = new Point(39, 458);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(172, 38);
            btnHome.TabIndex = 13;
            btnHome.Text = "Начално меню";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // FormAdminsCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(545, 534);
            Controls.Add(btnAdminMenu);
            Controls.Add(btnHome);
            Controls.Add(tabControlAdmin);
            Margin = new Padding(3, 2, 3, 2);
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
    }
}