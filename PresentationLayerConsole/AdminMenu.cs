using BusinessLogic.Services;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayerConsole
{
    public class AdminMenu
    {
        private readonly ReservationService _reservationService;
        private readonly OperatingHourService _operatingHourService;
        private readonly RestaurantTableService _tableService;
        private readonly UserService _userService;

        public AdminMenu()
        {
            var dbContext = new RestaurantDbContext();
            _reservationService = new ReservationService(dbContext);
            _operatingHourService = new OperatingHourService(dbContext);
            _tableService = new RestaurantTableService(dbContext);
            _userService = new UserService(dbContext);
        }

        public async Task ShowMenu()
        {
            if (!Login())
                return;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Админ меню ====");
                Console.WriteLine("1. Виж всички резервации");
                Console.WriteLine("2. Обнови резервация");
                Console.WriteLine("3. Изтрий резервация");
                Console.WriteLine("0. Изход");
                Console.Write("Изберете опция: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DisplayAllReservations();
                        break;
                    case "2":
                        await UpdateReservationAsync();
                        break;
                    case "3":
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

        private bool Login()
        {
            Console.WriteLine("==== Вход за администратор ====");
            Console.Write("Потребителско име: ");
            string username = Console.ReadLine()!;
            Console.Write("Парола: ");
            string password = ReadPassword();

            bool success = _userService.ValidateLogin(username, password);
            if (!success)
            {
                Console.WriteLine("Невалидни данни за вход.");
                Console.WriteLine("Натиснете Enter за изход...");
                Console.ReadLine();
                return false;
            }

            var user = _userService.GetUserByUsername(username);
            if (user == null || user.Role?.ToLower() != "admin")
            {
                Console.WriteLine("Само администратори имат достъп до това меню.");
                Console.WriteLine("Натиснете Enter за изход...");
                Console.ReadLine();
                return false;
            }

            return true;
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
                Console.WriteLine("Резервацията е обновена.");
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
                Console.WriteLine("Резервацията е изтрита.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Грешка: {ex.Message}");
            }
        }

        private string ReadPassword()
        {
            var password = string.Empty;
            ConsoleKey key;

            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            }
            while (key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }
    }
}