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
    /// <summary>
    /// Provides services for creating, updating, deleting, and retrieving restaurant reservations.
    /// </summary>
    public class ReservationService
    {
        private readonly RestaurantDbContext _context;

        private readonly EmailService emailService = new EmailService(new SmtpSettings());

        private static readonly Random _random = new Random();

        private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationService"/> class.
        /// </summary>
        /// <param name="context">The database context to be used.</param>
        public ReservationService(RestaurantDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new reservation and sends a verification email.
        /// </summary>
        /// <param name="reservation">The reservation to create.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentException">Thrown when reservation data is invalid or already exists for the same time and table.</exception>
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

        /// <summary>
        /// Verifies a reservation using a provided verification code.
        /// </summary>
        /// <param name="reservation">The reservation to verify.</param>
        /// <param name="code">The verification code to validate.</param>
        /// <exception cref="ArgumentException">Thrown when the reservation is invalid or the code is incorrect.</exception>
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

        /// <summary>
        /// Retrieves a reservation by its identifier.
        /// </summary>
        /// <param name="id">The ID of the reservation.</param>
        /// <returns>The matching reservation.</returns>
        /// <exception cref="ArgumentException">Thrown when the reservation does not exist.</exception>
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

        /// <summary>
        /// Retrieves all reservations.
        /// </summary>
        /// <returns>A list of all reservations.</returns>
        public List<Reservation> GetAllReservations()
        {
            return _context.Reservations
                .Include(r => r.OperatingHours)
                .Include(r => r.Table)
                .ToList();    
        }

        /// <summary>
        /// Retrieves all reservations for a specific table.
        /// </summary>
        /// <param name="tableId">The table ID to filter by.</param>
        /// <returns>A list of reservations for the given table.</returns>
        public List<Reservation> GetAllReservationsByTableId(int tableId)
        {
            return _context.Reservations.Include(r => r.OperatingHours).Include(r => r.Table)
                .Where(res => res.TableId == tableId).ToList();
        }

        /// <summary>
        /// Retrieves all reservations between two dates.
        /// </summary>
        /// <param name="start">The start date.</param>
        /// <param name="end">The end date.</param>
        /// <returns>A list of reservations within the time period.</returns>
        public List<Reservation> GetAllReservationsForTimePeriod(DateOnly start, DateOnly end)
        {
            return _context.Reservations.Include(r => r.OperatingHours).Include(r => r.Table)
                .Where(res => res.ReservationDate >= start && res.ReservationDate <= end)
                .ToList();
        }

        /// <summary>
        /// Retrieves all reservations within a date range for a specific table.
        /// </summary>
        /// <param name="start">Start date.</param>
        /// <param name="end">End date.</param>
        /// <param name="tableId">Table ID to filter by.</param>
        /// <returns>List of filtered reservations.</returns>
        public List<Reservation> GetAllReservationsForTimePeriodAndTableId(DateOnly start, DateOnly end, int tableId)
        {
            return _context.Reservations.Include(r => r.OperatingHours).Include(r => r.Table)
                .Where(res => res.ReservationDate >= start && res.ReservationDate <= end)
                .Where(res => res.TableId == tableId)
                .ToList();
        }

        /// <summary>
        /// Retrieves all reservations for a specific date.
        /// </summary>
        /// <param name="date">The date to filter by.</param>
        /// <returns>List of reservations for the date.</returns>
        public List<Reservation> GetAllReservationsByDate(DateOnly date)
        {
            return _context.Reservations.Include(r => r.OperatingHours).Include(r => r.Table)
                .Where(res => res.ReservationDate == date).ToList();
        }

        /// <summary>
        /// Retrieves reservations by date and table.
        /// </summary>
        /// <param name="date">Date of reservation.</param>
        /// <param name="tableId">ID of the table.</param>
        /// <returns>List of reservations.</returns>
        public List<Reservation> GetAllReservationsByDateAndTableId(DateOnly date, int tableId)
        {
            return _context.Reservations.Include(r => r.OperatingHours).Include(r => r.Table)
                .Where(res => res.ReservationDate == date)
                .Where(res => res.TableId == tableId)
                .ToList();
        }

        /// <summary>
        /// Retrieves filtered reservations based on date, table, and other criteria.
        /// </summary>
        /// <param name="startDate">Start date filter.</param>
        /// <param name="endDate">End date filter.</param>
        /// <param name="exactDate">Exact reservation date filter.</param>
        /// <param name="tableId">Table ID filter.</param>
        /// <param name="isVerified">Verification status filter.</param>
        /// <param name="includePassed">Whether to include passed reservations.</param>
        /// <param name="includeCancelled">Whether to include cancelled reservations.</param>
        /// <returns>List of matching reservations.</returns>
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

        /// <summary>
        /// Updates an existing reservation and notifies the user.
        /// </summary>
        /// <param name="reservation">The reservation with updated data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentException">Thrown if the reservation does not exist or overlaps with an existing one.</exception>
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

        /// <summary>
        /// Deletes a reservation and notifies the user.
        /// </summary>
        /// <param name="reservation">The reservation to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentException">Thrown if the reservation does not exist.</exception>
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

        /// <summary>
        /// Deletes all reservations for a specific table and notifies affected users.
        /// </summary>
        /// <param name="tableId">ID of the table to delete reservations for.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
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

        /// <summary>
        /// Validates the reservation fields.
        /// </summary>
        /// <param name="reservation">The reservation to validate.</param>
        /// <exception cref="ArgumentException">Thrown if validation fails.</exception>
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

        /// <summary>
        /// Checks if an email address is valid.
        /// </summary>
        /// <param name="email">Email address to check.</param>
        /// <returns>True if the email is valid; otherwise, false.</returns>
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

        /// <summary>
        /// Creates a random verification code for a reservation.
        /// </summary>
        /// <returns>A generated verification code.</returns>
        private string CreateVerificationCodeForReservation()
        {
            char[] code = new char[8];

            for (int i = 0; i < code.Length; i++)
            {
                code[i] = _chars[_random.Next(_chars.Length)];
            }

            return new string(code);

        }

        /// <summary>
        /// Checks if there is an existing reservation with the same date and time for the same table.
        /// </summary>
        /// <param name="reservationForCheck">The reservation to check against existing ones.</param>
        /// <exception cref="ArgumentException">Thrown if a conflicting reservation is found.</exception>
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
