using BusinessLogic.Services;
using Microsoft.EntityFrameworkCore;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Tests
{
    [TestFixture]
    public class ReservationServiceTests
    {
        private RestaurantDbContext _context;
        private ReservationService _service;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<RestaurantDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new RestaurantDbContext(options);
            _service = new ReservationService(_context);

            // Add OperatingHour with required fields
            _context.OperatingHours.Add(new OperatingHour
            {
                Id = 1,
                DayOfWeek = DayOfWeek.Monday.ToString(),            // required enum
                StartTime = new TimeOnly(9, 0, 0),     // example opening time
                EndTime = new TimeOnly(18, 0, 0)     // example closing time
            });

            // Add RestaurantTable with required fields
            _context.RestaurantTables.Add(new RestaurantTable
            {
                Id = 1,
                Number = 101,           // assuming Number is required
                Type = "Regular",       // assuming Type is required
                Description = "Main hall"
            });

            _context.SaveChanges();
        }


        [TearDown]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public void CreateReservation_InvalidEmail_Throws()
        {
            var reservation = GetValidReservation();
            reservation.Email = "invalid";

            var ex = Assert.ThrowsAsync<ArgumentException>(() => _service.CreateReservation(reservation));
            Assert.That(ex.Message, Does.Contain("Невалиден имейл"));
        }

        [Test]
        public void GetReservationById_ValidId_ReturnsReservation()
        {
            var reservation = GetValidReservation();
            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            var result = _service.GetReservationById(reservation.Id);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void GetReservationById_InvalidId_Throws()
        {
            var ex = Assert.Throws<ArgumentException>(() => _service.GetReservationById(999));
            Assert.That(ex.Message, Does.Contain("does not exist"));
        }

        [Test]
        public void GetAllReservations_ReturnsAll()
        {
            _context.Reservations.AddRange(GetValidReservation(), GetValidReservation());
            _context.SaveChanges();
            var result = _service.GetAllReservations();
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void UpdateReservation_Conflict_Throws()
        {
            var r1 = GetValidReservation();
            var r2 = GetValidReservation();
            r2.Id = 2;
            _context.Reservations.AddRange(r1, r2);
            _context.SaveChanges();

            r2.ReservationDate = r1.ReservationDate;

            var ex = Assert.ThrowsAsync<ArgumentException>(() => _service.UpdateReservation(r2));
            Assert.That(ex.Message, Does.Contain("existing reservation"));
        }

        private Reservation GetValidReservation()
        {
            return new Reservation
            {
                Id = new Random().Next(1000),
                Name = "Test Name",
                Email = "test@example.com",
                PhoneNumber = "123456789",
                TableId = 1,
                OperatingHoursId = 1,
                ReservationDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1))
            };
        }
    }
}

