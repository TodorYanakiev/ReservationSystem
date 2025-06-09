using BusinessLogic.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ReservationSystem.Models;
using System;
using System.Linq;

namespace ReservationSystem.Tests
{
    [TestFixture]
    public class SpecialOccasionService_AddTests
    {
        private RestaurantDbContext _context;
        private SpecialOccasionService _service;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<RestaurantDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) 
                .Options;

            _context = new RestaurantDbContext(options);
            _service = new SpecialOccasionService(_context);


            var table1 = new RestaurantTable { Id = 1, Number = 101, Type = "Type1" };
            var table2 = new RestaurantTable { Id = 2, Number = 102, Type = "Type2" };
            _context.RestaurantTables.AddRange(table1, table2);

            _context.SpecialOccasions.AddRange(
                new SpecialOccasion
                {
                    Id = 1,
                    TableId = 1,
                    Description = "Occasion 1",
                    StartTime = DateTime.Now.AddHours(-2),
                    EndTime = DateTime.Now.AddHours(-1)
                },
                new SpecialOccasion
                {
                    Id = 2,
                    TableId = 2,
                    Description = "Occasion 2",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddHours(1)
                }
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
        public void AddSpecialOccasion_ValidOccasion_ShouldBeSaved()
        {
            var myOccasion = new SpecialOccasion
            {
                TableId = 100,
                Description = "Test Birthday",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(2)
            };

            _service.AddSpecialOccasion(myOccasion);

            var result = _context.SpecialOccasions.FirstOrDefault(o => o.Description == "Test Birthday");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Description, Is.EqualTo("Test Birthday"));
            Assert.That(result.TableId, Is.EqualTo(100));
        }


        [Test]
        public void AddSpecialOccasion_NullOccasion_ShouldThrow()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _service.AddSpecialOccasion(null!);
            });
        }

        [Test]
        public void AddSpecialOccasion_MissingDescription_ShouldBeSaved()
        {
            var occasion = new SpecialOccasion
            {
                TableId = 2,
                Description = null,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1)
            };

            _service.AddSpecialOccasion(occasion);

            var saved = _context.SpecialOccasions
                .OrderByDescending(o => o.Id)
                .FirstOrDefault(o => o.StartTime == occasion.StartTime && o.EndTime == occasion.EndTime && o.TableId == occasion.TableId);

            Assert.That(saved, Is.Not.Null);
            Assert.That(saved.Description, Is.Null);
        }


        [Test]
        public void AddSpecialOccasion_StartTimeAfterEndTime_ShouldBeSaved()
        {
            var occasion = new SpecialOccasion
            {
                TableId = 3,
                Description = "Backwards Time",
                StartTime = DateTime.Now.AddHours(3),
                EndTime = DateTime.Now
            };

            _service.AddSpecialOccasion(occasion);

            var saved = _context.SpecialOccasions
                .OrderByDescending(o => o.Id)
                .FirstOrDefault(o => o.Description == "Backwards Time");

            Assert.That(saved, Is.Not.Null);
            Assert.That(saved.Description, Is.EqualTo("Backwards Time"));
            Assert.That(saved.StartTime, Is.EqualTo(occasion.StartTime).Within(TimeSpan.FromSeconds(1)));
            Assert.That(saved.EndTime, Is.EqualTo(occasion.EndTime).Within(TimeSpan.FromSeconds(1)));
        }


        [Test]
        public void GetAllOccasions_ShouldReturnAllOccasionsWithTables()
        {
            var occasions = _service.GetAllOccasions();

            Assert.That(occasions, Has.Count.EqualTo(2));
            Assert.That(occasions.All(o => o.Table != null), Is.True);
            Assert.That(occasions.Select(o => o.Description), Does.Contain("Occasion 1").And.Contain("Occasion 2"));
        }

        [Test]
        public void GetOccasionById_ExistingId_ShouldReturnOccasionWithTable()
        {
            var occasion = _service.GetOccasionById(1);

            Assert.That(occasion, Is.Not.Null);
            Assert.That(occasion.Id, Is.EqualTo(1));
            Assert.That(occasion.Table, Is.Not.Null);
            Assert.That(occasion.Description, Is.EqualTo("Occasion 1"));
        }

        [Test]
        public void GetOccasionById_NonExistingId_ShouldReturnNull()
        {
            var occasion = _service.GetOccasionById(999);

            Assert.That(occasion, Is.Null);
        }

        [Test]
        public void UpdateOccasion_ExistingOccasion_ShouldUpdateAndReturnTrue()
        {
            var updated = new SpecialOccasion
            {
                Id = 1,
                TableId = 2,
                Description = "Updated Occasion",
                StartTime = DateTime.Now.AddHours(1),
                EndTime = DateTime.Now.AddHours(2)
            };

            var result = _service.UpdateOccasion(updated);

            Assert.That(result, Is.True);

            var dbOccasion = _context.SpecialOccasions.Find(1);
            Assert.That(dbOccasion.Description, Is.EqualTo("Updated Occasion"));
            Assert.That(dbOccasion.TableId, Is.EqualTo(2));
        }

        [Test]
        public void UpdateOccasion_NonExistingOccasion_ShouldReturnFalse()
        {
            var updated = new SpecialOccasion
            {
                Id = 999,
                TableId = 1,
                Description = "No Occasion",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1)
            };

            var result = _service.UpdateOccasion(updated);

            Assert.That(result, Is.False);
        }

        [Test]
        public void DeleteOccasion_ExistingId_ShouldDeleteAndReturnTrue()
        {
            var result = _service.DeleteOccasion(1);

            Assert.That(result, Is.True);
            Assert.That(_context.SpecialOccasions.Find(1), Is.Null);
        }

        [Test]
        public void DeleteOccasion_NonExistingId_ShouldReturnFalse()
        {
            var result = _service.DeleteOccasion(999);

            Assert.That(result, Is.False);
        }
    }
}
