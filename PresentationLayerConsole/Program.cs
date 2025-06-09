using BusinessLogic.Services;
using ReservationSystem.Models;
using System;
using BusinessLogic.Services.Email;
using PresentationLayerConsole;

namespace PresentationLayerConsole
{
    class Program
    {
        public static async Task Main(String[] args)
        {
            Display display = new();
            display.Start();
        }
    }
}