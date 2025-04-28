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
                            operatingHours.Add(newHour);
                        }
                    }
                }
                _context.OperatingHours.AddRange(operatingHours);
                _context.SaveChanges();
            }
        }

        public void DeleteOperatingHour(OperatingHour operatingHour)
        {
            //TODO send email to canceled reservations
            _context.Reservations.RemoveRange(operatingHour.Reservations);
            _context.OperatingHours.Remove(operatingHour);
            _context.SaveChanges();
        }

        private void CheckSingleOperatingHour(OperatingHour operatingHour)
        {
            
        }
    }
}


