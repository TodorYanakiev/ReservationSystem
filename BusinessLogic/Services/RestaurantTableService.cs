using System;
using System.Collections.Generic;
using System.Linq;
using ReservationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    /// <summary>
    /// Provides business logic for managing restaurant tables, including
    /// CRUD operations and availability checks.
    /// </summary>
    public class RestaurantTableService
    {
        private readonly RestaurantDbContext _context;
        private readonly OperatingHourService _operatingHourService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestaurantTableService"/> class.
        /// </summary>
        /// <param name="context">Database context for the reservation system.</param>
        public RestaurantTableService(RestaurantDbContext context)
        {
            _context = context;
            _operatingHourService = new OperatingHourService(context);
        }

        /// <summary>
        /// Adds a new restaurant table to the system and sets the creation timestamp.
        /// </summary>
        /// <param name="table">The restaurant table to add.</param>
        public void AddTable(RestaurantTable table)
        {
            table.CreatedAt = DateTime.Now;
            _context.RestaurantTables.Add(table);
            _context.SaveChanges();
        }

        /// <summary>
        /// Retrieves all non-deleted restaurant tables.
        /// </summary>
        /// <returns>A list of active restaurant tables.</returns>
        public List<RestaurantTable> GetAllTables()
        {
            return _context.RestaurantTables
                .Where(t => t.DeletedAt == null)
                .ToList();
        }

        /// <summary>
        /// Retrieves a restaurant table by its identifier if it is not deleted.
        /// </summary>
        /// <param name="id">The unique identifier of the table.</param>
        /// <returns>The table if found; otherwise, <c>null</c>.</returns>
        public RestaurantTable? GetTableById(int id)
        {
            return _context.RestaurantTables
                .FirstOrDefault(t => t.Id == id && t.DeletedAt == null);
        }

        /// <summary>
        /// Updates the properties of an existing table if it exists and is not deleted.
        /// </summary>
        /// <param name="updatedTable">The table with updated data.</param>
        /// <returns><c>true</c> if the update was successful; otherwise, <c>false</c>.</returns>
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

        /// <summary>
        /// Soft deletes a table by setting its <see cref="RestaurantTable.DeletedAt"/> timestamp.
        /// </summary>
        /// <param name="id">The identifier of the table to delete.</param>
        /// <returns><c>true</c> if the deletion was successful; otherwise, <c>false</c>.</returns>
        public bool DeleteTable(int id)
        {
            var table = _context.RestaurantTables.Find(id);
            if (table == null || table.DeletedAt != null) return false;

            table.DeletedAt = DateTime.Now;
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Gets the IDs of all tables that are free (not reserved) on a given date.
        /// </summary>
        /// <param name="date">The date to check for available tables.</param>
        /// <param name="reservationService">Service used to fetch existing reservations.</param>
        /// <returns>A list of table IDs that are available on the specified date.</returns>
        public List<int?> GetFreeTableIdsForDate(DateOnly date, ReservationService reservationService)
        {
            List<OperatingHour> allOperatingHours = _operatingHourService.GetAllOperatingHours();
            List<int?> reservedTables = reservationService.GetAllReservationsByDate(date)
                .Select(r => r.TableId)
                .Distinct()
                .ToList();
            List<int?> allTableIds = allOperatingHours
                .Select(oh => oh.TableId)
                .Distinct()
                .ToList();

            return allTableIds.Except(reservedTables).ToList();
        }
    }
}
