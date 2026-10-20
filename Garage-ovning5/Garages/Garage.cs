using Garage_ovning5.Vehicles;
using System;

namespace Garage_ovning5.Garages
{
	internal class Garage
	{
		private Vehicle?[] _vehicles;

		public Garage(int capacity)
		{
			_vehicles = new Vehicle?[capacity];
		}


		public bool ParkVehicle(Vehicle vehicle)
		{
			if (IsLicensePlateTaken(vehicle.LicensePlateNumber))
			{
				return false;
			}

			for (int i = 0; i < _vehicles.Length; i++)
			{
				if (_vehicles[i] == null)
				{
					_vehicles[i] = vehicle;
					return true;
				}
			}

			return false;
		}

		public bool IsLicensePlateTaken(string licensePlateNumber)
		{
			string searchedPlate = licensePlateNumber.Trim().ToUpper();

			foreach (Vehicle? vehicle in _vehicles)
			{
				if (vehicle == null)
				{
					continue;
				}

				if (vehicle.LicensePlateNumber == searchedPlate)
				{
					return true;
				}
			}

			return false;
		}

		public Vehicle? RemoveVehicle(string licensePlateNumber)
		{
			string searchedPlate = licensePlateNumber.Trim().ToUpper();

			for (int i = 0; i < _vehicles.Length; i++)
			{
				Vehicle? vehicle = _vehicles[i];

				if (vehicle == null)
				{
					continue;
				}

				if (vehicle.LicensePlateNumber == searchedPlate)
				{
					_vehicles[i] = null;
					return vehicle;
				}

			}

			return null;
		}

		public void ListAllVehicles()
		{
			bool vehicleFound = false;

			foreach (Vehicle? vehicle in _vehicles)
			{
				if (vehicle == null)
				{
					continue;
				}

				Console.WriteLine($"{vehicle}\n");
				vehicleFound = true;

			}

			if (!vehicleFound)
			{
				Console.WriteLine("There are no vehicles parked in the garage.\n");
			}
		}

		public int CountOfVehicleType(VehicleType type)
		{
			int count = 0;

			foreach (Vehicle? vehicle in _vehicles)
			{
				if (vehicle == null)
					continue;

				if (vehicle.VehicleType == type)
				{
					count++;
				}
			}

			return count;
		}

		public Vehicle? SearchByLicensePlate(string licensePlateNumber)
		{
			string searchedPlate = licensePlateNumber.Trim().ToUpper();

			for (int i = 0; i < _vehicles.Length; i++)
			{
				Vehicle? vehicle = _vehicles[i];

				if (vehicle == null)
				{
					continue;
				}

				if (vehicle.LicensePlateNumber == searchedPlate)
				{
					return vehicle;
				}

			}

			return null;
		}

		private static bool MatchesSearch(Vehicle vehicle, VehicleColor? color, int? wheels, VehicleType? type)
		{
			if (color != null && vehicle.Color != color)
			{
				return false;
			}

			if (wheels != null && vehicle.NumberOfWheels != wheels)
			{
				return false;
			}

			if (type != null && vehicle.VehicleType != type)
			{
				return false;
			}

			return true;

		}

		public Vehicle[]? SearchByProperties(VehicleColor? color, int? numberOfWheels, VehicleType? vehicleType)
		{
			int matchedSearchedCount = 0;

			for (int i = 0; i < _vehicles.Length; i++)
			{
				Vehicle? vehicle = _vehicles[i];

				if (vehicle == null)
				{
					continue;
				}


				if (MatchesSearch(vehicle, color, numberOfWheels, vehicleType))
				{
					matchedSearchedCount++;
				}
			}

			if (matchedSearchedCount == 0)
			{
				return null;
			}

			Vehicle[] resultArray = new Vehicle[matchedSearchedCount];

			int resultIndex = 0;

			for (int j = 0; j < _vehicles.Length; j++)
			{
				Vehicle? vehicle = _vehicles[j];

				if (vehicle == null)
				{
					continue;
				}

				if (MatchesSearch(vehicle, color, numberOfWheels, vehicleType))
				{
					resultArray[resultIndex] = vehicle;

					resultIndex++;
				}
			}
			return resultArray;
		}
	}
}
