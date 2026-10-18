using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_ovning5.Vehicles
{
	internal class Airplane : Vehicle
	{

		private int _numberOfEngines;

		public int NumberOfEngines
		{ 
			get { return _numberOfEngines; } 
			set { _numberOfEngines = value; }

		}

		public Airplane(string licensePlateNumber, string color, int numberOfWheels, int numberOfEngines) : base(licensePlateNumber, color, numberOfWheels)
		{
			NumberOfEngines = numberOfEngines;
		}
	}
}
