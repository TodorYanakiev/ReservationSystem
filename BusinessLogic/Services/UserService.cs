using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class UserService
    {
        private readonly RestaurantDbContext _context;

        public UserService(RestaurantDbContext context)
        {
            _context = context;
        }

        public bool AddUser(User user)
        {
            if (IsUsernameTaken(user.Username))
                return false;

            user.Password = HashPassword(user.Password);
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User? GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User? GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        public bool UpdateUser(User updatedUser)
        {
            var existing = _context.Users.Find(updatedUser.Id);
            if (existing == null) return false;

            if (existing.Username != updatedUser.Username && IsUsernameTaken(updatedUser.Username))
                return false;

            existing.Username = updatedUser.Username;
            existing.Password = HashPassword(updatedUser.Password); 
            existing.Role = updatedUser.Role;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public bool IsUsernameTaken(string username)
        {
            return _context.Users.Any(u => u.Username.Equals(username));
        }

        public bool ValidateLogin(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null) return false;

            string hashedPassword = HashPassword(password);
            return user.Password == hashedPassword;
        }

        private string HashPassword(string password)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}