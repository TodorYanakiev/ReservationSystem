using System;
using System.Collections.Generic;

namespace ReservationSystem.Models;

public partial class RestaurantTable
{
    public int Id { get; set; }

    public int Number { get; set; }

    public string Type { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<OperatingHour> OperatingHours { get; set; } = new List<OperatingHour>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<SpecialOccasion> SpecialOccasions { get; set; } = new List<SpecialOccasion>();

    public override string ToString()
    {
        return $"№{Number}; type: {Type}; description: {Description}";
    }
}
