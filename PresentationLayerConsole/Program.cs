using BusinessLogic.Services;
using ReservationSystem.Models;
using System;

class Programm
{
    public static void Main(String[] args)
    {
        ReservationService service = new ReservationService(new RestaurantDbContext());
        Reservation reservation = new Reservation();
        reservation.Name = "Toshko";
        reservation.Email = "todormaster25@gmail.com";
        reservation.PhoneNumber = "23462534";
        reservation.TableId = 12;
        reservation.OperatingHoursId = 67;
        reservation.ReservationDate = new DateOnly(2025, 5, 22);

        service.CreateReservation(reservation);
    }
}