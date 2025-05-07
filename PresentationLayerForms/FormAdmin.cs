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
            List<Reservation> reservations = reservationService.GetAllReservations();
            int size = reservations.Count;
            for (int i = 0; i < size; i++)
            {
                Reservation reservation = reservations[i];
                Panel reservationPanel = new Panel();
                reservationPanel.Size = new Size(600, 60);
                reservationPanel.BackColor = Color.LightGray;
                reservationPanel.Margin = new Padding(10);

                Label lbl = new Label();
                lbl.Text = $"Резервация №{reservation.Id}: {reservation.Name} - {reservation.ReservationDate} " +
                    $"{reservation.OperatingHours.StartTime}ч до {reservation.OperatingHours.EndTime}";
                lbl.AutoSize = true;
                lbl.Location = new Point(10, 10);

                Button btnEdit = new Button();
                btnEdit.Text = "Редактирай";
                btnEdit.Location = new Point(400, 5);
                btnEdit.Size = new Size(100, 30);

                Button btnDelete = new Button();
                btnDelete.Text = "Изтрий";
                btnDelete.Location = new Point(500, 5);
                btnDelete.Size = new Size(80, 30);

                reservationPanel.Controls.Add(lbl);
                reservationPanel.Controls.Add(btnEdit);
                reservationPanel.Controls.Add(btnDelete);

                flowLayoutPanel1.Controls.Add(reservationPanel);
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
