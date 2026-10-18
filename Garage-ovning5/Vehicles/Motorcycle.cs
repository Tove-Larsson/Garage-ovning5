using System;
using System.Collections.Generic;
using System.Text;

namespace Garage_ovning5.Vehicles
{
	internal class Motorcycle : Vehicle
	{

		private int _cylinderVolume;

		public int CylinderVolume
		{
			get { return _cylinderVolume; }
			set { _cylinderVolume = value; }
		}
		public Motorcycle(string licensePlateNumber, string color, int numberOfWheels, int cylinderVolume) : base(licensePlateNumber, color, numberOfWheels)
		{
			CylinderVolume = cylinderVolume;
		}
	}
}
