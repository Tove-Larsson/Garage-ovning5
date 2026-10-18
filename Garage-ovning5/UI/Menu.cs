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
			GarageMenu();
		}

		public void GarageMenu()
		{
			bool running = true;

			while (running)
			{

				Console.WriteLine("========= Garage menu =========");
				Console.WriteLine("Please select what you want to do!");

				Console.WriteLine("1. Park a vehicle");
				Console.WriteLine("2. Retrieve a vehicle");
				Console.WriteLine("3. List all parked vehicles");
				Console.WriteLine("4. List vehicle types and number of vehicles");
				Console.WriteLine("5. Search vehicles");
				Console.WriteLine("0. Back to main menu");

				string? selectedChoice = Console.ReadLine();

				switch (selectedChoice)
				{
					case "1":
						Console.WriteLine("TODO: Park vehicle functionality here");
						break;
					case "2":
						Console.WriteLine("TODO: Retrieval of vehicle functionality here");
						break;
					case "3":
						Console.WriteLine("TODO: List all parked vehicles functionality here");
						break;
					case "4":
						Console.WriteLine("TODO: List vehicle types and count of them here ");
						break;
					case "5":
						Console.WriteLine("TODO: Searching on a vehicle here");
						break;
					case "0":
						Console.WriteLine("Back to main menu!");
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
