using System;
using System.Collections.Generic;

namespace ReservationSystem.Models;

public partial class Reservation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public int? TableId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? OperatingHoursId { get; set; }

    public DateOnly ReservationDate { get; set; }

    public DateTime? CanceledAt { get; set; }

    public string? Notes { get; set; }

    public string? VerificationCode { get; set; }

    public bool? VerifiedByUser { get; set; }

    public virtual OperatingHour? OperatingHours { get; set; }

    public virtual RestaurantTable? Table { get; set; }
}
