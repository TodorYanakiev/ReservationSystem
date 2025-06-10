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
    internal class OperatingHourServiceTest
    {
        [TestFixture]
        public class OperatingHourServiceTests
        {
            private RestaurantDbContext _context;
            private OperatingHourService _service;

            [SetUp]
            public void Setup()
            {
                var options = new DbContextOptionsBuilder<RestaurantDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

                _context = new RestaurantDbContext(options);
                _service = new OperatingHourService(_context);

                var table = new RestaurantTable { Id = 1, Number = 101, Type = "VIP", CreatedAt = DateTime.Now };
                _context.RestaurantTables.Add(table);
                _context.SaveChanges();
            }

            [TearDown]
            public void Cleanup()
            {
                _context.Database.EnsureDeleted();
                _context.Dispose();
            }

            [Test]
            public void CreateSingleOperatingHour_Valid_ShouldBeSaved()
            {
                var hour = new OperatingHour
                {
                    DayOfWeek = "Monday",
                    StartTime = new TimeOnly(9, 0),
                    EndTime = new TimeOnly(10, 0),
                    TableId = 1
                };

                _service.CreateSingleOperatingHour(hour);

                Assert.That(_context.OperatingHours.Count(), Is.EqualTo(1));
            }

            [Test]
            public void CreateSingleOperatingHour_EndTimeBeforeStartTime_ShouldThrow()
            {
                var hour = new OperatingHour
                {
                    DayOfWeek = "Monday",
                    StartTime = new TimeOnly(11, 0),
                    EndTime = new TimeOnly(10, 0),
                    TableId = 1
                };

                var ex = Assert.Throws<ArgumentException>(() => _service.CreateSingleOperatingHour(hour));
                Assert.That(ex.Message, Does.Contain("ending hour is before"));
            }

            [Test]
            public void CreateSingleOperatingHour_Overlapping_ShouldThrow()
            {
                _service.CreateSingleOperatingHour(new OperatingHour
                {
                    DayOfWeek = "Monday",
                    StartTime = new TimeOnly(9, 0),
                    EndTime = new TimeOnly(10, 0),
                    TableId = 1
                });

                var overlapping = new OperatingHour
                {
                    DayOfWeek = "Monday",
                    StartTime = new TimeOnly(9, 30),
                    EndTime = new TimeOnly(10, 30),
                    TableId = 1
                };

                var ex = Assert.Throws<ArgumentException>(() => _service.CreateSingleOperatingHour(overlapping));
                Assert.That(ex.Message, Does.Contain("overlapping"));
            }

            [Test]
            public void CreateMultipleOperatingHours_Valid_ShouldSaveAll()
            {
                var days = new List<string> { "Monday", "Tuesday" };
                var starts = new List<TimeOnly> { new TimeOnly(9, 0) };
                var ends = new List<TimeOnly> { new TimeOnly(10, 0) };
                var tables = new List<int> { 1 };

                _service.CreateMultipleOperatingHours(days, starts, ends, tables);

                Assert.That(_context.OperatingHours.Count(), Is.EqualTo(2));
            }

            [Test]
            public void CreateMultipleOperatingHours_MismatchedStartEndLists_ShouldThrow()
            {
                var ex = Assert.Throws<ArgumentException>(() =>
                    _service.CreateMultipleOperatingHours(
                        new List<string> { "Monday" },
                        new List<TimeOnly> { new TimeOnly(9, 0) },
                        new List<TimeOnly> { }, // empty end times
                        new List<int> { 1 }));

                Assert.That(ex.Message, Does.Contain("number of starting and ending hours must be the same"));
            }

            [Test]
            public void GetAllOperatingHours_ShouldReturnAll()
            {
                _service.CreateSingleOperatingHour(new OperatingHour
                {
                    DayOfWeek = "Wednesday",
                    StartTime = new TimeOnly(12, 0),
                    EndTime = new TimeOnly(13, 0),
                    TableId = 1
                });

                var result = _service.GetAllOperatingHours();

                Assert.That(result.Count, Is.EqualTo(1));
                Assert.That(result.First().TableId, Is.EqualTo(1));
            }

            [Test]
            public void GetOperatingHoursByTableId_ShouldReturnCorrectOnes()
            {
                _service.CreateSingleOperatingHour(new OperatingHour
                {
                    DayOfWeek = "Friday",
                    StartTime = new TimeOnly(15, 0),
                    EndTime = new TimeOnly(16, 0),
                    TableId = 1
                });

                var result = _service.GetOperatingHoursByTableId(1);
                Assert.That(result.Count, Is.EqualTo(1));
            }

            [Test]
            public void GetOperatingHoursByDayOfWeek_ShouldReturnCorrectOnes()
            {
                _service.CreateSingleOperatingHour(new OperatingHour
                {
                    DayOfWeek = "Saturday",
                    StartTime = new TimeOnly(10, 0),
                    EndTime = new TimeOnly(11, 0),
                    TableId = 1
                });

                var result = _service.GetOperatingHoursByDayOfWeek("Saturday");
                Assert.That(result.Count, Is.EqualTo(1));
            }

            [Test]
            public void UpdateOperatingHour_Valid_ShouldUpdate()
            {
                var hour = new OperatingHour
                {
                    DayOfWeek = "Monday",
                    StartTime = new TimeOnly(9, 0),
                    EndTime = new TimeOnly(10, 0),
                    TableId = 1
                };
                _service.CreateSingleOperatingHour(hour);
                var id = _context.OperatingHours.First().Id;

                var updated = new OperatingHour
                {
                    Id = id,
                    DayOfWeek = "Monday",
                    StartTime = new TimeOnly(10, 0),
                    EndTime = new TimeOnly(11, 0),
                    TableId = 1
                };

                _service.UpdateOperatingHour(updated);

                var result = _context.OperatingHours.Find(id);
                Assert.That(result.StartTime, Is.EqualTo(new TimeOnly(10, 0)));
            }

            [Test]
            public void UpdateOperatingHour_NonExisting_ShouldThrow()
            {
                var hour = new OperatingHour
                {
                    Id = 999,
                    DayOfWeek = "Tuesday",
                    StartTime = new TimeOnly(9, 0),
                    EndTime = new TimeOnly(10, 0),
                    TableId = 1
                };

                var ex = Assert.Throws<ArgumentException>(() => _service.UpdateOperatingHour(hour));
                Assert.That(ex.Message, Does.Contain("does not exist"));
            }

            /*[Test]
            public async Task DeleteOperatingHour_ShouldRemoveAndCancelReservations()
            {
                var table = new RestaurantTable { Id = 1, Number = 101, Type = "VIP", Description = "Test Table" };
                _context.RestaurantTables.Add(table);

                var opHour = new OperatingHour
                {
                    Id = 1,
                    Table = table,
                    TableId = table.Id,
                    DayOfWeek = "Monday",
                    StartTime = new TimeOnly(10, 0),
                    EndTime = new TimeOnly(12, 0)
                };
                _context.OperatingHours.Add(opHour);

                var reservation = new Reservation
                {
                    Id = 1,
                    OperatingHours = opHour,
                    OperatingHoursId = opHour.Id,
                    Email = "test@example.com",
                    ReservationDate = DateOnly.FromDateTime(DateTime.Today),
                    Name = "John Doe",
                    PhoneNumber = "1234567890"
                };
                _context.Reservations.Add(reservation);
                _context.SaveChanges();

                await _service.DeleteOperatingHour(opHour);

                Assert.That(_context.OperatingHours.Any(), Is.False);
                Assert.That(_context.Reservations.Any(), Is.False);
            }

            [Test]
            public void GetFreeOperatingHoursForTableAndDate_WithReservation_ShouldExcludeReserved()
            {
                var table = new RestaurantTable { Id = 1, Number = 101, Type = "VIP" };
                _context.RestaurantTables.Add(table);

                var opHour1 = new OperatingHour
                {
                    Id = 1,
                    DayOfWeek = DateTime.Today.DayOfWeek.ToString(),
                    StartTime = new TimeOnly(10, 0),
                    EndTime = new TimeOnly(11, 0),
                    Table = table,
                    TableId = table.Id
                };

                var opHour2 = new OperatingHour
                {
                    Id = 2,
                    DayOfWeek = DateTime.Today.DayOfWeek.ToString(),
                    StartTime = new TimeOnly(11, 0),
                    EndTime = new TimeOnly(12, 0),
                    Table = table,
                    TableId = table.Id
                };

                _context.OperatingHours.AddRange(opHour1, opHour2);
                _context.SaveChanges();

                var reservation = new Reservation
                {
                    Id = 1,
                    OperatingHoursId = opHour1.Id,
                    Email = "test@example.com",
                    ReservationDate = DateOnly.FromDateTime(DateTime.Today),
                    Name = "Jane Smith",
                    PhoneNumber = "9876543210"
                };

                _context.Reservations.Add(reservation);
                _context.SaveChanges();

                var reservationService = new ReservationService(_context);
                var freeHours = _service.GetFreeOperatingHoursForTableAndDate(table.Id, DateOnly.FromDateTime(DateTime.Today), reservationService);

                Assert.That(freeHours.Count, Is.EqualTo(1));
                Assert.That(freeHours.First().Id, Is.EqualTo(opHour2.Id));
            }*/

        }
    }
}
