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
            var occasion = new SpecialOccasion
            {
                TableId = 1,
                Description = "Test Birthday",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(2)
            };

            _service.AddSpecialOccasion(occasion);

            var result = _context.SpecialOccasions.FirstOrDefault();
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Description, Is.EqualTo("Test Birthday"));
        }

        [Test]
        public void AddSpecialOccasion_NullOccasion_ShouldThrow()
        {
            Assert.Throws<NullReferenceException>(() =>
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
                Description = null, // allowed if DB allows nulls
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1)
            };

            _service.AddSpecialOccasion(occasion);

            var saved = _context.SpecialOccasions.FirstOrDefault();
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

            var saved = _context.SpecialOccasions.FirstOrDefault();
            Assert.That(saved, Is.Not.Null);
            Assert.That(saved.Description, Is.EqualTo("Backwards Time"));
        }
    }
}
