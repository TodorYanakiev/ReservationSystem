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
        private readonly UserService _userService;
        private readonly ReservationMenu _reservationMenu;
        private readonly RestaurantTableMenu _restaurantTableMenu;
        private readonly OperatingHourMenu _operatingHourMenu;
        private readonly SpecialOccasionMenu _specialOccasionMenu;
        private readonly UserMenu _userMenu;

        public AdminMenu()
        {
            var dbContext = new RestaurantDbContext();
            _userService = new UserService(dbContext);
            _reservationMenu = new ReservationMenu();
            _restaurantTableMenu = new RestaurantTableMenu();
            _operatingHourMenu = new OperatingHourMenu();
            _specialOccasionMenu = new SpecialOccasionMenu();
            _userMenu = new UserMenu();
        }

        public Task ShowAdminMenu()
        {
            if (!Login())
                return Task.CompletedTask;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Админ меню ====");
                Console.WriteLine("1. Rезервации");
                Console.WriteLine("2. Маси");
                Console.WriteLine("3. Специални поводи");
                Console.WriteLine("4. Администратори");
                Console.WriteLine("5. Работни часове");
                Console.WriteLine("0. Назад");
                Console.Write("Изберете опция: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        _reservationMenu.ShowAdminReservationMenu(); 
                        break;
                    case "2":
                        _restaurantTableMenu.ShowRestaurantTableMenu();
                        break;
                    case "3":
                        _specialOccasionMenu.ShowOccasionMenu();
                        break;
                    case "4":
                        _userMenu.ShowUserMenu();
                        break;
                    case "5":
                        _operatingHourMenu.ShowOperatingHourMenu();
                        break;
                    case "0":
                        return Task.CompletedTask;
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
            const int maxAttempts = 3; 
            int attempts = 0;

            while (attempts < maxAttempts)
            {
                Console.WriteLine("==== Вход за администратор ====");
                Console.Write("Потребителско име: ");
                string username = Console.ReadLine()!;
                Console.Write("Парола: ");
                string password = ReadPassword();

                bool success = _userService.ValidateLogin(username, password);
                if (success)
                {
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
                else
                {
                    attempts++;
                    Console.WriteLine("Невалидни данни за вход.");

                    if (attempts < maxAttempts)
                    {
                        Console.WriteLine($"Остават {maxAttempts - attempts} опита.");
                    }
                    else
                    {
                        Console.WriteLine("Броят опити е изчерпан.");
                        Console.WriteLine("Натиснете Enter за изход...");
                        Console.ReadLine();
                        return false;
                    }
                }
            }
            return false;
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


