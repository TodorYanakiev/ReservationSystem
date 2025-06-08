using BusinessLogic.Services;
using Microsoft.EntityFrameworkCore;
using ReservationSystem.Models;

namespace ReservationSystem.Tests
{
    public class SpecialOccasionServiceTests
    {
        private RestaurantDbContext _context;
        private SpecialOccasionService _service;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<RestaurantDbContext>()
                .UseInMemoryDatabase("TestDb")
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
        public void AddSpecialOccasion_ShouldSaveOccasion()
        {
            var occasion = new SpecialOccasion
            {
                TableId = 1,
                Description = "Birthday",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(2)
            };

            _service.AddSpecialOccasion(occasion);
            var result = _context.SpecialOccasions.FirstOrDefault();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Description, Is.EqualTo("Birthday"));
        }

        [Test]
        public void GetOccasionById_ShouldReturnCorrect()
        {
            var occasion = new SpecialOccasion { TableId = 2, Description = "Anniversary" };
            _context.SpecialOccasions.Add(occasion);
            _context.SaveChanges();

            var result = _service.GetOccasionById(occasion.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Description, Is.EqualTo("Anniversary"));
        }

        [Test]
        public void DeleteOccasion_ShouldRemoveItem()
        {
            var occasion = new SpecialOccasion { TableId = 3, Description = "Remove me" };
            _context.SpecialOccasions.Add(occasion);
            _context.SaveChanges();

            var deleted = _service.DeleteOccasion(occasion.Id);

            Assert.That(deleted, Is.True);
            Assert.That(_context.SpecialOccasions.Find(occasion.Id), Is.Null);
        }

        [Test]
        public void UpdateOccasion_ShouldUpdateFields()
        {
            var occasion = new SpecialOccasion { TableId = 4, Description = "Old" };
            _context.SpecialOccasions.Add(occasion);
            _context.SaveChanges();

            occasion.Description = "Updated";
            var updated = _service.UpdateOccasion(occasion);

            Assert.That(updated, Is.True);
            Assert.That(_context.SpecialOccasions.Find(occasion.Id)?.Description, Is.EqualTo("Updated"));
        }

        [Test]
        public void GetAllOccasions_ShouldReturnAll()
        {
            _context.SpecialOccasions.Add(new SpecialOccasion { TableId = 1, Description = "One" });
            _context.SpecialOccasions.Add(new SpecialOccasion { TableId = 2, Description = "Two" });
            _context.SaveChanges();

            var list = _service.GetAllOccasions();

            Assert.That(list.Count, Is.EqualTo(2));
        }
    }
}
