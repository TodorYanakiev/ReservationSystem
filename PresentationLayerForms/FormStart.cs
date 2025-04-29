namespace PresentationLayerForms
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormLogInAdmin formLogInAdmin = new FormLogInAdmin();
            formLogInAdmin.Show();
            this.Hide();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            FormReservation formReservation = new FormReservation();
            formReservation.Show();
            this.Hide();
        }
    }
}
