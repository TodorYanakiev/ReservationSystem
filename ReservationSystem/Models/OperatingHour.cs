using System;
using System.Collections.Generic;

namespace ReservationSystem.Models;

public partial class OperatingHour
{
    public int Id { get; set; }

    public string DayOfWeek { get; set; } = null!;

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public int? TableId { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual RestaurantTable? Table { get; set; }
}
