using Garage_ovning5.Garages;
using Garage_ovning5.Vehicles;
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
						ParkVehicle();
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

		public void ParkVehicle()
		{
			if (_garage == null)
			{
				Console.WriteLine("No garage exists");
				return;
			}

			VehicleType? type = ReadVehicleType();
			if (type == null)
			{
				return;
			}


			try
			{

				Vehicle? vehicle = VehicleCreator.CreateVehicle(type.Value);
				if (vehicle == null)
				{
					Console.WriteLine("The vehicle was not created");
					return;
				}

				bool parked = _garage.ParkVehicle(vehicle);

				if (parked)
				{
					Console.WriteLine($"The {type} with {vehicle.LicensePlateNumber} license plate number was parked successfully!");
				}
				else
				{
					Console.WriteLine("The garage was full!");
				}

			}
			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
				return;
			}
		
		}

		private VehicleType? ReadVehicleType()
		{
			while (true)
			{
				Console.WriteLine("What type of vehicle do you want to park?");
				Console.WriteLine("1. Car");
				Console.WriteLine("2. Motorcycle");
				Console.WriteLine("3. Bus");
				Console.WriteLine("4. Airplane");
				Console.WriteLine("5. Boat");
				Console.WriteLine("0. Cancel");

				switch (Console.ReadLine())
				{
					case "1": return VehicleType.Car;
					case "2": return VehicleType.Motorcycle;
					case "3": return VehicleType.Bus;
					case "4": return VehicleType.Airplane;
					case "5": return VehicleType.Boat;
					case "0": return null;
					default:
						Console.WriteLine("Invalid input, please try again");
						break;
				}
			}
		}
	}
}
