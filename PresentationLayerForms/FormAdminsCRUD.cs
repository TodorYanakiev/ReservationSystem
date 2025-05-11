using BusinessLogic.Services;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayerForms
{
    public partial class FormAdminsCRUD : Form
    {
        private readonly UserService userService;
        private bool isEditing = false;
        private User? selectedUser = null;

        public FormAdminsCRUD()
        {
            InitializeComponent();
            userService = new UserService(new RestaurantDbContext());
            tabControlAdmin.SelectedIndexChanged += TabControlAdmin_SelectedIndexChanged;
        }

        private void TabControlAdmin_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (tabControlAdmin.SelectedTab == tabManageAdmins)
            {
                LoadAllAdmins();
            }
        }

        private void FormAdminsCRUD_Load(object sender, EventArgs e)
        {
            tabControlAdmin.SelectedIndexChanged += (s, e) =>
            {
                if (tabControlAdmin.SelectedTab == tabManageAdmins)
                    LoadAllAdmins();
            };
        }

        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
            User user = new User
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                Role = "Admin"
            };

            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
            {
                MessageBox.Show("Моля въведете потребителско име и парола.");
                return;
            }

            if (userService.AddUser(user))
            {
                MessageBox.Show("Администраторът е добавен успешно.");
                txtUsername.Clear();
                txtPassword.Clear();
            }
            else
            {
                MessageBox.Show("Потребителското име вече съществува.");
            }
        }

        private void LoadAllAdmins()
        {
            flowAdmins.Controls.Clear();
            var admins = userService.GetAllUsers().Where(u => u.Role == "Admin").ToList();

            foreach (var admin in admins)
            {
                flowAdmins.Controls.Add(CreateAdminPanel(admin));
            }
        }

        private Panel CreateAdminPanel(User admin)
        {
            var panel = new Panel
            {
                Size = new Size(340, 200),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };

            Label lblId = new Label { Text = $"ID: {admin.Id}", Location = new Point(10, 10) };

            Label lblUsername = new Label { Text = "Потребител:", Location = new Point(10, 40) };
            TextBox txtUsername = new TextBox
            {
                Text = admin.Username,
                Location = new Point(110, 38),
                Width = 200,
                ReadOnly = true
            };

            Label lblPassword = new Label { Text = "Нова Парола:", Location = new Point(10, 70) };
            TextBox txtPassword = new TextBox
            {
                Text = "",
                Location = new Point(110, 68),
                Width = 200,
                UseSystemPasswordChar = true,
                ReadOnly = true
            };

            Label lblRole = new Label { Text = "Роля: Admin", Location = new Point(10, 100) };

            Button btnUpdate = new Button
            {
                Text = "Редактирай",
                Location = new Point(40, 140),
                Size = new Size(100, 30)
            };

            Button btnDelete = new Button
            {
                Text = "Изтрий",
                Location = new Point(160, 140),
                Size = new Size(100, 30)
            };

            bool isEditing = false;

            btnUpdate.Click += (s, e) =>
            {
                if (!isEditing)
                {
                    isEditing = true;
                    btnUpdate.Text = "Запази";
                    txtUsername.ReadOnly = false;
                    txtPassword.ReadOnly = false;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtUsername.Text))
                    {
                        MessageBox.Show("Потребителското име е задължително.");
                        return;
                    }

                    admin.Username = txtUsername.Text.Trim();

                    if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                        admin.Password = txtPassword.Text.Trim();

                    admin.Role = "Admin";

                    if (userService.UpdateUser(admin))
                    {
                        MessageBox.Show("Промените са записани.");
                        LoadAllAdmins();
                    }
                    else
                    {
                        MessageBox.Show("Грешка при запис или потребителското име вече съществува.");
                    }
                }
            };

            btnDelete.Click += (s, e) =>
            {
                var confirm = MessageBox.Show("Сигурни ли сте, че искате да изтриете този администратор?",
                                              "Потвърждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    userService.DeleteUser(admin.Id);
                    LoadAllAdmins();
                }
            };

            // Add controls
            panel.Controls.Add(lblId);
            panel.Controls.Add(lblUsername);
            panel.Controls.Add(txtUsername);
            panel.Controls.Add(lblPassword);
            panel.Controls.Add(txtPassword);
            panel.Controls.Add(lblRole);
            panel.Controls.Add(btnUpdate);
            panel.Controls.Add(btnDelete);

            return panel;
        }

        private void btnAdminMenu_Click(object sender, EventArgs e)
        {
            FormAdmin formAdmin = new FormAdmin();
            formAdmin.Show();
            this.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            FormStart formStart = new FormStart();
            formStart.Show();
            this.Close();
        }

        private void tabAddAdmin_Click(object sender, EventArgs e)
        {

        }
    }
}

