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
    public class SpecialOccasionService
    {
        private readonly RestaurantDbContext _context;

        public SpecialOccasionService(RestaurantDbContext context)
        {
            _context = context;
        }

        public void AddSpecialOccasion(SpecialOccasion occasion)
        {
            _context.SpecialOccasions.Add(occasion);
            _context.SaveChanges();
        }

        public List<SpecialOccasion> GetAllOccasions()
        {
            return _context.SpecialOccasions
                .Include(o => o.Table)
                .ToList();
        }

        public SpecialOccasion? GetOccasionById(int id)
        {
            return _context.SpecialOccasions
                .Include(o => o.Table)
                .FirstOrDefault(o => o.Id == id);
        }

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