using PresentationLayerConsole.ReservationSystem.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayerConsole
{
    internal class Display
    {
        private readonly ReservationMenu _reservationMenu;
        private readonly AdminMenu _adminMenu;

        public Display()
        {
            _reservationMenu = new ReservationMenu();
            _adminMenu = new AdminMenu();
        }
        public void Start()
        {
            Console.WriteLine("Запазете специалния си момент с нас\nВашата маса ви очаква!");
            ShowMainMenu();
        }
        public void ShowMainMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Резервирай своята маса сега!\n2. Влез като Администратор");
                Console.Write("Въведете (1 или 2): ");
                string input = Console.ReadLine();

                if (byte.TryParse(input, out byte choice))
                {
                    if (choice == 1)
                    {
                        _reservationMenu.MakeReservationMenu();
                        break;
                    }
                    else if (choice == 2)
                    {
                        _adminMenu.ShowMenu();
                        break;
                    }
                }

                Console.WriteLine("Невалидни данни! Опитай отново.\n");
            }
        }

    }
}
