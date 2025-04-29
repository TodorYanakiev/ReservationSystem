using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    internal class OperatingHourService
    {
        private readonly RestaurantDbContext _context;

        public OperatingHourService(RestaurantDbContext context)
        {
            _context = context;
        }

        public void CreateSingleOperatingHour(OperatingHour operatingHour)
        {
            if (!CanSingleOperatingHourBeSaved(operatingHour))
                throw new ArgumentException("The requested operating hour is overlapping with existing one.");
            _context.OperatingHours.Add(operatingHour);
            _context.SaveChanges();
        }

        public void CreateMultipleOperatingHours(List<string> workingDays, List<TimeOnly> startingHours, List<TimeOnly> endingHours, List<int> tableIds)
        {
            if (startingHours.Count != endingHours.Count)
            {
                throw new ArgumentException("The number of starting and ending hours must be the same.");
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
        }

        public List<OperatingHour> GetAllOperatingHours()
        {
            return _context.OperatingHours.ToList();
        }

        public List<OperatingHour> GetOperatingHoursByTableId(int tableId)
        {
            return _context.OperatingHours.Where(oh => oh.TableId == tableId).ToList();
        }

        public List<OperatingHour> GetOperatingHoursByDayOfWeek(string dayOfWeek)
        {
            return _context.OperatingHours.Where(oh => oh.DayOfWeek.Equals(dayOfWeek)).ToList();
        }

        public void DeleteOperatingHour(OperatingHour operatingHour)
        {
            //TODO send email to canceled reservations
            _context.Reservations.RemoveRange(operatingHour.Reservations);
            _context.OperatingHours.Remove(operatingHour);
            _context.SaveChanges();
        }

        private bool CanSingleOperatingHourBeSaved(OperatingHour operatingHour)
        {
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
                    return false;
                }
            }
            return true;
        }
    }
}


