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
using BusinessLogic.Services;

namespace PresentationLayerForms
{
    public partial class FormRestaurantTable : Form
    {
        private readonly RestaurantTableService restaurantTableService;
        public FormRestaurantTable()
        {
            restaurantTableService = new RestaurantTableService(new RestaurantDbContext());
            InitializeComponent();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            RestaurantTable table = new RestaurantTable();
            table.CreatedAt = DateTime.Now;
            try
            {
                table.Number = int.Parse(textBoxTableNumber.Text);
            }
            catch
            {
                MessageBox.Show("Въведете неизползвано число за номер на масата.");
                return;
            }
            if (radioBtnStandart.Checked)
                table.Type = "standard";
            else if (radioButtonVIP.Checked)
                table.Type = "vip";
            else if (radioButtonOutdoor.Checked)
                table.Type = "outdoor";
            else
            {
                MessageBox.Show("Видът на масата е задължителен.");
                return;
            }
            table.Description = richTextBoxTableDescription.Text;

            restaurantTableService.AddTable(table);

            MessageBox.Show("Успешно добавихте нова маса.");
            clearForm();
        }

        private void clearForm()
        {
            textBoxTableNumber.Clear();
            radioBtnStandart.Checked = false;
            radioButtonVIP.Checked = false;
            radioButtonOutdoor.Checked = false;
            richTextBoxTableDescription.Clear();
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void LoadAllTables()
        {
            flowTables.Controls.Clear();
            var tables = restaurantTableService.GetAllTables();

            foreach (var table in tables)
            {
                Panel panel = CreateTablePanel(table, editable: false);
                flowTables.Controls.Add(panel);
            }
        }

        private Panel CreateTablePanel(RestaurantTable table, bool editable, bool isNew = false)
        {
            Label lblTypeValue = null;
            ComboBox cmbType = null;

            Panel panel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(360, 250),
                Margin = new Padding(10),
                Padding = new Padding(10)
            };

            Label lblId = new Label
            {
                Text = isNew ? "Нова маса" : $"ID: {table.Id}",
                Location = new Point(10, 10),
                AutoSize = true
            };

            Label lblNumber = new Label { Text = "Номер:", Location = new Point(10, 40), AutoSize = true };
            TextBox txtNumber = new TextBox
            {
                Text = table.Number.ToString(),
                Location = new Point(100, 38),
                Width = 200,
                ReadOnly = !editable
            };

            Label lblType = new Label { Text = "Тип:", Location = new Point(10, 70), AutoSize = true };

            Control typeControl;
            if (editable)
            {
                cmbType = new ComboBox
                {
                    Location = new Point(100, 68),
                    Width = 200,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Enabled = true
                };
                cmbType.Items.AddRange(new[] { "Standard", "Outdoor", "VIP" });
                cmbType.SelectedItem = table.Type ?? "Standard";
                typeControl = cmbType;
            }
            else
            {
                lblTypeValue = new Label
                {
                    Text = table.Type,
                    Location = new Point(100, 70),
                    AutoSize = true
                };
                typeControl = lblTypeValue;
            }



            Label lblDescription = new Label { Text = "Описание:", Location = new Point(10, 100), AutoSize = true };
            TextBox txtDescription = new TextBox
            {
                Text = table.Description ?? "",
                Location = new Point(100, 98),
                Width = 200,
                ReadOnly = !editable
            };

            Label lblCreated = new Label
            {
                Text = table.CreatedAt != null ? $"Създадено: {table.CreatedAt.Value:dd.MM.yyyy}" : "",
                Location = new Point(10, 130),
                AutoSize = true
            };

            Button btnSave = new Button
            {
                Text = isNew ? "Запази" : "Редактирай",
                Size = new Size(100, 30),
                Location = new Point(60, 180)
            };




            Button btnDelete = null;

            bool isEditing = editable;

            if (!isNew)
            {
                btnDelete = new Button
                {
                    Text = "Изтрий",
                    Size = new Size(100, 30),
                    Location = new Point(180, 180)
                };

                btnDelete.Click += async (sender, e) =>
                {
                    var result = MessageBox.Show("Сигурни ли сте, че искате да изтриете тази маса?", "Потвърждение",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        restaurantTableService.DeleteTable(table.Id);
                        LoadAllTables();
                    }
                };
            }

            btnSave.Click += async (sender, e) =>
            {
                if (!isEditing)
                {
                    isEditing = true;
                    btnSave.Text = "Запази";
                    txtNumber.ReadOnly = false;
                    txtDescription.ReadOnly = false;

                    // Remove label and add dropdown
                    panel.Controls.Remove(lblTypeValue);
                    cmbType = new ComboBox
                    {
                        Location = lblTypeValue.Location,
                        Width = lblTypeValue.Width + 50,
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };
                    cmbType.Items.AddRange(new[] { "Standard", "Outdoor", "VIP" });
                    cmbType.SelectedItem = lblTypeValue.Text;
                    panel.Controls.Add(cmbType);
                }

                else
                {
                    isEditing = false;
                    btnSave.Text = "Редактирай";
                    txtNumber.ReadOnly = true;
                    txtDescription.ReadOnly = true;

                    table.Number = int.TryParse(txtNumber.Text, out int num) ? num : 0;
                    table.Type = cmbType?.SelectedItem?.ToString() ?? "Standard";
                    table.Description = txtDescription.Text;

                    if (isNew)
                    {
                        table.CreatedAt = DateTime.Now;
                        restaurantTableService.AddTable(table);
                    }
                    else
                    {
                        restaurantTableService.UpdateTable(table);
                    }

                    // Replace dropdown with label again
                    panel.Controls.Remove(cmbType);
                    lblTypeValue.Text = table.Type;
                    panel.Controls.Add(lblTypeValue);

                    LoadAllTables();
                }
            };


            // Add all controls
            panel.Controls.Add(lblId);
            panel.Controls.Add(lblNumber);
            panel.Controls.Add(txtNumber);
            panel.Controls.Add(lblType);
            panel.Controls.Add(typeControl);
            panel.Controls.Add(lblDescription);
            panel.Controls.Add(txtDescription);
            panel.Controls.Add(lblCreated);
            panel.Controls.Add(btnSave);
            if (btnDelete != null) panel.Controls.Add(btnDelete);

            return panel;
        }

        private void FormRestaurantTable_Load(object sender, EventArgs e)
        {
            tabControlTables.SelectedIndexChanged += (s, e) =>
            {
                if (tabControlTables.SelectedTab == all)
                {
                    LoadAllTables();
                }
            };
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            FormStart formStart = new FormStart();
            formStart.Show();
            this.Close();
        }

        private void btnAdminMenu_Click(object sender, EventArgs e)
        {
            FormAdmin formAdmin = new FormAdmin();
            formAdmin.Show();
            this.Close();
        }

        private void add_Click(object sender, EventArgs e)
        {

        }
    }
}
