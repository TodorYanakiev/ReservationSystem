using BusinessLogic.Services.Email;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ReservationService
    {
        private readonly RestaurantDbContext _context;

        private readonly EmailService emailService = new EmailService(new SmtpSettings());

        private static readonly Random _random = new Random();

        private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public ReservationService(RestaurantDbContext context)
        {
            _context = context;

        }

        public async void CreateReservation(Reservation reservation)
        {
            //TODOR fix email sending
            CheckIfThereIsReservationWithTheSameDateAndTimeForTable(reservation);
            reservation.VerificationCode = CreateVerificationCodeForReservation();
            reservation.VerifiedByUser = false;
            reservation.CreatedAt = DateTime.Now;
            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            emailService.SendEmailAsync(reservation.Email, "Verification code",
                $"Your verification code is: {reservation.VerificationCode}");
        }

        private string CreateVerificationCodeForReservation()
        {
            char[] code = new char[8];

            for (int i = 0; i < code.Length; i++)
            {
                code[i] = _chars[_random.Next(_chars.Length)];
            }

            return new string(code);

        }

        private void CheckIfThereIsReservationWithTheSameDateAndTimeForTable(Reservation reservationForCheck)
        {
            List<Reservation> reservationsForTable = _context.Reservations
                .Where(re => re.TableId == reservationForCheck.TableId)
                .Where(re => re.OperatingHoursId == reservationForCheck.OperatingHoursId)
                .ToList();
            foreach (Reservation reservation in reservationsForTable)
            {
                if (reservation.ReservationDate == reservationForCheck.ReservationDate)
                    throw new ArgumentException("There is existing reservation for this date and time.");
            }
        }
    }
}
