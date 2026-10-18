using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_ovning5.Vehicles
{
	internal class Bus : Vehicle
	{

		private int numberOfSeats;

		public int NumberOfSeats
		{ 
			get { return numberOfSeats; } 
			set { numberOfSeats = value; }
		}

		public Bus(string licensePlateNumber, string color, int numberOfWheels, int numberOfSeats) : base(licensePlateNumber, color, numberOfWheels)
		{
			NumberOfSeats = numberOfSeats;
		}
	}
}
