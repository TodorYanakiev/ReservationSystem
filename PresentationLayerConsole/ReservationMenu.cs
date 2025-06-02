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

                DateOnly? date = PromptForDate();
                if (date == null) return;

                int? tableId = PromptForTableSelection(date.Value);
                if (tableId == null) continue;

                OperatingHour selectedHour = PromptForTimeSlot(date.Value, tableId.Value);
                if (selectedHour == null) continue;

                Reservation reservation = CollectReservationDetails(date.Value, tableId.Value, selectedHour);

                TryToConfirmReservation(reservation);

                Console.WriteLine("Натисни Enter за връщане към менюто.");
                Console.ReadLine();
                return;
            }
        }


        private DateOnly? PromptForDate()
        {
            Console.Write("Въведи дата за резервация (гггг-мм-дд) или 'b' за връщане назад: ");
            string dateInput = Console.ReadLine();

            if (dateInput.Trim().ToLower() == "b")
            {
                Console.Clear();
                return null;
            }

            if (!DateOnly.TryParse(dateInput, out DateOnly date))
            {
                Console.WriteLine("Невалиден формат на дата.");
                return PromptForDate();
            }

            if (date < DateOnly.FromDateTime(DateTime.Now))
            {
                Console.WriteLine("Не може да се прави резервация за минала дата.");
                return PromptForDate();
            }

            return date;
        }


        private int? PromptForTableSelection(DateOnly date)
        {
            var freeTableIds = _restaurantTableService.GetFreeTableIdsForDate(date, _reservationService);

            if (!freeTableIds.Any())
            {
                Console.WriteLine("Няма свободни маси за тази дата. Натисни Enter за нов опит...");
                Console.ReadLine();
                return null;
            }

            Console.WriteLine("Избери маса:");
            for (int i = 0; i < freeTableIds.Count; i++)
                Console.WriteLine($"{i + 1}. Маса №{freeTableIds[i]}");

            Console.Write("Въведи номер на маса или 'b' за връщане назад: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "b") return null;

            if (!int.TryParse(input, out int choice) || choice < 1 || choice > freeTableIds.Count)
            {
                Console.WriteLine("Невалиден избор. Натисни Enter за нов опит...");
                Console.ReadLine();
                return PromptForTableSelection(date);
            }

            return freeTableIds[choice - 1];
        }

        private OperatingHour PromptForTimeSlot(DateOnly date, int tableId)
        {
            var freeHours = _operatingHourService.GetFreeOperatingHoursForTableAndDate(tableId, date, _reservationService);

            if (!freeHours.Any())
            {
                Console.WriteLine("Няма свободни часове за избраната маса. Натисни Enter за нов опит...");
                Console.ReadLine();
                return null;
            }

            Console.WriteLine("Избери свободен часови интервал:");
            for (int i = 0; i < freeHours.Count; i++)
                Console.WriteLine($"{i + 1}. {freeHours[i].StartTime} - {freeHours[i].EndTime}");

            Console.Write("Въведи номер на интервал или 'b' за връщане назад: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "b") return null;

            if (!int.TryParse(input, out int choice) || choice < 1 || choice > freeHours.Count)
            {
                Console.WriteLine("Невалиден избор. Натисни Enter за нов опит...");
                Console.ReadLine();
                return PromptForTimeSlot(date, tableId);
            }

            return freeHours[choice - 1];
        }

        private Reservation CollectReservationDetails(DateOnly date, int tableId, OperatingHour selectedHour)
        {
            Console.Write("Въведи своето име: ");
            string name = Console.ReadLine();
            Console.Write("Въведи имейл: ");
            string email = Console.ReadLine();
            Console.Write("Въведи телефон: ");
            string phone = Console.ReadLine();
            Console.Write("Допълнителни бележки (по избор): ");
            string notes = Console.ReadLine();

            return new Reservation
            {
                Name = name,
                Email = email,
                PhoneNumber = phone,
                Notes = notes,
                TableId = tableId,
                OperatingHoursId = selectedHour.Id,
                ReservationDate = date
            };
        }

        private void TryToConfirmReservation(Reservation reservation)
        {
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
                Console.WriteLine("0. Назад");
                Console.Write("Изберете опция: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DisplayAllReservations(); 
                        break;
                    case "2":
                        FilterReservations();
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
            int id = PromptForReservationId("обновяване");
            if (id == -1) return;

            try
            {
                var existing = _reservationService.GetReservationById(id);
                if (existing == null)
                {
                    Console.WriteLine("Резервацията не е намерена.");
                    return;
                }

                UpdateReservationFields(existing);
                await _reservationService.UpdateReservation(existing);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Грешка: {ex.Message}");
            }
        }

        private void UpdateReservationFields(Reservation existing)
        {
            existing.Name = PromptForUpdate($"Ново име", existing.Name);
            existing.Email = PromptForUpdate($"Нов имейл", existing.Email);
            existing.PhoneNumber = PromptForUpdate($"Нов телефонен номер", existing.PhoneNumber);

            string tableInput = PromptForUpdate("Нова маса ID", existing.TableId?.ToString());
            if (int.TryParse(tableInput, out int tableId)) existing.TableId = tableId;

            string hourInput = PromptForUpdate("Нов часови интервал ID", existing.OperatingHoursId?.ToString());
            if (int.TryParse(hourInput, out int hourId)) existing.OperatingHoursId = hourId;

            string dateInput = PromptForUpdate("Нова дата (гггг-мм-дд)", existing.ReservationDate.ToString());
            if (DateOnly.TryParse(dateInput, out var newDate)) existing.ReservationDate = newDate;

            string notes = PromptForUpdate("Бележки (по желание)", existing.Notes);
            if (!string.IsNullOrWhiteSpace(notes)) existing.Notes = notes;
        }

        private string PromptForUpdate(string label, string currentValue)
        {
            Console.Write($"{label} ({currentValue}): ");
            var input = Console.ReadLine();
            return string.IsNullOrWhiteSpace(input) ? currentValue : input;
        }


        private async Task DeleteReservationAsync()
        {
            int id = PromptForReservationId("изтриване");
            if (id == -1) return;

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

        private int PromptForReservationId(string action)
        {
            Console.Write($"ID на резервацията за {action}: ");
            if (int.TryParse(Console.ReadLine(), out int id)) return id;

            Console.WriteLine("Невалиден ID.");
            return -1;
        }


        private void FilterReservations()
        {
            Console.WriteLine("=== Филтриране на резервации ===");

            DateOnly? startDate = PromptOptionalDate("начална дата");
            DateOnly? endDate = PromptOptionalDate("крайна дата");
            DateOnly? exactDate = PromptOptionalDate("конкретна дата");
            int? tableId = PromptOptionalInt("ID на маса");
            bool? isVerified = PromptOptionalBool("Само потвърдени? (y/n/празно)");
            bool? includePassed = PromptOptionalBool("Включване на минали резервации? (y/n/празно)");
            bool? includeCancelled = PromptOptionalBool("Включване на анулирани резервации? (y/n/празно)");

            var filteredReservations = _reservationService.GetReservations(
                startDate, endDate, exactDate, tableId, isVerified, includePassed, includeCancelled);

            PrintReservations(filteredReservations);
        }

        private DateOnly? PromptOptionalDate(string label)
        {
            Console.Write($"Въведете {label} (гггг-мм-дд) или оставете празно: ");
            return TryParseOptionalDate(Console.ReadLine());
        }

        private int? PromptOptionalInt(string label)
        {
            Console.Write($"Въведете {label} или оставете празно: ");
            return TryParseOptionalInt(Console.ReadLine());
        }

        private bool? PromptOptionalBool(string label)
        {
            Console.Write($"{label}: ");
            return TryParseOptionalBool(Console.ReadLine());
        }

        private void PrintReservations(IEnumerable<Reservation> reservations)
        {
            if (!reservations.Any())
            {
                Console.WriteLine("Няма намерени резервации по зададените критерии.");
                return;
            }

            foreach (var r in reservations)
            {
                Console.WriteLine(
                    $"ID: {r.Id}, Име: {r.Name}, Имейл: {r.Email}, Телефон: {r.PhoneNumber}, " +
                    $"Маса: {r.TableId}, Дата: {r.ReservationDate}, Час: {r.OperatingHours?.StartTime}-{r.OperatingHours?.EndTime}, Потвърдена: {r.VerifiedByUser}");
            }
        }


        private DateOnly? TryParseOptionalDate(string input)
        {
            return DateOnly.TryParse(input, out var result) ? result : (DateOnly?)null;
        }

        private int? TryParseOptionalInt(string input)
        {
            return int.TryParse(input, out var result) ? result : (int?)null;
        }

        private bool? TryParseOptionalBool(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;
            return input.ToLower() switch
            {
                "у" => true,
                "y" => true,
                "н" => false,
                "n" => false,
                _ => null
            };
        }

    }
}
