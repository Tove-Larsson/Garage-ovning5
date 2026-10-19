using System;

namespace Garage_ovning5.Vehicles
{
	internal class Boat : Vehicle
	{
		private double _length;

		public double Length
		{
			get {  return _length; }
			set 
			{
				if (value <= 0 || !double.IsFinite(value))
				{
					throw new ArgumentException("Length must be a number greater than 0");
				}
				_length = value;
			}
		}

		public override VehicleType VehicleType
		{
			get { return VehicleType.Boat; }
		}

		public Boat(string licensePlateNumber, VehicleColor color, double length) : base(licensePlateNumber, color, 0)
		{
			Length = length;
		}

		public override string ToString()
		{
			return $"{base.ToString()}" +
				$"Length: {Length}\n";
		}
	}
}
