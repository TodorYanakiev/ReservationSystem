using BusinessLogic.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    /// <summary>
    /// Provides business logic for managing special occasions in the restaurant reservation system.
    /// </summary>
    public class SpecialOccasionService
    {
        private readonly RestaurantDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpecialOccasionService"/> class.
        /// </summary>
        /// <param name="context">The database context for accessing special occasion data.</param>
        public SpecialOccasionService(RestaurantDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new special occasion to the database.
        /// </summary>
        /// <param name="occasion">The special occasion to add.</param>
        public void AddSpecialOccasion(SpecialOccasion occasion)
        {
            _context.SpecialOccasions.Add(occasion);
            _context.SaveChanges();
        }

        /// <summary>
        /// Retrieves all special occasions, including related table data.
        /// </summary>
        /// <returns>A list of all special occasions with their associated tables.</returns>
        public List<SpecialOccasion> GetAllOccasions()
        {
            return _context.SpecialOccasions
                .Include(o => o.Table)
                .ToList();
        }

        /// <summary>
        /// Retrieves a special occasion by its ID, including related table data.
        /// </summary>
        /// <param name="id">The ID of the special occasion to retrieve.</param>
        /// <returns>The matching <see cref="SpecialOccasion"/> if found; otherwise, <c>null</c>.</returns>
        public SpecialOccasion? GetOccasionById(int id)
        {
            return _context.SpecialOccasions
                .Include(o => o.Table)
                .FirstOrDefault(o => o.Id == id);
        }

        /// <summary>
        /// Updates an existing special occasion's details.
        /// </summary>
        /// <param name="updatedOccasion">The updated special occasion object.</param>
        /// <returns><c>true</c> if the update was successful; otherwise, <c>false</c>.</returns>
        public bool UpdateOccasion(SpecialOccasion updatedOccasion)
        {
            var existing = _context.SpecialOccasions.Find(updatedOccasion.Id);
            if (existing == null) return false;

            existing.TableId = updatedOccasion.TableId;
            existing.StartTime = updatedOccasion.StartTime;
            existing.EndTime = updatedOccasion.EndTime;
            existing.Description = updatedOccasion.Description;

            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Deletes a special occasion by its ID.
        /// </summary>
        /// <param name="id">The ID of the occasion to delete.</param>
        /// <returns><c>true</c> if the deletion was successful; otherwise, <c>false</c>.</returns>
        public bool DeleteOccasion(int id)
        {
            var occasion = _context.SpecialOccasions.Find(id);
            if (occasion == null) return false;

            _context.SpecialOccasions.Remove(occasion);
            _context.SaveChanges();
            return true;
        }
    }
}
