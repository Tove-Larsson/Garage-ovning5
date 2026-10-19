using System;

namespace Garage_ovning5.Vehicles
{
	internal class Airplane : Vehicle
	{

		private int _numberOfEngines;

		public int NumberOfEngines
		{ 
			get { return _numberOfEngines; } 
			set 
			{ 
				if (value < 1)
				{
					throw new ArgumentException("Your airplane can not have less than 1 engine");
				}
				_numberOfEngines = value; 
			}

		}

		public override VehicleType VehicleType
		{
			get { return VehicleType.Airplane; }
		}

		public Airplane(string licensePlateNumber, string color, int numberOfWheels, int numberOfEngines) : base(licensePlateNumber, color, numberOfWheels)
		{
			NumberOfEngines = numberOfEngines;
		}

		public override string ToString()
		{
			return $"{base.ToString()}" +
				$"Number of engines: {NumberOfEngines}\n";
		}
	}
}
