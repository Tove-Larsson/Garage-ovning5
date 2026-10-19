
namespace Garage_ovning5.Vehicles
{
	internal class Car : Vehicle
	{
		private FuelType _fuelType;

		public FuelType FuelType
		{
			get { return _fuelType; }
			set
			{
				_fuelType = value;
			}
		}
		public override VehicleType VehicleType
		{
			get { return VehicleType.Car; }
		}

		public Car(string licensePlateNumber, string color, int numberOfWheels, FuelType fuelType)
			: base(licensePlateNumber, color, numberOfWheels)
		{
			FuelType = fuelType;
		}

		public override string ToString()
		{
			return $"{base.ToString()}" +
				$"Fuel type: {FuelType}\n";
		}
	}
}
