using System;
using System.Collections.Generic;

namespace ReservationSystem.Models;

public partial class SpecialOccasion
{
    public int Id { get; set; }

    public int? TableId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string? Description { get; set; }

    public virtual RestaurantTable? Table { get; set; }
}
