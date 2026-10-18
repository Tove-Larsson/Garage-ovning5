using Garage_ovning5.Garages;
using System;

namespace Garage_ovning5.UI
{
	internal class Menu
	{
		private Garage? _garage;

		public void MainMenu()
		{
			bool running = true;

			while (running)
			{
				Console.WriteLine("========= Main Menu =========");
				Console.WriteLine("Please select what you want to do!");

				Console.WriteLine("1. Create a garage");
				Console.WriteLine("0. Exit program");

				string? selectedChoice = Console.ReadLine();

				switch (selectedChoice)
				{
					case "1":
						CreateGarage();
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

		public void CreateGarage()
		{

			bool garageCreated = false;

			while (!garageCreated)
			{

				Console.WriteLine("How many parking spaces should the garage have?");

				if (int.TryParse(Console.ReadLine(), out int parkingSpaces) && parkingSpaces > 0)
				{
					Console.WriteLine($"A garage has been created with {parkingSpaces} parking spaces!");
					_garage = new Garage(parkingSpaces);
					garageCreated = true;
					
				}
				else
				{
					Console.WriteLine("Invalid input, please try again");
				}
			}
			// TODO: go to the garage sub-menu from here 
		}
	}
}
