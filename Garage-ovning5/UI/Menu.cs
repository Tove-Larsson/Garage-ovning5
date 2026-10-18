using Garage_ovning5.Garages;
using System;

namespace Garage_ovning5.UI
{
	internal class Menu
	{
		public void MainMenu()
		{
			bool running = true;

			while (running)
			{
				Console.WriteLine("========= Main Menu =========");
				Console.WriteLine("Please select what you want to do!");

				Console.WriteLine("1. Create a garage");
				Console.WriteLine("0. Avsluta");

				string? selectedChoice = Console.ReadLine();

				switch (selectedChoice)
				{
					case "1":
						Console.WriteLine("TODO: Create garage functionality");
						break;
					case "0":
						Console.WriteLine("You chose to end the application, goodbye!");
						running = false;
						break;
					default:
						Console.WriteLine("Invalid input, please try again");
						break;
				}
			}
		}

	}
}
