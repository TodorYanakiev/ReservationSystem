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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
            GenerateReservationList();
        }

        private void GenerateReservationList()
        {
            // 5 резервации (замени с реални от базата по-късно)
            for (int i = 1; i <= 5; i++)
            {
                Panel reservationPanel = new Panel();
                reservationPanel.Size = new Size(600, 60);
                reservationPanel.BackColor = Color.LightGray;
                reservationPanel.Margin = new Padding(10);

                Label lbl = new Label();
                lbl.Text = $"Резервация №{i}: Иван Иванов - 12.05.2025 19:00ч";
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
