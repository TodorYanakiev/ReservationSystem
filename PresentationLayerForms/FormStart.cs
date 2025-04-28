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
            FormAdmin formAdmin = new FormAdmin();
            formAdmin.Show();
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
