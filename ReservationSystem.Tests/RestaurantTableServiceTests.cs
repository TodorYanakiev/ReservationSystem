using NUnit.Framework;
using BusinessLogic.Services;
using Microsoft.EntityFrameworkCore;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReservationSystem.Tests
{
    [TestFixture]
    public class RestaurantTableServiceTests
    {
        private RestaurantDbContext _context;
        private RestaurantTableService _service;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<RestaurantDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new RestaurantDbContext(options);
            _service = new RestaurantTableService(_context);

            _context.RestaurantTables.AddRange(
                new RestaurantTable { Id = 1, Number = 101, Type = "VIP", Description = "Window", CreatedAt = DateTime.Now },
                new RestaurantTable { Id = 2, Number = 102, Type = "Regular", Description = "Near door", CreatedAt = DateTime.Now }
            );

            _context.SaveChanges();
        }

        [TearDown]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public void AddTable_ValidTable_ShouldBeSaved()
        {
            var table = new RestaurantTable { Number = 103, Type = "Outdoor" };

            _service.AddTable(table);

            var saved = _context.RestaurantTables.FirstOrDefault(t => t.Number == 103);
            Assert.That(saved, Is.Not.Null);
            Assert.That(saved.CreatedAt, Is.Not.EqualTo(default(DateTime)));
        }

        [Test]
        public void GetAllTables_ShouldReturnOnlyNonDeletedTables()
        {
            var deletedTable = new RestaurantTable { Id = 3, Number = 104, Type = "Test", DeletedAt = DateTime.Now };
            _context.RestaurantTables.Add(deletedTable);
            _context.SaveChanges();

            var result = _service.GetAllTables();

            Assert.That(result.Count, Is.EqualTo(2)); // Not including deleted
            Assert.That(result.Any(t => t.Id == 3), Is.False);
        }

        [Test]
        public void GetTableById_ExistingAndNotDeleted_ShouldReturnTable()
        {
            var table = _service.GetTableById(1);

            Assert.That(table, Is.Not.Null);
            Assert.That(table.Number, Is.EqualTo(101));
        }

        [Test]
        public void GetTableById_NonExisting_ShouldReturnNull()
        {
            var table = _service.GetTableById(999);

            Assert.That(table, Is.Null);
        }

        [Test]
        public void GetTableById_DeletedTable_ShouldReturnNull()
        {
            var table = _context.RestaurantTables.Find(1);
            table.DeletedAt = DateTime.Now;
            _context.SaveChanges();

            var result = _service.GetTableById(1);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void UpdateTable_ExistingAndNotDeleted_ShouldUpdateAndReturnTrue()
        {
            var updated = new RestaurantTable
            {
                Id = 1,
                Number = 777,
                Type = "Updated",
                Description = "Updated description"
            };

            var result = _service.UpdateTable(updated);

            Assert.That(result, Is.True);
            var dbTable = _context.RestaurantTables.Find(1);
            Assert.That(dbTable.Number, Is.EqualTo(777));
            Assert.That(dbTable.Type, Is.EqualTo("Updated"));
        }

        [Test]
        public void UpdateTable_DeletedTable_ShouldReturnFalse()
        {
            var table = _context.RestaurantTables.Find(1);
            table.DeletedAt = DateTime.Now;
            _context.SaveChanges();

            var result = _service.UpdateTable(new RestaurantTable
            {
                Id = 1,
                Number = 500,
                Type = "Hidden"
            });

            Assert.That(result, Is.False);
        }

        [Test]
        public void UpdateTable_NonExistingTable_ShouldReturnFalse()
        {
            var result = _service.UpdateTable(new RestaurantTable
            {
                Id = 999,
                Number = 500,
                Type = "Ghost"
            });

            Assert.That(result, Is.False);
        }

        [Test]
        public void DeleteTable_ExistingAndNotDeleted_ShouldSetDeletedAt()
        {
            var result = _service.DeleteTable(1);

            Assert.That(result, Is.True);
            Assert.That(_context.RestaurantTables.Find(1).DeletedAt, Is.Not.Null);
        }

        [Test]
        public void DeleteTable_DeletedTable_ShouldReturnFalse()
        {
            var table = _context.RestaurantTables.Find(1);
            table.DeletedAt = DateTime.Now;
            _context.SaveChanges();

            var result = _service.DeleteTable(1);
            Assert.That(result, Is.False);
        }

        [Test]
        public void DeleteTable_NonExisting_ShouldReturnFalse()
        {
            var result = _service.DeleteTable(999);

            Assert.That(result, Is.False);
        }

        /*[Test]
        public void GetFreeTableIdsForDate_ShouldReturnUnreservedTableIds()
        {
            // Arrange mock operating hours
            var opHours = new List<OperatingHour>
            {
                new OperatingHour { TableId = 1, DayOfWeek = DayOfWeek.Monday },
                new OperatingHour { TableId = 2, DayOfWeek = DayOfWeek.Monday }
            };
            _context.OperatingHours.AddRange(opHours);

            var reservationService = new ReservationService(_context);
            var reservation = new Reservation
            {
                TableId = 1,
                Date = DateOnly.FromDateTime(DateTime.Today),
                Name = "Reserved"
            };
            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            var result = _service.GetFreeTableIdsForDate(DateOnly.FromDateTime(DateTime.Today), reservationService);

            Assert.That(result, Contains.Item(2));
            Assert.That(result, Does.Not.Contain(1));
        }*/
    }
}
