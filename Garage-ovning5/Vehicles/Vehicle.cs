using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_ovning5.Vehicles
{
	internal class Vehicle
	{

		private string _licensePlateNumber;
		private string _color;
		private int _numberOfWheels;


		public string LicensePlateNumber
		{
			get { return _licensePlateNumber; }
			set
			{
				_licensePlateNumber = value;
			}
		}

		public string Color
		{
			get { return _color; }
			set
			{
				_color = value;
			}
		}

		public int NumberOfWheels
		{
			get { return _numberOfWheels; }
			set
			{
				_numberOfWheels = value;
			}
		}


		public Vehicle(string licensePlateNumber, string color, int numberOfWheels)
		{
			LicensePlateNumber = licensePlateNumber;
			Color = color;
			NumberOfWheels = numberOfWheels;

		}



		public override string ToString()
		{
			return $"The vehicle license plate number: {_licensePlateNumber}, color: {_color} amount of wheels: {_numberOfWheels}";
		}
	}
}
