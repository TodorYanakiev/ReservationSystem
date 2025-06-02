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
            tabControlAdmin.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            tabControlAdmin.Location = new Point(41, 92);
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
            tabAddAdmin.Location = new Point(4, 32);
            tabAddAdmin.Name = "tabAddAdmin";
            tabAddAdmin.Padding = new Padding(3);
            tabAddAdmin.Size = new Size(832, 253);
            tabAddAdmin.TabIndex = 0;
            tabAddAdmin.Text = "Добави";
            tabAddAdmin.UseVisualStyleBackColor = true;
            tabAddAdmin.Click += tabAddAdmin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(361, 114);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(351, 30);
            txtPassword.TabIndex = 4;
            // 
            // btnAddAdmin
            // 
            btnAddAdmin.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold);
            btnAddAdmin.Location = new Point(608, 180);
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
            lblPassword.Font = new Font("Segoe UI", 14.2F, FontStyle.Bold | FontStyle.Italic);
            lblPassword.Location = new Point(43, 109);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(110, 32);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Парола:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(361, 39);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(351, 30);
            txtUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 14.2F, FontStyle.Bold | FontStyle.Italic);
            lblUsername.Location = new Point(43, 34);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(268, 32);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Потребителско име:";
            // 
            // tabManageAdmins
            // 
            tabManageAdmins.Controls.Add(flowAdmins);
            tabManageAdmins.Location = new Point(4, 32);
            tabManageAdmins.Name = "tabManageAdmins";
            tabManageAdmins.Padding = new Padding(3);
            tabManageAdmins.Size = new Size(832, 253);
            tabManageAdmins.TabIndex = 1;
            tabManageAdmins.Text = "Виж администратори";
            tabManageAdmins.UseVisualStyleBackColor = true;
            // 
            // flowAdmins
            // 
            flowAdmins.AutoScroll = true;
            flowAdmins.Location = new Point(6, 8);
            flowAdmins.Name = "flowAdmins";
            flowAdmins.Size = new Size(818, 239);
            flowAdmins.TabIndex = 0;
            // 
            // btnAdminMenu
            // 
            btnAdminMenu.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnAdminMenu.Location = new Point(565, 388);
            btnAdminMenu.Margin = new Padding(3, 4, 3, 4);
            btnAdminMenu.Name = "btnAdminMenu";
            btnAdminMenu.Size = new Size(222, 81);
            btnAdminMenu.TabIndex = 14;
            btnAdminMenu.Text = "Меню на администратор";
            btnAdminMenu.UseVisualStyleBackColor = true;
            btnAdminMenu.Click += btnAdminMenu_Click;
            // 
            // btnHome
            // 
            btnHome.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold);
            btnHome.Location = new Point(134, 388);
            btnHome.Margin = new Padding(3, 4, 3, 4);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(222, 81);
            btnHome.TabIndex = 13;
            btnHome.Text = "Начално меню";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(258, 25);
            label1.Name = "label1";
            label1.Size = new Size(422, 38);
            label1.TabIndex = 29;
            label1.Text = "Добави нов администратор";
            // 
            // FormAdminsCRUD
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(923, 497);
            Controls.Add(label1);
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
            PerformLayout();
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