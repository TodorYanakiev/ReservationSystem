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
    public partial class FormOperatingHours : Form
    {
        private readonly OperatingHourService _operatingHourService;
        private readonly RestaurantTableService _tableService;

        public FormOperatingHours(OperatingHourService operatingHourService)
        {
            InitializeComponent();
            _operatingHourService = operatingHourService;
            _tableService = new RestaurantTableService(new RestaurantDbContext());
            InitializeCreateTab();
            InitializeManageTab();
        }

        private void FormOperatingHours_Load(object sender, EventArgs e)
        {

        }
        private void InitializeCreateTab()
        {
            // Load tables into CheckedListBox
            var tables = _tableService.GetAllTables().Where(t => t.DeletedAt == null).ToList();
            checkedListBoxTables.Items.Clear();
            foreach (var table in tables)
            {
                checkedListBoxTables.Items.Add(table, false);
            }

            // Load days of the week
            checkedListBoxDays.Items.Clear();
            foreach (var day in Enum.GetNames(typeof(DayOfWeek)))
            {
                checkedListBoxDays.Items.Add(day, false);
            }

            // Setup time slots grid
            dataGridTimeSlots.Columns.Clear();
            dataGridTimeSlots.Columns.Add("StartTime", "Start Time");
            dataGridTimeSlots.Columns.Add("EndTime", "End Time");

            dataGridTimeSlots.Columns["StartTime"].ValueType = typeof(TimeSpan);
            dataGridTimeSlots.Columns["EndTime"].ValueType = typeof(TimeSpan);
        }

        private void InitializeManageTab()
        {
            RefreshOperatingHourGrid();
        }

        private void RefreshOperatingHourGrid()
        {
            var allOH = _operatingHourService.GetAllOperatingHours();
            dataGridOperatingHours.DataSource = allOH.Select(oh => new
            {
                oh.Id,
                oh.DayOfWeek,
                StartTime = oh.StartTime.ToString("HH:mm"),
                EndTime = oh.EndTime.ToString("HH:mm"),
                Table = $"№{oh.Table.Number}, {oh.Table.Type}, {oh.Table.Description}"
            }).ToList();
        }

        private void buttonAddTimeSlot_Click(object sender, EventArgs e)
        {
            dataGridTimeSlots.Rows.Add();
        }

        private void buttonCreateOH_Click(object sender, EventArgs e)
        {
            try
            {
                var days = checkedListBoxDays.CheckedItems.Cast<string>().ToList();
                var tables = checkedListBoxTables.CheckedItems.Cast<RestaurantTable>().Select(t => t.Id).ToList();
                var startTimes = new List<TimeOnly>();
                var endTimes = new List<TimeOnly>();

                foreach (DataGridViewRow row in dataGridTimeSlots.Rows)
                {
                    if (row.IsNewRow) continue;

                    var startStr = row.Cells["StartTime"].Value?.ToString();
                    var endStr = row.Cells["EndTime"].Value?.ToString();

                    if (!TimeOnly.TryParse(startStr, out var start) || !TimeOnly.TryParse(endStr, out var end))
                        throw new Exception("Invalid time format in one of the time slots.");

                    startTimes.Add(start);
                    endTimes.Add(end);
                }

                if (days.Count == 0 || tables.Count == 0 || startTimes.Count == 0)
                    throw new Exception("Select at least one day, one table, and add time slots.");

                _operatingHourService.CreateMultipleOperatingHours(days, startTimes, endTimes, tables);
                MessageBox.Show("Operating hours created.");
                InitializeCreateTab();
                RefreshOperatingHourGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void buttonDeleteOH_Click(object sender, EventArgs e)
        {
            if (dataGridOperatingHours.CurrentRow == null) return;

            int id = (int)dataGridOperatingHours.CurrentRow.Cells["Id"].Value;
            var hour = _operatingHourService.GetAllOperatingHours().FirstOrDefault(h => h.Id == id);

            if (hour == null) return;

            var confirm = MessageBox.Show("Are you sure you want to delete this operating hour?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                _ = _operatingHourService.DeleteOperatingHour(hour);
                RefreshOperatingHourGrid();
            }
        }

        private void buttonEditOH_Click(object sender, EventArgs e)
        {
            if (dataGridOperatingHours.CurrentRow == null) return;

            int id = (int)dataGridOperatingHours.CurrentRow.Cells["Id"].Value;
            var hour = _operatingHourService.GetAllOperatingHours().FirstOrDefault(h => h.Id == id);
            if (hour == null) return;

            // Example: update time range
            string newStart = Microsoft.VisualBasic.Interaction.InputBox("New start time (HH:mm):", "Edit", hour.StartTime.ToString("HH:mm"));
            string newEnd = Microsoft.VisualBasic.Interaction.InputBox("New end time (HH:mm):", "Edit", hour.EndTime.ToString("HH:mm"));

            if (TimeOnly.TryParse(newStart, out var start) && TimeOnly.TryParse(newEnd, out var end))
            {
                hour.StartTime = start;
                hour.EndTime = end;
                try
                {
                    _operatingHourService.UpdateOperatingHour(hour);
                    MessageBox.Show("Updated successfully.");
                    RefreshOperatingHourGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Invalid time format.");
            }
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
    }
}
