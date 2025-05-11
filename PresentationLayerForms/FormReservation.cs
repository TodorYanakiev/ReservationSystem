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
    public partial class FormReservation : Form
    {
        private readonly ReservationService _reservationService;
        private readonly SpecialOccasionService _specialOccasionService;
        private readonly OperatingHourService _operatingHourService; // You can create one or use context directly
        private readonly RestaurantTableService _restaurantTableService;

        private DateTime _currentWeekStart;
        private List<OperatingHour> _operatingHours;
        private List<SpecialOccasion> _specialOccasions;
        private int? _selectedTableId;
        private OperatingHour? _selectedOperatingHour;
        private DateTime? _selectedDate;

        public FormReservation(
            ReservationService reservationService,
            SpecialOccasionService specialOccasionService,
            OperatingHourService operatingHoursService)
        {

            InitializeComponent();
            _restaurantTableService = new RestaurantTableService(new RestaurantDbContext());
            _reservationService = reservationService;
            _specialOccasionService = specialOccasionService;
            _operatingHourService = operatingHoursService;
            _currentWeekStart = DateTime.Today.StartOfWeek(DayOfWeek.Monday);
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        /*private void LoadForm()
        {
            var tables = _restaurantTableService.GetAllTables();
            comboBoxTables.DataSource = tables;
            comboBoxTables.DisplayMember = "Name";
            comboBoxTables.ValueMember = "Id";

            comboBoxTables.SelectedIndexChanged += (s, e) =>
            {
                _selectedTableId = (int?)comboBoxTables.SelectedValue;
                if (_selectedTableId.HasValue)
                    _operatingHours = _operatingHourService.GetOperatingHoursByTableId(_selectedTableId.Value);
                LoadCalendar();
            };
            comboBoxTables.SelectedIndex = 0;
            _specialOccasions = _specialOccasionService.GetAllOccasions();
            buttonPrevWeek.Click += (s, e) => { _currentWeekStart = _currentWeekStart.AddDays(-7); LoadCalendar(); };
            buttonNextWeek.Click += (s, e) => { _currentWeekStart = _currentWeekStart.AddDays(7); LoadCalendar(); };
            buttonSubmitReservation.Click += SubmitReservation;
        }*/

        private void LoadForm()
        {
            var tables = _restaurantTableService.GetAllTables()
                .Select(t => new
                {
                    Id = t.Id,
                    Display = $"№{t.Number}, type - {t.Type}, {t.Description}"
                })
                .ToList();

            comboBoxTables.DataSource = tables;
            comboBoxTables.DisplayMember = "Display";
            comboBoxTables.ValueMember = "Id";

            comboBoxTables.SelectedIndexChanged += (s, e) =>
            {
                _selectedTableId = (int?)comboBoxTables.SelectedValue;
                if (_selectedTableId.HasValue)
                    _operatingHours = _operatingHourService.GetOperatingHoursByTableId(_selectedTableId.Value);
                LoadCalendar();
            };

            comboBoxTables.SelectedIndex = 0;
            _specialOccasions = _specialOccasionService.GetAllOccasions();
            buttonPrevWeek.Click += (s, e) => { _currentWeekStart = _currentWeekStart.AddDays(-7); LoadCalendar(); };
            buttonNextWeek.Click += (s, e) => { _currentWeekStart = _currentWeekStart.AddDays(7); LoadCalendar(); };
            buttonSubmitReservation.Click += SubmitReservation;
        }

        private void LoadCalendar()
        {
            if (!_selectedTableId.HasValue) return;
            flowLayoutCalendar.Controls.Clear();

            for (int i = 0; i < 7; i++)
            {
                DateTime day = _currentWeekStart.AddDays(i);
                var column = new FlowLayoutPanel { Width = 120, Height = 600, AutoScroll = true, FlowDirection = FlowDirection.TopDown };
                column.Controls.Add(new Label
                {
                    Text = $"{day:MMM dd}\n{day:dddd}",
                    TextAlign = ContentAlignment.MiddleCenter,
                    Width = 125,
                    Height = 40
                });

                var dayOccasion = _specialOccasions.FirstOrDefault(o => o.TableId == _selectedTableId && o.StartTime.Date <= day.Date && o.EndTime.Date >= day.Date);
                if (dayOccasion != null)
                {
                    column.Controls.Add(new Label
                    {
                        Text = dayOccasion.Description,
                        ForeColor = Color.White,
                        BackColor = Color.Red,
                        Width = 100,
                        Height = 60,
                        TextAlign = ContentAlignment.MiddleCenter
                    });
                }
                else
                {
                    var dayOfWeek = day.DayOfWeek.ToString();
                    var hoursForDay = _operatingHours
                        .Where(h => h.DayOfWeek.Equals(dayOfWeek, StringComparison.OrdinalIgnoreCase))
                        .OrderBy(h => h.StartTime)
                        .ToList();

                    foreach (var hour in hoursForDay)
                    {
                        var isTaken = _reservationService.GetAllReservationsByDateAndTableId(DateOnly.FromDateTime(day), _selectedTableId.Value)
                                        .Any(r => r.OperatingHoursId == hour.Id);

                        var btn = new Button
                        {
                            Text = $"{hour.StartTime:HH\\:mm} - {hour.EndTime:HH\\:mm}",
                            Width = 120,
                            Height = 40,
                            Enabled = !isTaken,
                            BackColor = isTaken ? Color.Gray : Color.LightGreen,
                            Tag = (day, hour)
                        };

                        btn.Click += (s, e) =>
                        {
                            var (selectedDay, selectedHour) = ((DateTime, OperatingHour))((Button)s).Tag!;
                            _selectedDate = selectedDay;
                            _selectedOperatingHour = selectedHour;
                            MessageBox.Show($"Selected {selectedDay:MMM dd} - {selectedHour.StartTime} to {selectedHour.EndTime}", "Time Selected");
                        };

                        column.Controls.Add(btn);
                    }
                }
                flowLayoutCalendar.Controls.Add(column);
            }
        }

        private async void SubmitReservation(object? sender, EventArgs e)
        {
            if (_selectedTableId == null || _selectedOperatingHour == null || _selectedDate == null)
            {
                MessageBox.Show("Please select a time slot.");
                return;
            }

            var reservation = new Reservation
            {
                Name = textBoxName.Text,
                Email = textBoxEmail.Text,
                PhoneNumber = textBoxPhone.Text,
                Notes = textBoxNotes.Text,
                TableId = _selectedTableId,
                ReservationDate = DateOnly.FromDateTime(_selectedDate.Value),
                OperatingHoursId = _selectedOperatingHour.Id
            };

            await _reservationService.CreateReservation(reservation);

            string? userInput = Microsoft.VisualBasic.Interaction.InputBox("Check your email. Enter the verification code:", "Email Verification");
            try
            {
                _reservationService.VerifyReservation(reservation, userInput);
                MessageBox.Show("Reservation confirmed!", "Success");

                textBoxName.Clear();
                textBoxEmail.Clear();
                textBoxPhone.Clear();
                textBoxNotes.Clear();

                _selectedDate = null;
                _selectedOperatingHour = null;

                LoadCalendar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Verification Failed");
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            FormStart formStart = new FormStart();
            formStart.Show();
            this.Close();
        }

        private void buttonPrevWeek_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutCalendar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSubmitReservation_Click(object sender, EventArgs e)
        {

        }
    }

    public static class Extensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }


}

