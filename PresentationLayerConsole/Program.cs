using BusinessLogic.Services;
using ReservationSystem.Models;
using System;
using BusinessLogic.Services.Email;

class Programm
{
    public static async Task Main(String[] args)
    {
        ReservationService service = new ReservationService(new RestaurantDbContext());
        List<Reservation> reservations = service.GetReservations(includeCancelled:true);
        foreach (Reservation reservation in reservations)
        {
            Console.WriteLine($"{reservation.Id}");
        }
    }
}