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
                Console.Write("Въведи дата за резервация (гггг-мм-дд) или 'b' за връщане назад: ");

                string dateInput = Console.ReadLine();
                if (dateInput.ToLower() == "b") return;

                if (!DateOnly.TryParse(dateInput, out DateOnly date))
                {
                    Console.Write("Невалиден формат на дата. Натисни Enter за нов опит...");
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
                Console.Write("Въведи номер на маса или 'b' за връщане назад: ");
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
                Console.Write("Въведи номер на интервал или 'b' за връщане назад: ");
                string hourInput = Console.ReadLine();
                if (hourInput.ToLower() == "b") continue;

                if (!int.TryParse(hourInput, out int hourChoice) || hourChoice < 1 || hourChoice > freeHours.Count)
                {
                    Console.WriteLine("Невалиден избор. Натисни Enter за нов опит...");
                    Console.ReadLine();
                    continue;
                }

                OperatingHour selectedHour = freeHours[hourChoice - 1];

                Console.Write("Въведи своето име: ");
                string name = Console.ReadLine();
                Console.Write("Въведи имейл: ");
                string email = Console.ReadLine();
                Console.Write("Въведи телефон: ");
                string phone = Console.ReadLine();
                Console.Write("Допълнителни бележки (по избор): ");
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
                    Console.Write("Въведи кода: ");
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


        public async Task ShowAdminReservationMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Управление на резервациите ====");
                Console.WriteLine("1. Всички резервации");
                Console.WriteLine("2. Филтриране");
                Console.WriteLine("3. Обновяване на резерваця");
                Console.WriteLine("4. Премахване на резервация");
                Console.Write("Изберете опция: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DisplayAllReservations(); break;
                    case "2":
                        
                        break;
                    case "3":
                        await UpdateReservationAsync();
                        break;
                    case "4":
                        await DeleteReservationAsync();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Невалидна опция.");
                        break;
                }

                Console.WriteLine("Натиснете Enter за да продължите...");
                Console.ReadLine();
            }
        }

        private void DisplayAllReservations()
        {
            var reservations = _reservationService.GetAllReservations();
            foreach (var r in reservations)
            {
                Console.WriteLine($"ID: {r.Id}, Име: {r.Name}, Имейл: {r.Email}, Телефон: {r.PhoneNumber}, Маса: {r.TableId}, Дата: {r.ReservationDate}, Час: {r.OperatingHours?.StartTime}-{r.OperatingHours?.EndTime}, Потвърдена: {r.VerifiedByUser}");
            }
        }


        private async Task UpdateReservationAsync()
        {
            Console.Write("ID на резервацията за обновяване: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Невалиден ID.");
                return;
            }

            try
            {
                var existing = _reservationService.GetReservationById(id);
                if (existing == null)
                {
                    Console.WriteLine("Резервацията не е намерена.");
                    return;
                }

                Console.Write($"Ново име ({existing.Name}): ");
                var nameInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nameInput))
                    existing.Name = nameInput;

                Console.Write($"Нов имейл ({existing.Email}): ");
                var emailInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(emailInput))
                    existing.Email = emailInput;

                Console.Write($"Нов телефонен номер ({existing.PhoneNumber}): ");
                var phoneInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(phoneInput))
                    existing.PhoneNumber = phoneInput;

                Console.Write($"Нова маса ID ({existing.TableId}): ");
                var tableInput = Console.ReadLine();
                if (int.TryParse(tableInput, out int tableId))
                    existing.TableId = tableId;

                Console.Write($"Нов часови интервал ID ({existing.OperatingHoursId}): ");
                var hourInput = Console.ReadLine();
                if (int.TryParse(hourInput, out int hourId))
                    existing.OperatingHoursId = hourId;

                Console.Write($"Нова дата (гггг-мм-дд) ({existing.ReservationDate}): ");
                var dateInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(dateInput) && DateOnly.TryParse(dateInput, out var newDate))
                    existing.ReservationDate = newDate;

                Console.Write("Бележки (по желание): ");
                var notes = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(notes))
                    existing.Notes = notes;

                await _reservationService.UpdateReservation(existing);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Грешка: {ex.Message}");
            }
        }


        private async Task DeleteReservationAsync()
        {
            Console.Write("ID на резервацията за изтриване: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Невалиден ID.");
                return;
            }

            try
            {
                var existing = _reservationService.GetReservationById(id);
                if (existing == null)
                {
                    Console.WriteLine("Резервацията не е намерена.");
                    return;
                }

                await _reservationService.DeleteReservation(existing);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Грешка: {ex.Message}");
            }
        }
    }
}
