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
				Console.WriteLine("\n========= Main Menu =========\n");
				Console.WriteLine("Please select what you want to do!");

				Console.WriteLine("1. Create a garage");
				Console.WriteLine("2. Create a garage with pre-parked vehicles");
				Console.WriteLine("0. Exit program");

				string? selectedChoice = Console.ReadLine();

				switch (selectedChoice)
				{
					case "1":
						CreateGarage();
						break;
					case "2":
						CreatePreParkedGarage();
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

		public void CreatePreParkedGarage()
		{
			Console.WriteLine("Create a pre-parked garage chosen");
			Console.WriteLine("\nOne vehicle per vehicle type has been created, plus 5 extra parking spaces!\n");

			Garage preParkedGarage = new Garage(10);

			preParkedGarage.ParkVehicle(new Car("Abc123", "Red", 4, FuelType.Gasoline));
			preParkedGarage.ParkVehicle(new Motorcycle("def345", "Blue", 2, 1000));
			preParkedGarage.ParkVehicle(new Bus("Did865", "Yellow", 4, 30));
			preParkedGarage.ParkVehicle(new Airplane("bob261", "Green", 3, 2));
			preParkedGarage.ParkVehicle(new Boat("hej729", "Silver", 200.5));

			_garage = preParkedGarage;
			GarageMenu();

		}

		public void GarageMenu()
		{
			bool running = true;

			while (running)
			{

				Console.WriteLine("\n========= Garage menu =========\n");
				Console.WriteLine("Please select what you want to do!");

				Console.WriteLine("1. Park a vehicle");
				Console.WriteLine("2. Retrieve a vehicle");
				Console.WriteLine("3. List all parked vehicles");
				Console.WriteLine("4. List parked vehicle types");
				Console.WriteLine("5. Search vehicles");
				Console.WriteLine("0. Back to main menu");

				string? selectedChoice = Console.ReadLine();

				switch (selectedChoice)
				{
					case "1":
						ParkVehicle();
						break;
					case "2":
						RetrieveVehicle();
						break;
					case "3":
						ListParkedVehicles();
						break;
					case "4":
						ListVehicleType();
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

			string licensePlateNumber = InputHelper.ReadString("What is your vehicles license plate number?");

			if (_garage.IsLicensePlateTaken(licensePlateNumber))
			{
				Console.WriteLine($"A vehicle with licence plate number: {licensePlateNumber} already exists");
				return;
			}

			try
			{

				Vehicle? vehicle = VehicleCreator.CreateVehicle(type.Value, licensePlateNumber);
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

		public void RetrieveVehicle()
		{
			if (_garage == null)
			{
				Console.WriteLine("No garage exists");
				return;
			}

			string licensePlateNumber = InputHelper.ReadString("Please enter the license plate number of the vehicle you want to retrieve");

			Vehicle? retrievedVehicle = _garage.RemoveVehicle(licensePlateNumber);

			if (retrievedVehicle != null)
			{
				Console.WriteLine($"Retrieval of vehicle with license plate number: {retrievedVehicle.LicensePlateNumber} was successful!");
			}
			else
			{
				Console.WriteLine($"No vehicle with license plate {licensePlateNumber} was found.");
			}
		}

		public void ListParkedVehicles()
		{
			if (_garage == null)
			{
				Console.WriteLine("No garage exists");
				return;
			}

			Console.WriteLine("\n========= Parked vehicles =========\n");

			_garage.ListAllVehicles();
		}

		public void ListVehicleType()
		{
			if ( _garage == null)
			{
				Console.WriteLine("No garage exists");
				return;
			}

			Console.WriteLine("\n========= Parked vehicle types =========\n");

			Console.WriteLine($"Cars: {_garage.CountOfVehicleType(VehicleType.Car)}");
			Console.WriteLine($"Motorcycles: {_garage.CountOfVehicleType(VehicleType.Motorcycle)}");
			Console.WriteLine($"Buses: {_garage.CountOfVehicleType(VehicleType.Bus)}");
			Console.WriteLine($"Airplanes: {_garage.CountOfVehicleType(VehicleType.Airplane)}");
			Console.WriteLine($"Boats: {_garage.CountOfVehicleType(VehicleType.Boat)}\n");

		}
	}
}
