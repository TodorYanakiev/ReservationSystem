using BusinessLogic.Services;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayerConsole
{
    internal class OperatingHourMenu
    {
        private readonly OperatingHourService _operatingHourService;
        private readonly RestaurantTableService _tableService;

        public OperatingHourMenu()
        {
            var context = new RestaurantDbContext();
            _operatingHourService = new OperatingHourService(context);
            _tableService = new RestaurantTableService(context);
        }

        public void ShowOperatingHourMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Управление на работни часове ====");
                Console.WriteLine("1. Добавяне на работен час");
                Console.WriteLine("2. Преглед на всички работни часове");
                Console.WriteLine("3. Редактиране на работен час");
                Console.WriteLine("4. Изтриване на работен час");
                Console.WriteLine("0. Назад");
                Console.Write("Изберете опция: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddOperatingHour();
                        break;
                    case "2":
                        ViewOperatingHours();
                        break;
                    case "3":
                        EditOperatingHour();
                        break;
                    case "4":
                        DeleteOperatingHour();
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

        private void AddOperatingHour()
        {
            Console.Write("Ден от седмицата (напр. Monday): ");
            string dayOfWeek = Console.ReadLine()!;

            Console.Write("Начален час (формат HH:mm): ");
            var start = TimeOnly.Parse(Console.ReadLine()!);

            Console.Write("Краен час (формат HH:mm): ");
            var end = TimeOnly.Parse(Console.ReadLine()!);

            Console.Write("ID на маса: ");
            int tableId = int.Parse(Console.ReadLine()!);

            var operatingHour = new OperatingHour
            {
                DayOfWeek = dayOfWeek,
                StartTime = start,
                EndTime = end,
                TableId = tableId
            };

            try
            {
                _operatingHourService.CreateSingleOperatingHour(operatingHour);
                Console.WriteLine("Работният час е добавен.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Грешка: {ex.Message}");
            }
        }

        private void ViewOperatingHours()
        {
            var hours = _operatingHourService.GetAllOperatingHours();
            Console.WriteLine("Списък с работни часове:");
            foreach (var h in hours)
            {
                Console.WriteLine($"ID: {h.Id}, Ден: {h.DayOfWeek}, Час: {h.StartTime}-{h.EndTime}, Маса: {h.Table?.Number ?? h.TableId}");
            }
        }

        private void EditOperatingHour()
        {
            Console.Write("ID на работния час за редактиране: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Невалиден ID.");
                return;
            }

            var existing = _operatingHourService.GetAllOperatingHours().FirstOrDefault(h => h.Id == id);
            if (existing == null)
            {
                Console.WriteLine("Работният час не е намерен.");
                return;
            }

            Console.Write($"Нов ден (текущ: {existing.DayOfWeek}): ");
            var dayInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(dayInput)) existing.DayOfWeek = dayInput;

            Console.Write($"Нов начален час (текущ: {existing.StartTime}, формат HH:mm): ");
            var startInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(startInput)) existing.StartTime = TimeOnly.Parse(startInput);

            Console.Write($"Нов краен час (текущ: {existing.EndTime}, формат HH:mm): ");
            var endInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(endInput)) existing.EndTime = TimeOnly.Parse(endInput);

            Console.Write($"Нов ID на маса (текущ: {existing.TableId}): ");
            var tableInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(tableInput) && int.TryParse(tableInput, out int newTableId)) existing.TableId = newTableId;

            try
            {
                _operatingHourService.UpdateOperatingHour(existing);
                Console.WriteLine("Работният час е обновен.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Грешка при обновяване: {ex.Message}");
            }
        }

        private void DeleteOperatingHour()
        {
            Console.Write("ID на работния час за изтриване: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var existing = _operatingHourService.GetAllOperatingHours().FirstOrDefault(h => h.Id == id);
                if (existing != null)
                {
                    try
                    {
                        _operatingHourService.DeleteOperatingHour(existing).Wait();
                        Console.WriteLine("Работният час е изтрит.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Грешка: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Работният час не е намерен.");
                }
            }
            else
            {
                Console.WriteLine("Невалиден ID.");
            }
        }
    }
}
