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
    public partial class FormAdmin : Form
    {
        private readonly ReservationService reservationService;
        public FormAdmin()
        {
            reservationService = new ReservationService(new RestaurantDbContext());
            InitializeComponent();
            GenerateReservationList();
        }

        private void GenerateReservationList()
        {
            flowLayoutPanel1.Controls.Clear();
            List<Reservation> reservations = reservationService.GetAllReservations();
            int size = reservations.Count;
            foreach (var reservation in reservations)
            {
                Panel reservationPanel = new Panel();
                reservationPanel.Size = new Size(600, 60);
                reservationPanel.BackColor = Color.LightGray;
                reservationPanel.Margin = new Padding(10);

                Label lbl = new Label();
                lbl.Text = $"Резервация №{reservation.Id}: {reservation.Name} - {reservation.ReservationDate} " +
                    $"{reservation.OperatingHours.StartTime}ч до {reservation.OperatingHours.EndTime}ч";
                lbl.AutoSize = true;
                lbl.Location = new Point(10, 10);

                Button btnEdit = new Button();
                btnEdit.Text = "Редактирай";
                btnEdit.Location = new Point(400, 5);
                btnEdit.Size = new Size(100, 30);
                btnEdit.Tag = reservation.Id; // Store reservation ID in the button tag
                //btnEdit.Click += BtnEdit_Click;

                Button btnDelete = new Button();
                btnDelete.Text = "Изтрий";
                btnDelete.Location = new Point(500, 5);
                btnDelete.Size = new Size(80, 30);
                btnDelete.Tag = reservation.Id;
                btnDelete.Click += BtnDelete_Click;

                reservationPanel.Controls.Add(lbl);
                reservationPanel.Controls.Add(btnEdit);
                reservationPanel.Controls.Add(btnDelete);

                flowLayoutPanel1.Controls.Add(reservationPanel);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            int reservationId = (int)((Button)sender).Tag;

            var result = MessageBox.Show("Сигурни ли сте, че искате да изтриете резервацията?", "Потвърждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Reservation reservation = reservationService.GetReservationById(reservationId);
                await reservationService.DeleteReservation(reservation);
                GenerateReservationList();
            }
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNewAdminAccount_Click(object sender, EventArgs e)
        {

        }
    }
}
