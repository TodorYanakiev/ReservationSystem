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
        public FormLogInAdmin()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAdminLogIn_Click(object sender, EventArgs e)
        {
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
    }
}
