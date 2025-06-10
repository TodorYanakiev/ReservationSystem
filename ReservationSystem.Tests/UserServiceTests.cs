using NUnit.Framework;
using BusinessLogic.Services;
using ReservationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace ReservationSystem.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private RestaurantDbContext _context;
        private UserService _service;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<RestaurantDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new RestaurantDbContext(options);
            _service = new UserService(_context);

            _context.Users.AddRange(
                new User { Id = 1, Username = "alice", Password = "secret1", Role = "Admin" },
                new User { Id = 2, Username = "bob", Password = "secret2", Role = "User" }
            );
            _context.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public void AddUser_UniqueUsername_ShouldAddSuccessfully()
        {
            var user = new User { Username = "charlie", Password = "1234", Role = "User" };

            var result = _service.AddUser(user);

            Assert.That(result, Is.True);
            Assert.That(_context.Users.Count(), Is.EqualTo(3));
            Assert.That(_context.Users.Any(u => u.Username == "charlie"), Is.True);
        }

        [Test]
        public void AddUser_UsernameTaken_ShouldFail()
        {
            var user = new User { Username = "alice", Password = "newpass", Role = "Admin" };

            var result = _service.AddUser(user);

            Assert.That(result, Is.False);
            Assert.That(_context.Users.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GetAllUsers_ShouldReturnAllUsers()
        {
            var users = _service.GetAllUsers();
            Assert.That(users.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetUserById_ExistingId_ShouldReturnUser()
        {
            var user = _service.GetUserById(1);
            Assert.That(user.Username, Is.EqualTo("alice"));
        }

        [Test]
        public void GetUserById_NonExistingId_ShouldReturnNull()
        {
            var user = _service.GetUserById(999);
            Assert.That(user, Is.Null);
        }

        [Test]
        public void GetUserByUsername_Existing_ShouldReturnUser()
        {
            var user = _service.GetUserByUsername("bob");
            Assert.That(user.Id, Is.EqualTo(2));
        }

        [Test]
        public void GetUserByUsername_NonExisting_ShouldReturnNull()
        {
            var user = _service.GetUserByUsername("ghost");

            Assert.That(user, Is.Null);
        }

        [Test]
        public void UpdateUser_ValidUpdate_ShouldApplyChanges()
        {
            var updatedUser = new User
            {
                Id = 1,
                Username = "alice_updated",
                Password = "newpass",
                Role = "SuperAdmin"
            };

            var result = _service.UpdateUser(updatedUser);

            Assert.That(result, Is.True);

            var fromDb = _context.Users.Find(1);
            Assert.That(fromDb.Username, Is.EqualTo("alice_updated"));
            Assert.That(fromDb.Role, Is.EqualTo("SuperAdmin"));
            Assert.That(fromDb.Password, Is.Not.EqualTo("newpass"));
        }


        [Test]
        public void UpdateUser_UsernameConflict_ShouldFail()
        {
            var updatedUser = new User
            {
                Id = 1,
                Username = "bob", 
                Password = "test",
                Role = "Admin"
            };

            var result = _service.UpdateUser(updatedUser);

            Assert.That(result, Is.False);
        }

        [Test]
        public void UpdateUser_NonExistingId_ShouldFail()
        {
            var fakeUser = new User
            {
                Id = 999,
                Username = "ghost",
                Password = "pass",
                Role = "Admin"
            };

            var result = _service.UpdateUser(fakeUser);

            Assert.That(result, Is.False);
        }

        [Test]
        public void DeleteUser_Existing_ShouldRemoveUser()
        {
            var result = _service.DeleteUser(1);
            Assert.That(result, Is.True);
            Assert.That(_context.Users.Find(1), Is.Null);
        }

        [Test]
        public void DeleteUser_NonExisting_ShouldReturnFalse()
        {
            var result = _service.DeleteUser(999);

            Assert.That(result, Is.False);
        }

        [Test]
        public void IsUsernameTaken_TakenUsername_ShouldReturnTrue()
        {
            var result = _service.IsUsernameTaken("alice");
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsUsernameTaken_AvailableUsername_ShouldReturnFalse()
        {
            var result = _service.IsUsernameTaken("daisy");

            Assert.That(result, Is.False);
        }

        [Test]
        public void ValidateLogin_CorrectCredentials_ShouldReturnTrue()
        {
            var password = "secret1";
            var user = _context.Users.Find(1);
            var hashMethod = typeof(UserService).GetMethod("HashPassword", BindingFlags.NonPublic | BindingFlags.Instance);
            user.Password = hashMethod.Invoke(_service, new object[] { password })!.ToString();
            _context.SaveChanges();

            var result = _service.ValidateLogin("alice", "secret1");

            Assert.That(result, Is.True);
        }

        [Test]
        public void ValidateLogin_WrongPassword_ShouldReturnFalse()
        {
            var password = "secret1";
            var user = _context.Users.Find(1);
            var hashMethod = typeof(UserService).GetMethod("HashPassword", BindingFlags.NonPublic | BindingFlags.Instance);
            user.Password = hashMethod.Invoke(_service, new object[] { password })!.ToString();
            _context.SaveChanges();

            var result = _service.ValidateLogin("alice", "wrong");

            Assert.That(result, Is.False);
        }

        [Test]
        public void ValidateLogin_NonExistingUser_ShouldReturnFalse()
        {
            var result = _service.ValidateLogin("ghost", "whatever");

            Assert.That(result, Is.False);
        }
    }
}
