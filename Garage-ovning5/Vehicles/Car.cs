using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_ovning5.Vehicles
{
	internal class Car : Vehicle
	{

		private string _fuelType;

		public string FuelType
		{
			get { return _fuelType; }
			set { _fuelType = value; }
		}

		public Car(string licensePlateNumber, string color, int numberOfWheels, string fuelType) : base(licensePlateNumber, color, numberOfWheels)
		{
			FuelType = fuelType;
		}
	}
}
