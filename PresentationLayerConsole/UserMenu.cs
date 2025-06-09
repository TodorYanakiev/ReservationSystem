using BusinessLogic.Services;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayerConsole
{
    internal class UserMenu
    {
        private readonly UserService _userService;

        public UserMenu()
        {
            var context = new RestaurantDbContext();
            _userService = new UserService(context);
        }

        public void ShowUserMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Управление на потребители ====");
                Console.WriteLine("1. Добавяне на потребител");
                Console.WriteLine("2. Преглед на всички потребители");
                Console.WriteLine("3. Редактиране на потребител");
                Console.WriteLine("4. Изтриване на потребител");
                Console.WriteLine("5. Проверка за вход");
                Console.WriteLine("0. Назад");
                Console.Write("Изберете опция: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddUser();
                        break;
                    case "2":
                        ViewUsers();
                        break;
                    case "3":
                        EditUser();
                        break;
                    case "4":
                        DeleteUser();
                        break;
                    case "5":
                        ValidateLogin();
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

        private void AddUser()
        {
            string username;
            do
            {
                Console.Write("Потребителско име: ");
                username = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(username))
                    Console.WriteLine("Потребителското име не може да е празно.");
            } while (string.IsNullOrWhiteSpace(username));

            string password;
            do
            {
                Console.Write("Парола: ");
                password = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(password))
                    Console.WriteLine("Паролата не може да е празна.");
            } while (string.IsNullOrWhiteSpace(password));

            string role;
            do
            {
                Console.Write("Роля (Admin/User): ");
                role = Console.ReadLine()!.ToLower();
                if (!IsValidRole(role))
                    Console.WriteLine("Невалидна роля. Моля въведете 'Admin' или 'User'.");
            } while (!IsValidRole(role));

            var user = new User
            {
                Username = username,
                Password = password,
                Role = role
            };

            bool added = _userService.AddUser(user);
            Console.WriteLine(added ? "Потребителят е добавен успешно." : "Потребителското име вече съществува.");
        }


        private void ViewUsers()
        {
            var users = _userService.GetAllUsers();
            Console.WriteLine("Списък с потребители:");
            foreach (var u in users)
            {
                Console.WriteLine($"ID: {u.Id}, Потребител: {u.Username}, Роля: {u.Role}");
            }
        }

        private void EditUser()
        {
            Console.Write("ID на потребителя за редактиране: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Невалиден ID.");
                return;
            }

            var user = _userService.GetUserById(id);
            if (user == null)
            {
                Console.WriteLine("Потребителят не е намерен.");
                return;
            }

            Console.Write($"Ново потребителско име (текущо: {user.Username}): ");
            string? newUsername = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newUsername))
                user.Username = newUsername;

            string newPassword;
            do
            {
                Console.Write("Нова парола: ");
                newPassword = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(newPassword))
                    Console.WriteLine("Паролата не може да е празна.");
            } while (string.IsNullOrWhiteSpace(newPassword));
            user.Password = newPassword;

            Console.Write($"Нова роля (текуща: {user.Role}): ");
            string? newRole = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newRole))
            {
                if (!IsValidRole(newRole))
                {
                    Console.WriteLine("Невалидна роля. Допустими: Admin, User.");
                    return;
                }
                user.Role = newRole;
            }

            bool updated = _userService.UpdateUser(user);
            Console.WriteLine(updated ? "Потребителят е обновен успешно." : "Неуспешна редакция. Потребителското име може да е заето.");
        }


        private void DeleteUser()
        {
            Console.Write("ID на потребителя за изтриване: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                bool deleted = _userService.DeleteUser(id);
                Console.WriteLine(deleted ? "Потребителят е изтрит успешно." : "Потребителят не е намерен.");
            }
            else
            {
                Console.WriteLine("Невалиден ID.");
            }
        }

        private void ValidateLogin()
        {
            string username;
            do
            {
                Console.Write("Потребителско име: ");
                username = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(username))
                    Console.WriteLine("Потребителското име не може да е празно.");
            } while (string.IsNullOrWhiteSpace(username));

            string password;
            do
            {
                Console.Write("Парола: ");
                password = Console.ReadLine()!;
                if (string.IsNullOrWhiteSpace(password))
                    Console.WriteLine("Паролата не може да е празна.");
            } while (string.IsNullOrWhiteSpace(password));

            bool isValid = _userService.ValidateLogin(username, password);
            Console.WriteLine(isValid ? "Входът е успешен." : "Грешно потребителско име или парола.");
        }


        private bool IsValidRole(string role)
        {
            return role.Equals("Admin", StringComparison.OrdinalIgnoreCase) ||
                   role.Equals("User", StringComparison.OrdinalIgnoreCase);
        }

    }
}
