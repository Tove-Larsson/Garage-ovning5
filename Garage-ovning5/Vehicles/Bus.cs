using System;

namespace Garage_ovning5.Vehicles
{
	internal class Bus : Vehicle
	{
		private const int MinimumSeats = 9;

		private int _numberOfSeats;
		public int NumberOfSeats
		{
			get { return _numberOfSeats; }
			set
			{
				if (value < MinimumSeats)
				{
					throw new ArgumentException($"A bus must have at least {MinimumSeats} seats");
				}
				_numberOfSeats = value;
			}
		}

		public Bus(string licensePlateNumber, string color, int numberOfWheels, int numberOfSeats) : base(licensePlateNumber, color, numberOfWheels)
		{
			NumberOfSeats = numberOfSeats;
		}

		public override string ToString()
		{
			return $"{base.ToString()}" +
				$"Number of seats: {NumberOfSeats}\n";
		}
	}
}
