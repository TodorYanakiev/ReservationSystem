using BusinessLogic.Services;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayerConsole
{
    internal class SpecialOccasionMenu
    {
        private readonly SpecialOccasionService _occasionService;

        public SpecialOccasionMenu()
        {
            var context = new RestaurantDbContext();
            _occasionService = new SpecialOccasionService(context);
        }

        public void ShowOccasionMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Специални поводи ====");
                Console.WriteLine("1. Добавяне на повод");
                Console.WriteLine("2. Преглед на всички поводи");
                Console.WriteLine("3. Редактиране на повод");
                Console.WriteLine("4. Изтриване на повод");
                Console.WriteLine("0. Назад");
                Console.Write("Изберете опция: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddOccasion();
                        break;
                    case "2":
                        ViewOccasions();
                        break;
                    case "3":
                        EditOccasion();
                        break;
                    case "4":
                        DeleteOccasion();
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

        private void AddOccasion()
        {
            Console.Write("Описание: ");
            string description = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("Описанието не може да е празно.");
                return;
            }

            Console.Write("Начален час (формат: yyyy-MM-dd HH:mm): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime start))
            {
                Console.WriteLine("Невалиден начален час.");
                return;
            }

            if (start <= DateTime.Now)
            {
                Console.WriteLine("Началният час трябва да не е минал.");
                return;
            }

            Console.Write("Краен час (формат: yyyy-MM-dd HH:mm): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime end))
            {
                Console.WriteLine("Невалиден краен час.");
                return;
            }

            if (end <= start)
            {
                Console.WriteLine("Крайният час трябва да е след началния.");
                return;
            }

            Console.Write("ID на маса: ");
            if (!int.TryParse(Console.ReadLine(), out int tableId) || tableId <= 0)
            {
                Console.WriteLine("Невалиден ID на маса.");
                return;
            }

            var occasion = new SpecialOccasion
            {
                Description = description,
                StartTime = start,
                EndTime = end,
                TableId = tableId
            };

            _occasionService.AddSpecialOccasion(occasion);
            Console.WriteLine("Поводът е добавен успешно.");
        }

        private void ViewOccasions()
        {
            var occasions = _occasionService.GetAllOccasions();
            Console.WriteLine("Списък с поводи:");
            foreach (var o in occasions)
            {
                Console.WriteLine($"ID: {o.Id}, Описание: {o.Description}, Начало: {o.StartTime}, Край: {o.EndTime}, Маса: {o.Table?.Number ?? o.TableId}");
            }
        }

        private void EditOccasion()
        {
            Console.Write("ID на повода за редактиране: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Невалиден ID.");
                return;
            }

            var existing = _occasionService.GetOccasionById(id);
            if (existing == null)
            {
                Console.WriteLine("Поводът не е намерен.");
                return;
            }

            Console.Write($"Ново описание (текущо: {existing.Description}): ");
            var descInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(descInput))
                existing.Description = descInput;

            Console.Write($"Нов начален час (текущ: {existing.StartTime}, формат yyyy-MM-dd HH:mm): ");
            var startInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(startInput) &&
                DateTime.TryParseExact(startInput, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime newStart))
                existing.StartTime = newStart;

            Console.Write($"Нов краен час (текущ: {existing.EndTime}, формат yyyy-MM-dd HH:mm): ");
            var endInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(endInput) &&
                DateTime.TryParseExact(endInput, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime newEnd))
                existing.EndTime = newEnd;

            if (existing.EndTime <= existing.StartTime)
            {
                Console.WriteLine("Крайният час трябва да е след началния.");
                return;
            }

            Console.Write($"Нов ID на маса (текущ: {existing.TableId}): ");
            var tableInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(tableInput) && int.TryParse(tableInput, out int newTableId) && newTableId > 0)
                existing.TableId = newTableId;

            bool updated = _occasionService.UpdateOccasion(existing);
            Console.WriteLine(updated ? "Поводът е обновен успешно." : "Грешка при обновяване.");
        }

        private void DeleteOccasion()
        {
            Console.Write("ID на повода за изтриване: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                bool deleted = _occasionService.DeleteOccasion(id);
                Console.WriteLine(deleted ? "Поводът е изтрит успешно." : "Поводът не е намерен.");
            }
            else
            {
                Console.WriteLine("Невалиден ID.");
            }
        }
    }
}
