using BusinessLogic.Services.Email;
using ReservationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{

    /// <summary>
    /// Service responsible for managing operating hours for restaurant tables.
    /// </summary>
    public class OperatingHourService
    {
        private readonly RestaurantDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatingHourService"/> class.
        /// </summary>
        /// <param name="context">The database context for restaurant reservations.</param>
        public OperatingHourService(RestaurantDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates and saves a single operating hour.
        /// </summary>
        /// <param name="operatingHour">The operating hour to be saved.</param>
        public void CreateSingleOperatingHour(OperatingHour operatingHour)
        {
            CheckSingleOperatingHourIfCanBeSaved(operatingHour);
            _context.OperatingHours.Add(operatingHour);
            _context.SaveChanges();
        }

        /// <summary>
        /// Creates and saves multiple operating hours for given days, times, and table IDs.
        /// </summary>
        /// <param name="workingDays">List of days of the week.</param>
        /// <param name="startingHours">List of starting times.</param>
        /// <param name="endingHours">List of ending times.</param>
        /// <param name="tableIds">List of table IDs.</param>
        public void CreateMultipleOperatingHours(List<string> workingDays, List<TimeOnly> startingHours, List<TimeOnly> endingHours, List<int> tableIds)
        {
            if (startingHours.Count != endingHours.Count)
            {
                throw new ArgumentException("The number of starting and ending hours must be the same.");
            }

            List<OperatingHour> operatingHours = new List<OperatingHour>();
            foreach (string workingDay in workingDays)
            {
                for (int i = 0; i < startingHours.Count; i++)
                {
                    if (startingHours[i] > endingHours[i])
                    {
                        throw new ArgumentException($"Ending hour {endingHours[i]} is before {startingHours[i]}.");
                    }
                    foreach (int tableId in tableIds)
                    {
                        OperatingHour newHour = new OperatingHour();
                        newHour.DayOfWeek = workingDay;
                        newHour.StartTime = startingHours[i];
                        newHour.EndTime = endingHours[i];
                        newHour.TableId = tableId;
                        CreateSingleOperatingHour(newHour);
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves all operating hours.
        /// </summary>
        /// <returns>List of all operating hours.</returns>
        public List<OperatingHour> GetAllOperatingHours()
        {
            return _context.OperatingHours.Include(oh => oh.Table).ToList();
        }

        /// <summary>
        /// Retrieves all operating hours for a specific table.
        /// </summary>
        /// <param name="tableId">The table ID.</param>
        /// <returns>List of operating hours for the specified table.</returns>
        public List<OperatingHour> GetOperatingHoursByTableId(int tableId)
        {
            return _context.OperatingHours.Include(oh => oh.Table).Where(oh => oh.TableId == tableId).ToList();
        }

        /// <summary>
        /// Retrieves operating hours for a specific day of the week.
        /// </summary>
        /// <param name="dayOfWeek">Day of the week as string (e.g., "Monday").</param>
        /// <returns>List of operating hours for the specified day.</returns>
        public List<OperatingHour> GetOperatingHoursByDayOfWeek(string dayOfWeek)
        {
            return _context.OperatingHours.Include(oh => oh.Table).Where(oh => oh.DayOfWeek.Equals(dayOfWeek)).ToList();
        }

        /// <summary>
        /// Updates an existing operating hour.
        /// </summary>
        /// <param name="newHour">The updated operating hour object.</param>
        public void UpdateOperatingHour(OperatingHour newHour)
        {
            CheckSingleOperatingHourIfCanBeSaved(newHour);
            var existingHour = _context.OperatingHours.FirstOrDefault(oh => oh.Id == newHour.Id);
            if (existingHour == null)
                throw new ArgumentException("The operating hour does not exist with id " + newHour.Id);
            existingHour.DayOfWeek = newHour.DayOfWeek;
            existingHour.StartTime = newHour.StartTime;
            existingHour.EndTime = newHour.EndTime;
            existingHour.TableId = newHour.TableId;
            existingHour.Table = newHour.Table;

            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes an operating hour and cancels any related reservations.
        /// </summary>
        /// <param name="operatingHour">The operating hour to be deleted.</param>
        public async Task DeleteOperatingHour(OperatingHour operatingHour)
        {
            var emailService = new EmailService(new SmtpSettings());
            List<Reservation> reservations = _context.Reservations
                .Where(reservation => reservation.OperatingHours.Id == operatingHour.Id)
                .ToList();
            foreach (Reservation reservation in reservations)
            {
                await emailService.SendEmailAsync(reservation.Email, "Cancelled reservation"
                    , $"Your reservation for {reservation.ReservationDate} at " +
                    $"{operatingHour.StartTime} - {operatingHour.EndTime} is cancelled. " +
                    $"Sorry for the inconvenience.");
            }

            _context.Reservations.RemoveRange(reservations);
            _context.OperatingHours.Remove(operatingHour);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets available (unreserved) operating hours for a specific table and date.
        /// </summary>
        /// <param name="tableId">The table ID.</param>
        /// <param name="date">The reservation date.</param>
        /// <param name="reservationService">The reservation service used to check for existing reservations.</param>
        /// <returns>List of free operating hours for the specified table and date.</returns>
        public List<OperatingHour> GetFreeOperatingHoursForTableAndDate(int tableId, DateOnly date, ReservationService reservationService)
        {
            var reservedHourIds = reservationService.GetAllReservationsByDateAndTableId(date, tableId)
                .Select(r => r.OperatingHoursId).ToHashSet();

            var dayOfWeek = date.DayOfWeek.ToString();
            return GetOperatingHoursByDayOfWeek(dayOfWeek)
                .Where(oh => oh.TableId == tableId && !reservedHourIds.Contains(oh.Id))
                .ToList();
        }

        /// <summary>
        /// Validates whether an operating hour can be saved without overlaps.
        /// </summary>
        /// <param name="operatingHour">The operating hour to validate.</param>
        /// <exception cref="ArgumentException">Thrown when time is invalid or overlapping with another slot.</exception>
        private void CheckSingleOperatingHourIfCanBeSaved(OperatingHour operatingHour)
        {
            if (operatingHour.EndTime < operatingHour.StartTime)
                throw new ArgumentException("The ending hour is before the staring hour.");

            List<OperatingHour> potentialProblemOperatingHours = _context.OperatingHours
                .Where(oh => oh.TableId == operatingHour.TableId)
                .Where(oh => oh.DayOfWeek.Equals(operatingHour.DayOfWeek))
                .ToList();

            foreach (OperatingHour potentialProblem in potentialProblemOperatingHours)
            {
                //check if there is existing operating hour that overlaps with the requested
                if (!(potentialProblem.EndTime <= operatingHour.StartTime
                    || potentialProblem.StartTime >= operatingHour.EndTime))
                {
                    throw new ArgumentException("The requested operating hour is overlapping with existing one.");
                }
            }
        }
    }
}


