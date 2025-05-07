using BusinessLogic.Services;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayerConsole
{
    using BusinessLogic.Services;
    using System;

    namespace ReservationSystem.Menu
    {
        public class AdminMenu
        {
            private readonly ReservationService _reservationService;
            private readonly OperatingHourService _operatingHourService;
            private readonly RestaurantTableService _tableService;

            public AdminMenu()
            {
                _reservationService = new ReservationService(new RestaurantDbContext());
                _operatingHourService = new OperatingHourService(new RestaurantDbContext());
                _tableService = new RestaurantTableService(new RestaurantDbContext());
            }

            public async Task ShowMenu()
            {
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
                int id = int.Parse(Console.ReadLine()!);

                try
                {
                    var existing = _reservationService.GetReservationById(id);

                    Console.Write($"Ново име ({existing.Name}): ");
                    existing.Name = Console.ReadLine() ?? existing.Name;

                    Console.Write($"Нов имейл ({existing.Email}): ");
                    existing.Email = Console.ReadLine() ?? existing.Email;

                    Console.Write($"Нов телефонен номер ({existing.PhoneNumber}): ");
                    existing.PhoneNumber = Console.ReadLine() ?? existing.PhoneNumber;

                    Console.Write($"Нова маса ID ({existing.TableId}): ");
                    var tableInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(tableInput))
                        existing.TableId = int.Parse(tableInput);

                    Console.Write($"Нов часови интервал ID ({existing.OperatingHoursId}): ");
                    var hourInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(hourInput))
                        existing.OperatingHoursId = int.Parse(hourInput);

                    Console.Write($"Нова дата (гггг-мм-дд) ({existing.ReservationDate}): ");
                    var dateInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(dateInput))
                        existing.ReservationDate = DateOnly.Parse(dateInput);

                    Console.Write("Бележки (по желание): ");
                    existing.Notes = Console.ReadLine();

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
                int id = int.Parse(Console.ReadLine()!);

                try
                {
                    var existing = _reservationService.GetReservationById(id);
                    await _reservationService.DeleteReservation(existing);
                    Console.WriteLine("Резервацията е изтрита.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Грешка: {ex.Message}");
                }
            }

        }
    }
}