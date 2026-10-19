using Garage_ovning5.Vehicles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Garage_ovning5.UI
{
	internal static class VehicleCreator
	{

		public static Vehicle? CreateVehicle(VehicleType type)
		{

			string licensePlateNumber = InputHelper.ReadString("What is your licence plate number?");

			string color = InputHelper.ReadString("What is the color of your vehicle?");

			switch(type)
			{
				case VehicleType.Car:
					return CreateCar(licensePlateNumber, color);
				default:
					break;
			}

			return null;

		}

		private static Vehicle? CreateCar(string licensePlateNumber, string color)
		{

			int numberOfWheels = InputHelper.ReadInt("How many wheels do your vehicle have?");
			FuelType? fuelType = ReadFuelType();

			if (fuelType != null)
			{
				return new Car(licensePlateNumber, color, numberOfWheels, fuelType.Value);
			}

			return null;
		}

		private static FuelType? ReadFuelType()
		{

			while (true)
			{
				Console.WriteLine("What type of fuel does your car use?");
				Console.WriteLine("1. Gasoline");
				Console.WriteLine("2. Diesel");
				Console.WriteLine("3. Electric");
				Console.WriteLine("4. Hybrid");
				Console.WriteLine("0. Cancel");

				switch (Console.ReadLine())
				{
					case "1": return FuelType.Gasoline;
					case "2": return FuelType.Diesel;
					case "3": return FuelType.Electric;
					case "4": return FuelType.Hybrid;
					case "0": return null;
					default:
						Console.WriteLine("Invalid input, please try again");
						break;
				}
			}

		}

	}
}
