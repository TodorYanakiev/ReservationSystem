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
            tabControlAdmin.Location = new Point(41, 109);
            tabControlAdmin.Name = "tabControlAdmin";
            tabControlAdmin.SelectedIndex = 0;
            tabControlAdmin.Size = new Size(840, 289);
            tabControlAdmin.TabIndex = 0;
            // 
            // tabAddAdmin
            // 
            tabAddAdmin.Controls.Add(txtPassword);
            tabAddAdmin.Controls.Add(btnAddAdmin);
            tabAddAdmin.Controls.Add(lblPassword);
            tabAddAdmin.Controls.Add(txtUsername);
            tabAddAdmin.Controls.Add(lblUsername);
            tabAddAdmin.Location = new Point(4, 29);
            tabAddAdmin.Name = "tabAddAdmin";
            tabAddAdmin.Padding = new Padding(3);
            tabAddAdmin.Size = new Size(832, 256);
            tabAddAdmin.TabIndex = 0;
            tabAddAdmin.Text = "Добави";
            tabAddAdmin.UseVisualStyleBackColor = true;
            tabAddAdmin.Click += tabAddAdmin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(85, 128);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(125, 27);
            txtPassword.TabIndex = 4;
            // 
            // btnAddAdmin
            // 
            btnAddAdmin.Location = new Point(8, 196);
            btnAddAdmin.Name = "btnAddAdmin";
            btnAddAdmin.Size = new Size(254, 29);
            btnAddAdmin.TabIndex = 3;
            btnAddAdmin.Text = "Add new admin";
            btnAddAdmin.UseVisualStyleBackColor = true;
            btnAddAdmin.Click += btnAddAdmin_Click;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(6, 135);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 20);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(106, 53);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(125, 27);
            txtUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(8, 53);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(78, 20);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username:";
            // 
            // tabManageAdmins
            // 
            tabManageAdmins.Controls.Add(flowAdmins);
            tabManageAdmins.Location = new Point(4, 29);
            tabManageAdmins.Name = "tabManageAdmins";
            tabManageAdmins.Padding = new Padding(3);
            tabManageAdmins.Size = new Size(521, 404);
            tabManageAdmins.TabIndex = 1;
            tabManageAdmins.Text = "Виж администратори";
            tabManageAdmins.UseVisualStyleBackColor = true;
            // 
            // flowAdmins
            // 
            flowAdmins.AutoScroll = true;
            flowAdmins.Location = new Point(8, 8);
            flowAdmins.Name = "flowAdmins";
            flowAdmins.Size = new Size(488, 391);
            flowAdmins.TabIndex = 0;
            // 
            // btnAdminMenu
            // 
            btnAdminMenu.Location = new Point(653, 433);
            btnAdminMenu.Margin = new Padding(3, 4, 3, 4);
            btnAdminMenu.Name = "btnAdminMenu";
            btnAdminMenu.Size = new Size(138, 51);
            btnAdminMenu.TabIndex = 14;
            btnAdminMenu.Text = "Меню на администратор";
            btnAdminMenu.UseVisualStyleBackColor = true;
            btnAdminMenu.Click += btnAdminMenu_Click;
            // 
            // btnHome
            // 
            btnHome.Location = new Point(130, 424);
            btnHome.Margin = new Padding(3, 4, 3, 4);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(197, 51);
            btnHome.TabIndex = 13;
            btnHome.Text = "Начално меню";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // FormAdminsCRUD
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(923, 497);
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
    }
}