using Garage_ovning5.Vehicles;

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
	
	}
}
