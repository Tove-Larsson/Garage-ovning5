using System;

namespace Garage_ovning5.Vehicles
{
	internal abstract class Vehicle
	{

		private string _licensePlateNumber = string.Empty;
		private string _color = string.Empty;
		private int _numberOfWheels;


		public string LicensePlateNumber
		{
			get { return _licensePlateNumber; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("License plate number can not be empty");
				}

				string trimmed = value.Trim();

				if (trimmed.Length < 6)
				{
					throw new ArgumentException("License plate number must be at least 6 characters");
				}

				_licensePlateNumber = trimmed.ToUpper();
			}
		}

		public string Color
		{
			get { return _color; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Color can not be empty");
				}

				_color = value.Trim().ToUpper();
			}
		}

		public int NumberOfWheels
		{
			get { return _numberOfWheels; }
			set
			{
				if (value < 0)
				{
					throw new ArgumentException("Number of wheels can not be negative");
				}
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
			return $"Vehicle type: {GetType().Name}\n" +
				   $"License plate: {LicensePlateNumber}\n" +
				   $"Color: {Color}\n" +
				   $"Number of wheels: {NumberOfWheels}\n";
		}
	}
}
