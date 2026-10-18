using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_ovning5.Vehicles
{
	internal class Boat : Vehicle
	{
		private double _length;

		public double Length
		{
			get {  return _length; }
			set { _length = value; }
		}
		public Boat(string licensePlateNumber, string color, int numberOfWheels, double length) : base(licensePlateNumber, color, numberOfWheels)
		{
			Length = length;
		}
	}
}
