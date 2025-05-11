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
    public partial class FormLogInAdmin : Form
    {
        private readonly UserService userService;

        public FormLogInAdmin()
        {
            userService = new UserService(new RestaurantDbContext());
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAdminLogIn_Click(object sender, EventArgs e)
        {
            string username = textBoxUsernameAdmin.Text;
            string password = textBoxPasswordAdmin.Text;
            User user = userService.GetUserByUsername(username);
            if (user == null || !userService.ValidateLogin(username, password))
            {
                MessageBox.Show("Invalid username or password!", "Error", MessageBoxButtons.OK);
                return;
            }

            FormAdmin formAdmin = new FormAdmin();
            formAdmin.Show();
            this.Hide();
        }

        private void textBoxUsernameAdmin_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPasswordAdmin_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormStart formStart = new FormStart();
            formStart.Show();
            this.Hide();
        }
    }
}
