using System;

namespace Garage_ovning5.Vehicles
{
	internal class Motorcycle : Vehicle
	{

		private int _cylinderVolume;

		public int CylinderVolume
		{
			get { return _cylinderVolume; }
			set
			{
				if (value <= 0)
				{
					throw new ArgumentException("Cylinder volume must be greater than 0");
				}
				_cylinderVolume = value;
			}
		}
		public Motorcycle(string licensePlateNumber, string color, int numberOfWheels, int cylinderVolume) : base(licensePlateNumber, color, numberOfWheels)
		{
			CylinderVolume = cylinderVolume;
		}
	}
}
