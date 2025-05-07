using BusinessLogic.Services;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayerConsole
{
    internal class ReservationMenu
    {
        private readonly ReservationService _reservationService;
        private readonly RestaurantTableService _restaurantTableService;
        private readonly OperatingHourService _operatingHourService;
        public ReservationMenu() 
        { 
            _reservationService = new ReservationService(new RestaurantDbContext());
            _restaurantTableService = new RestaurantTableService(new RestaurantDbContext());
            _operatingHourService = new OperatingHourService(new RestaurantDbContext());
        }
        public void MakeReservationMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Направи резервация ===");
                Console.WriteLine("Въведи дата за резервация (гггг-мм-дд) или 'b' за връщане назад:");

                string dateInput = Console.ReadLine();
                if (dateInput.ToLower() == "b") return;

                if (!DateOnly.TryParse(dateInput, out DateOnly date))
                {
                    Console.WriteLine("Невалиден формат на дата. Натисни Enter за нов опит...");
                    Console.ReadLine();
                    continue;
                }

                List<int?> freeTableIds = _restaurantTableService.GetFreeTableIdsForDate(date, _reservationService);
                if (!freeTableIds.Any())
                {
                    Console.WriteLine("Няма свободни маси за тази дата. Натисни Enter за нов опит...");
                    Console.ReadLine();
                    continue;
                }

                Console.WriteLine("Избери маса:");
                for (int i = 0; i < freeTableIds.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Маса №{freeTableIds[i]}");
                }
                Console.WriteLine("Въведи номер на маса или 'b' за връщане назад:");
                string tableInput = Console.ReadLine();
                if (tableInput.ToLower() == "b") continue;

                if (!int.TryParse(tableInput, out int tableChoice) || tableChoice < 1 || tableChoice > freeTableIds.Count)
                {
                    Console.WriteLine("Невалиден избор. Натисни Enter за нов опит...");
                    Console.ReadLine();
                    continue;
                }

                int? chosenTableId = freeTableIds[tableChoice - 1];
                List<OperatingHour> freeHours = _operatingHourService.GetFreeOperatingHoursForTableAndDate((int)chosenTableId, date, _reservationService);
                if (!freeHours.Any())
                {
                    Console.WriteLine("Няма свободни часове за избраната маса. Натисни Enter за нов опит...");
                    Console.ReadLine();
                    continue;
                }

                Console.WriteLine("Избери свободен часови интервал:");
                for (int i = 0; i < freeHours.Count; i++)
                {
                    OperatingHour h = freeHours[i];
                    Console.WriteLine($"{i + 1}. {h.StartTime} - {h.EndTime}");
                }
                Console.WriteLine("Въведи номер на интервал или 'b' за връщане назад:");
                string hourInput = Console.ReadLine();
                if (hourInput.ToLower() == "b") continue;

                if (!int.TryParse(hourInput, out int hourChoice) || hourChoice < 1 || hourChoice > freeHours.Count)
                {
                    Console.WriteLine("Невалиден избор. Натисни Enter за нов опит...");
                    Console.ReadLine();
                    continue;
                }

                OperatingHour selectedHour = freeHours[hourChoice - 1];

                Console.WriteLine("Въведи своето име:");
                string name = Console.ReadLine();
                Console.WriteLine("Въведи имейл:");
                string email = Console.ReadLine();
                Console.WriteLine("Въведи телефон:");
                string phone = Console.ReadLine();
                Console.WriteLine("Допълнителни бележки (по избор):");
                string notes = Console.ReadLine();

                Reservation reservation = new Reservation
                {
                    Name = name,
                    Email = email,
                    PhoneNumber = phone,
                    Notes = notes,
                    TableId = chosenTableId,
                    OperatingHoursId = selectedHour.Id,
                    ReservationDate = date
                };

                try
                {
                    _reservationService.CreateReservation(reservation).Wait();
                    Console.WriteLine("Код за потвърждение е изпратен на твоя имейл.");
                    Console.WriteLine("Въведи кода:");
                    string code = Console.ReadLine();
                    _reservationService.VerifyReservation(reservation, code);
                    Console.WriteLine("Резервацията е успешно потвърдена!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Грешка: {ex.Message}");
                }

                Console.WriteLine("Натисни Enter за връщане към менюто.");
                Console.ReadLine();
                return;
            }
        }

    }
}
