using Garage_ovning5.Vehicles;

namespace Garage_ovning5.Garages
{
	internal class Garage
	{
		private Vehicle[] _vehicles;

		public Garage(int capacity)
		{
			_vehicles = new Vehicle[capacity];
		}
	}
}
