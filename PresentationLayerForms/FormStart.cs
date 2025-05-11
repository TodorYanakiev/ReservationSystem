using BusinessLogic.Services;
using ReservationSystem.Models;
namespace PresentationLayerForms
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            FormLogInAdmin formLogInAdmin = new FormLogInAdmin();
            formLogInAdmin.Show();
            this.Hide();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            //FormReservation formReservation = new FormReservation();
            RestaurantDbContext db = new RestaurantDbContext();
            ReservationForm formReservation = new ReservationForm(new ReservationService(db), new SpecialOccasionService(db),
                new OperatingHourService(db));
            formReservation.Show();
            this.Hide();
        }

        private void FormStart_Load(object sender, EventArgs e)
        {

        }
    }
}
