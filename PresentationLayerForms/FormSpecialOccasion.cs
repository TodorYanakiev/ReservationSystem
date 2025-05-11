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
    public partial class FormSpecialOccasion : Form
    {
        private readonly RestaurantTableService tableService;
        private readonly SpecialOccasionService specialOccasionService;

        public FormSpecialOccasion()
        {
            tableService = new RestaurantTableService(new RestaurantDbContext());
            specialOccasionService = new SpecialOccasionService(new RestaurantDbContext());
            InitializeComponent();
        }

        private void FormSpecialOccasion_Load(object sender, EventArgs e)
        {
            LoadTablesToComboBox();
            LoadAllOccasions();
        }

        private void LoadTablesToComboBox()
        {
            var tables = tableService.GetAllTables();
            cmbTables.DataSource = tables;
            cmbTables.DisplayMember = "Number";
            cmbTables.ValueMember = "Id";
        }

        private void btnAddOccasion_Click(object sender, EventArgs e)
        {
            if (cmbTables.SelectedItem is not RestaurantTable selectedTable)
            {
                MessageBox.Show("Моля изберете маса.");
                return;
            }

            var occasion = new SpecialOccasion
            {
                TableId = selectedTable.Id,
                StartTime = dtpStartTime.Value,
                EndTime = dtpEndTime.Value,
                Description = txtOccasionDescription.Text.Trim()
            };

            if (occasion.EndTime <= occasion.StartTime)
            {
                MessageBox.Show("Краят трябва да е след началото.");
                return;
            }

            specialOccasionService.AddSpecialOccasion(occasion);
            MessageBox.Show("Събитието е добавено успешно.");
            txtOccasionDescription.Clear();
            LoadAllOccasions();
        }

        private void LoadAllOccasions()
        {
            flowOccasions.Controls.Clear();
            var occasions = specialOccasionService.GetAllOccasions();

            foreach (var occasion in occasions)
            {
                flowOccasions.Controls.Add(CreateOccasionPanel(occasion));
            }
        }

        private Panel CreateOccasionPanel(SpecialOccasion occasion)
        {
            var panel = new Panel
            {
                Size = new Size(400, 240),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };

            Label lblId = new Label { Text = $"ID: {occasion.Id}", Location = new Point(10, 10) };

            Label lblTable = new Label { Text = $"Маса: {occasion.Table?.Number}", Location = new Point(10, 35) };

            DateTimePicker dtpStart = new DateTimePicker { Value = occasion.StartTime, Location = new Point(10, 60), Width = 180, Enabled = false };
            DateTimePicker dtpEnd = new DateTimePicker { Value = occasion.EndTime, Location = new Point(200, 60), Width = 180, Enabled = false };
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.CustomFormat = "dd.MM.yyyy HH:mm";

            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = "dd.MM.yyyy HH:mm";

            TextBox txtDescription = new TextBox { Text = occasion.Description, Location = new Point(10, 100), Width = 370, ReadOnly = true };

            Button btnUpdate = new Button { Text = "Редактирай", Location = new Point(50, 150), Size = new Size(100, 30) };
            Button btnDelete = new Button { Text = "Изтрий", Location = new Point(200, 150), Size = new Size(100, 30) };

            bool isEditing = false;

            btnUpdate.Click += (s, e) =>
            {
                if (!isEditing)
                {
                    isEditing = true;
                    btnUpdate.Text = "Запази";
                    dtpStart.Enabled = true;
                    dtpEnd.Enabled = true;
                    txtDescription.ReadOnly = false;
                }
                else
                {
                    if (dtpEnd.Value <= dtpStart.Value)
                    {
                        MessageBox.Show("Краят трябва да е след началото.");
                        return;
                    }

                    occasion.StartTime = dtpStart.Value;
                    occasion.EndTime = dtpEnd.Value;
                    occasion.Description = txtDescription.Text.Trim();

                    if (specialOccasionService.UpdateOccasion(occasion))
                    {
                        MessageBox.Show("Обновено успешно.");
                        LoadAllOccasions();
                    }
                    else
                    {
                        MessageBox.Show("Грешка при обновяване.");
                    }
                }
            };

            btnDelete.Click += (s, e) =>
            {
                var confirm = MessageBox.Show("Сигурни ли сте?", "Потвърждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    specialOccasionService.DeleteOccasion(occasion.Id);
                    LoadAllOccasions();
                }
            };

            panel.Controls.Add(lblId);
            panel.Controls.Add(lblTable);
            panel.Controls.Add(dtpStart);
            panel.Controls.Add(dtpEnd);
            panel.Controls.Add(txtDescription);
            panel.Controls.Add(btnUpdate);
            panel.Controls.Add(btnDelete);

            return panel;
        }

        private void btnHomeMenu_Click(object sender, EventArgs e)
        {
            FormStart form = new FormStart();
            form.Show();
            this.Close();
        }

        private void btnAdminMenu_Click(object sender, EventArgs e)
        {
            FormAdmin form = new FormAdmin();
            form.Show();
            this.Close();
        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
