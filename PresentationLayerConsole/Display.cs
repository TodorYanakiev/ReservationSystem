using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayerConsole
{
    internal class Display
    {
        public void Start()
        {
            Console.WriteLine("Запазете специалния си момент с нас\nВашата маса ви очаква!");
            ShowMainMenu();
        }
        public void ShowMainMenu()
        {
            Console.WriteLine("1. Резервирай своята маса сега!\n2. Влез като Администратор");
            Console.Write("Въведете (1 или 2): ");
            byte choice = byte.Parse(Console.ReadLine());
            if(choice == 1)
            {

            }
            else if(choice == 2)
            {

            }
            else
            {
                Console.WriteLine("Невалидни данни!");
                ShowMainMenu();
            }
        }
    }
}
