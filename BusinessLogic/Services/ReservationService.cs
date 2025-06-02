using BusinessLogic.Services.Email;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public async Task CreateReservation(Reservation reservation)
        {
            ValidateReservation(reservation);

            CheckIfThereIsReservationWithTheSameDateAndTimeForTable(reservation);

            reservation.VerificationCode = CreateVerificationCodeForReservation();
            reservation.VerifiedByUser = false;
            reservation.CreatedAt = DateTime.Now;

            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            await emailService.SendEmailAsync(reservation.Email, "Verification code",
                $"Your verification code is: {reservation.VerificationCode}");
        }

        private void ValidateReservation(Reservation reservation)
        {
            if (string.IsNullOrWhiteSpace(reservation.Name))
                throw new ArgumentException("Името е задължително.");

            if (string.IsNullOrWhiteSpace(reservation.Email) || !IsValidEmail(reservation.Email))
                throw new ArgumentException("Невалиден имейл адрес.");

            if (string.IsNullOrWhiteSpace(reservation.PhoneNumber) || reservation.PhoneNumber.Length < 6)
                throw new ArgumentException("Невалиден телефонен номер.");

            if (reservation.TableId == null || reservation.TableId <= 0)
                throw new ArgumentException("Моля, изберете валидна маса.");

            if (reservation.OperatingHoursId == null || reservation.OperatingHoursId <= 0)
                throw new ArgumentException("Моля, изберете валиден часови интервал.");

            if (reservation.ReservationDate < DateOnly.FromDateTime(DateTime.Now))
                throw new ArgumentException("Не може да правите резервации за минали дати.");
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        public void VerifyReservation(Reservation reservation, string code)
        {
            var optinalReservation = _context.Reservations.FirstOrDefault(res => res.Id == reservation.Id);
            if (optinalReservation == null)
                throw new ArgumentException("The requested reservation does not exist.");

            if ((bool)optinalReservation.VerifiedByUser)
                throw new ArgumentException("The reservation is already verified.");

            if (!optinalReservation.VerificationCode.Equals(code))
            {
                _context.Reservations.Remove(optinalReservation);
                _context.SaveChanges();
                throw new ArgumentException("Invalid verification code.");
            }
            optinalReservation.VerifiedByUser = true;
            _context.SaveChanges();
        }

        public Reservation GetReservationById(int id)
        {
            var optionalReservation = _context.Reservations
                .Include(r => r.OperatingHours)
                .Include(r => r.Table)
                .FirstOrDefault(res => res.Id == id);
            if (optionalReservation == null)
                throw new ArgumentException("The requested reservaton does not exist.");
            return optionalReservation;
        }

        public List<Reservation> GetAllReservations()
        {
            return _context.Reservations
                .Include(r => r.OperatingHours)
                .Include(r => r.Table)
                .ToList();    
        }

        public List<Reservation> GetAllReservationsByTableId(int tableId)
        {
            return _context.Reservations.Include(r => r.OperatingHours).Include(r => r.Table)
                .Where(res => res.TableId == tableId).ToList();
        }

        public List<Reservation> GetAllReservationsForTimePeriod(DateOnly start, DateOnly end)
        {
            return _context.Reservations.Include(r => r.OperatingHours).Include(r => r.Table)
                .Where(res => res.ReservationDate >= start && res.ReservationDate <= end)
                .ToList();
        }

        public List<Reservation> GetAllReservationsForTimePeriodAndTableId(DateOnly start, DateOnly end, int tableId)
        {
            return _context.Reservations.Include(r => r.OperatingHours).Include(r => r.Table)
                .Where(res => res.ReservationDate >= start && res.ReservationDate <= end)
                .Where(res => res.TableId == tableId)
                .ToList();
        }

        public List<Reservation> GetAllReservationsByDate(DateOnly date)
        {
            return _context.Reservations.Include(r => r.OperatingHours).Include(r => r.Table)
                .Where(res => res.ReservationDate == date).ToList();
        }

        public List<Reservation> GetAllReservationsByDateAndTableId(DateOnly date, int tableId)
        {
            return _context.Reservations.Include(r => r.OperatingHours).Include(r => r.Table)
                .Where(res => res.ReservationDate == date)
                .Where(res => res.TableId == tableId)
                .ToList();
        }

        public List<Reservation> GetReservations(DateOnly? startDate = null
            , DateOnly? endDate = null, DateOnly? exactDate = null, int? tableId = null,
            bool? isVerified = null, bool? includePassed = null, bool? includeCancelled = null)
        {
            var query = _context.Reservations.Include(r => r.OperatingHours).Include(r => r.Table).AsQueryable();

            if (exactDate.HasValue)
            {
                query = query.Where(res => res.ReservationDate == exactDate.Value);
            }
            else
            {
                if (startDate.HasValue)
                    query = query.Where(res => res.ReservationDate >= startDate.Value);
                if (endDate.HasValue)
                    query = query.Where(res => res.ReservationDate <= endDate.Value);
            }

            if (tableId.HasValue)
            {
                query = query.Where(res => res.TableId == tableId.Value);
            }

            if (isVerified.HasValue)
            {
                query = query.Where(res => res.VerifiedByUser == isVerified.Value);
            }

            if (includeCancelled.HasValue && !includeCancelled.Value)
            {
                query = query.Where(res => res.CanceledAt == null);
            }

            if (includePassed.HasValue && !includePassed.Value)
            {
                var today = DateOnly.FromDateTime(DateTime.Today);
                query = query.Where(res => res.ReservationDate >= today);
            }

            return query.ToList();
        }


        public async Task UpdateReservation(Reservation reservation)
        {
            CheckIfThereIsReservationWithTheSameDateAndTimeForTable(reservation);

            var optinalReservation = _context.Reservations.FirstOrDefault(res => res.Id == reservation.Id);
            if (optinalReservation == null)
                throw new ArgumentException("The requested reservation does not exist.");
            optinalReservation.Name = reservation.Name;
            optinalReservation.Email = reservation.Email;
            optinalReservation.PhoneNumber = reservation.PhoneNumber;
            optinalReservation.TableId = reservation.TableId;
            optinalReservation.OperatingHoursId = reservation.OperatingHoursId;
            optinalReservation.ReservationDate = reservation.ReservationDate;
            optinalReservation.Notes = reservation.Notes;

            _context.SaveChanges();

            await emailService.SendEmailAsync(optinalReservation.Email, "Updated reservation"
                    , $"Your reservation for {reservation.ReservationDate} is updated.");
        }

        public async Task DeleteReservation(Reservation reservation)
        {
            var optionalReservation = _context.Reservations.FirstOrDefault(res => res.Id == reservation.Id);
            if (optionalReservation == null)
                throw new ArgumentException("The requested reservation does not exist.");

            _context.Reservations.Remove(optionalReservation);
            _context.SaveChanges();

            await emailService.SendEmailAsync(reservation.Email, "Cancelled reservation"
                    , $"Your reservation for {reservation.ReservationDate} is annuled." +
                $"Sorry for the inconvenience.");
        }

        public async Task DeleteAllReservationsByTableId(int tableId)
        {
            List<Reservation> reservations = _context.Reservations.Where(res => res.TableId == tableId).ToList();
            _context.Reservations.RemoveRange(reservations);
            _context.SaveChanges();

            foreach (Reservation reservation in reservations)
            {
                await emailService.SendEmailAsync(reservation.Email, "Cancelled reservation"
                    , $"Your reservation for {reservation.ReservationDate} is annuled." + 
                $"Sorry for the inconvenience.");
            }
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
                if (reservation.ReservationDate == reservationForCheck.ReservationDate && reservation.Id != reservationForCheck.Id)
                    throw new ArgumentException("There is existing reservation for this date and time.");
            }
        }
    }
}
