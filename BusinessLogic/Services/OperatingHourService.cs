using BusinessLogic.Services.Email;
using ReservationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class OperatingHourService
    {
        private readonly RestaurantDbContext _context;

        public OperatingHourService(RestaurantDbContext context)
        {
            _context = context;
        }

        public void CreateSingleOperatingHour(OperatingHour operatingHour)
        {
            CheckSingleOperatingHourIfCanBeSaved(operatingHour);
            _context.OperatingHours.Add(operatingHour);
            _context.SaveChanges();
        }

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

        public List<OperatingHour> GetAllOperatingHours()
        {
            return _context.OperatingHours.Include(oh => oh.Table).ToList();
        }

        public List<OperatingHour> GetOperatingHoursByTableId(int tableId)
        {
            return _context.OperatingHours.Include(oh => oh.Table).Where(oh => oh.TableId == tableId).ToList();
        }

        public List<OperatingHour> GetOperatingHoursByDayOfWeek(string dayOfWeek)
        {
            return _context.OperatingHours.Include(oh => oh.Table).Where(oh => oh.DayOfWeek.Equals(dayOfWeek)).ToList();
        }

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
        public List<OperatingHour> GetFreeOperatingHoursForTableAndDate(int tableId, DateOnly date, ReservationService reservationService)
        {
            var reservedHourIds = reservationService.GetAllReservationsByDateAndTableId(date, tableId)
                .Select(r => r.OperatingHoursId).ToHashSet();

            var dayOfWeek = date.DayOfWeek.ToString();
            return GetOperatingHoursByDayOfWeek(dayOfWeek)
                .Where(oh => oh.TableId == tableId && !reservedHourIds.Contains(oh.Id))
                .ToList();
        }
    }
}


