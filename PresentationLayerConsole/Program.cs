using BusinessLogic.Services;
using ReservationSystem.Models;
using System;
using BusinessLogic.Services.Email;
using PresentationLayerConsole;

class Programm
{
    public static async Task Main(String[] args)
    {
        Display display = new Display();
        display.Start();
    }
}