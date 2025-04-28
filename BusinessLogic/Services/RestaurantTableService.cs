using System;
using System.Collections.Generic;
using System.Linq;
using ReservationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    internal class RestaurantTableService
    {
        private readonly RestaurantDbContext _context;

        public RestaurantTableService(RestaurantDbContext context)
        {
            _context = context;
        }

        public void AddTable(RestaurantTable table)
        {
            table.CreatedAt = DateTime.Now;
            _context.RestaurantTables.Add(table);
            _context.SaveChanges();
        }

        public List<RestaurantTable> GetAllTables()
        {
            return _context.RestaurantTables
                .Where(t => t.DeletedAt == null)
                .ToList();
        }

        public RestaurantTable? GetTableById(int id)
        {
            return _context.RestaurantTables
                .FirstOrDefault(t => t.Id == id && t.DeletedAt == null);
        }

        public bool UpdateTable(RestaurantTable updatedTable)
        {
            var table = _context.RestaurantTables.Find(updatedTable.Id);
            if (table == null || table.DeletedAt != null) return false;

            table.Number = updatedTable.Number;
            table.Type = updatedTable.Type;
            table.Description = updatedTable.Description;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteTable(int id)
        {
            var table = _context.RestaurantTables.Find(id);
            if (table == null || table.DeletedAt != null) return false;

            table.DeletedAt = DateTime.Now;
            _context.SaveChanges();
            return true;
        }
    }
}
