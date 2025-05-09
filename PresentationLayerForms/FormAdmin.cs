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

        private void GenerateReservationList(
            DateOnly? startDate = null,
            DateOnly? endDate = null,
            DateOnly? exactDate = null,
            int? tableId = null,
            bool? isVerified = null,
            bool? includePassed = null,
            bool? includeCancelled = null)
        {
            flowLayoutPanel1.Controls.Clear();

            List<Reservation> reservations = reservationService.GetReservations(
                startDate: startDate,
                endDate: endDate,
                exactDate: exactDate,
                tableId: tableId,
                isVerified: isVerified,
                includePassed: includePassed,
                includeCancelled: includeCancelled
            );

            foreach (var reservation in reservations)
            {
                Panel reservationPanel = new Panel();
                reservationPanel.Size = new Size(600, 60);
                reservationPanel.BackColor = Color.LightGray;
                reservationPanel.Margin = new Padding(10);

                Label lbl = new Label();
                lbl.Text = $"Резервация №{reservation.Id}: {reservation.Name} - {reservation.ReservationDate} " +
                           $"{reservation.OperatingHours?.StartTime}ч до {reservation.OperatingHours?.EndTime}ч";
                lbl.AutoSize = true;
                lbl.Location = new Point(10, 10);

                Button btnEdit = new Button();
                btnEdit.Text = "Редактирай";
                btnEdit.Location = new Point(400, 5);
                btnEdit.Size = new Size(100, 30);
                btnEdit.Tag = reservation.Id;

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
            FormAdminsCRUD formAdminsCRUD = new FormAdminsCRUD();
            formAdminsCRUD.Show();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStartDate.Checked)
            {
                chkEndDate.Checked = false;
                chkExactDate.Checked = false;

                dtpStartDate.Visible = true;
                dtpEndDate.Visible = false;
                dtpExactDate.Visible = false;
            }
            else
            {
                dtpStartDate.Visible = false;
            }
        }

        private void chkEndDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEndDate.Checked)
            {
                chkStartDate.Checked = false;
                chkExactDate.Checked = false;

                dtpEndDate.Visible = true;
                dtpStartDate.Visible = false;
                dtpExactDate.Visible = false;
            }
            else
            {
                dtpEndDate.Visible = false;
            }
        }

        private void chkExactDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExactDate.Checked)
            {
                chkStartDate.Checked = false;
                chkEndDate.Checked = false;

                dtpExactDate.Visible = true;
                dtpStartDate.Visible = false;
                dtpEndDate.Visible = false;
            }
            else
            {
                dtpExactDate.Visible = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateOnly? startDate = chkStartDate.Checked ? DateOnly.FromDateTime(dtpStartDate.Value.Date) : null;
            DateOnly? endDate = chkEndDate.Checked ? DateOnly.FromDateTime(dtpEndDate.Value.Date) : null;
            DateOnly? exactDate = chkExactDate.Checked ? DateOnly.FromDateTime(dtpExactDate.Value.Date) : null;

            bool? isVerified = chkIsVerified.CheckState == CheckState.Indeterminate ? null : chkIsVerified.Checked;
            bool? includeCancelled = chkIncludeCancelled.CheckState == CheckState.Indeterminate ? null : chkIncludeCancelled.Checked;
            bool? includePassed = chkIncludePassed.CheckState == CheckState.Indeterminate ? null : chkIncludePassed.Checked;

            GenerateReservationList(
                startDate: startDate,
                endDate: endDate,
                exactDate: exactDate,
                isVerified: isVerified,
                includeCancelled: includeCancelled,
                includePassed: includePassed
            );
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormRestaurantTable formAddTable = new FormRestaurantTable();
            formAddTable.Show();
            this.Close();
        }
    }
}
