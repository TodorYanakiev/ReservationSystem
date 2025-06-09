using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    /// <summary>
    /// Provides business logic for managing user accounts in the restaurant reservation system.
    /// Includes functionalities such as registration, login validation, and user CRUD operations.
    /// </summary>
    public class UserService
    {
        private readonly RestaurantDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="context">The database context for user data.</param>
        public UserService(RestaurantDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new user to the system after checking for username uniqueness and hashing the password.
        /// </summary>
        /// <param name="user">The user object to add.</param>
        /// <returns><c>true</c> if the user is added successfully; <c>false</c> if the username is already taken.</returns>
        public bool AddUser(User user)
        {
            if (IsUsernameTaken(user.Username))
                return false;

            user.Password = HashPassword(user.Password);
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Retrieves all users in the system.
        /// </summary>
        /// <returns>A list of all registered users.</returns>
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        /// <summary>
        /// Retrieves a user by their unique identifier.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>The user if found; otherwise, <c>null</c>.</returns>
        public User? GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        /// <summary>
        /// Retrieves a user by their username.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>The user if found; otherwise, <c>null</c>.</returns>
        public User? GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        /// <summary>
        /// Updates the information of an existing user.
        /// </summary>
        /// <param name="updatedUser">The user object containing updated data.</param>
        /// <returns>
        /// <c>true</c> if the update was successful;
        /// <c>false</c> if the user does not exist or the new username is already taken.
        /// </returns>
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

        /// <summary>
        /// Deletes a user from the system.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns><c>true</c> if the deletion was successful; otherwise, <c>false</c>.</returns>
        public bool DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Checks if a given username is already taken.
        /// </summary>
        /// <param name="username">The username to check.</param>
        /// <returns><c>true</c> if the username is taken; otherwise, <c>false</c>.</returns>
        public bool IsUsernameTaken(string username)
        {
            return _context.Users.Any(u => u.Username.Equals(username));
        }

        /// <summary>
        /// Validates a user's login credentials.
        /// </summary>
        /// <param name="username">The username entered by the user.</param>
        /// <param name="password">The password entered by the user.</param>
        /// <returns><c>true</c> if the credentials are valid; otherwise, <c>false</c>.</returns>
        public bool ValidateLogin(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null) return false;

            string hashedPassword = HashPassword(password);
            return user.Password == hashedPassword;
        }

        /// <summary>
        /// Hashes a plain text password using SHA256 for secure storage.
        /// </summary>
        /// <param name="password">The plain text password to hash.</param>
        /// <returns>The hashed password as a Base64-encoded string.</returns>
        private string HashPassword(string password)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
