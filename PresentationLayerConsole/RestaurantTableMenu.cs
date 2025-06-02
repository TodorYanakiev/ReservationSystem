using BusinessLogic.Services;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayerConsole
{
    internal class RestaurantTableMenu
    {
        private readonly RestaurantTableService _tableService;

        public RestaurantTableMenu()
        {
            _tableService = new RestaurantTableService(new RestaurantDbContext());
        }

        public void ShowRestaurantTableMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Управление на маси ====");
                Console.WriteLine("1. Добавяне на маса");
                Console.WriteLine("2. Преглед на всички маси");
                Console.WriteLine("3. Редактиране на маса");
                Console.WriteLine("4. Изтриване на маса");
                Console.WriteLine("0. Назад");
                Console.Write("Изберете опция: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddTable();
                        break;
                    case "2":
                        ViewTables();
                        break;
                    case "3":
                        EditTable();
                        break;
                    case "4":
                        DeleteTable();
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

        private string PromptForTableType(string? currentType = null)
        {
            while (true)
            {
                if (currentType != null)
                    Console.Write($"Нов тип (текущ: {currentType}) (вътрешна/външна/вип): ");
                else
                    Console.Write("Тип маса (вътрешна/външна/вип): ");

                var input = Console.ReadLine()?.Trim().ToLower();

                switch (input)
                {
                    case "вътрешна": return "standart";
                    case "външна": return "outdoor";
                    case "вип": return "vip";
                }

                Console.WriteLine("Невалиден тип. Моля въведете 'вътрешна', 'външна' или 'вип'.");
            }
        }

        private void AddTable()
        {
            Console.Write("Номер на маса: ");
            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine("Невалиден номер.");
                return;
            }

            string type = PromptForTableType();

            Console.Write("Описание: ");
            string description = Console.ReadLine()!;

            var table = new RestaurantTable
            {
                Number = number,
                Type = type,
                Description = description
            };

            try
            {
                _tableService.AddTable(table);
                Console.WriteLine("Масата е добавена.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Грешка при запис: {ex.Message}");
            }
        }

        private void EditTable()
        {
            Console.Write("ID на масата за редактиране: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Невалиден ID.");
                return;
            }

            var table = _tableService.GetTableById(id);
            if (table == null)
            {
                Console.WriteLine("Масата не е намерена.");
                return;
            }

            Console.Write($"Нов номер (текущ: {table.Number}): ");
            var numberInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(numberInput) && int.TryParse(numberInput, out int newNumber))
                table.Number = newNumber;

            table.Type = PromptForTableType(table.Type);

            Console.Write($"Ново описание (текущо: {table.Description}): ");
            var descriptionInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(descriptionInput))
                table.Description = descriptionInput;

            if (_tableService.UpdateTable(table))
                Console.WriteLine("Масата е обновена.");
            else
                Console.WriteLine("Грешка при обновяване.");
        }

        private void ViewTables()
        {
            var tables = _tableService.GetAllTables();
            Console.WriteLine("Списък с маси:");
            foreach (var t in tables)
            {
                Console.WriteLine($"ID: {t.Id}, Номер: {t.Number}, Тип: {t.Type}, Описание: {t.Description}");
            }
        }


        private void DeleteTable()
        {
            Console.Write("ID на масата за изтриване: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int id) || id <= 0)
            {
                Console.WriteLine("Невалидено ID. Моля, въведете положително цяло число.");
                return;
            }

            if (_tableService.DeleteTable(id))
                Console.WriteLine("Масата е изтрита.");
            else
                Console.WriteLine("Масата не беше намерена или вече е изтрита.");
        }

    }
}