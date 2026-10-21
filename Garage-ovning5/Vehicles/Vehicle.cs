using System;

namespace Garage_ovning5.Vehicles
{
	internal abstract class Vehicle
	{
		internal const int MinimumLicensePlateLength = 6;

		private string _licensePlateNumber = string.Empty;
		private VehicleColor _color;
		private int _numberOfWheels;


		public string LicensePlateNumber
		{
			get { return _licensePlateNumber; }
			set
			{
				if (!IsValidLicensePlate(value))
				{
					throw new ArgumentException($"License plate number must be at least {MinimumLicensePlateLength} characters and contain only letters and digits");
				}

				_licensePlateNumber = value.Trim().ToUpper();
			}
		}

		public VehicleColor Color
		{
			get { return _color; }
			set { _color = value; }
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

		public abstract VehicleType VehicleType { get; }


		public Vehicle(string licensePlateNumber, VehicleColor color, int numberOfWheels)
		{
			LicensePlateNumber = licensePlateNumber;
			Color = color;
			NumberOfWheels = numberOfWheels;

		}
		public static bool IsValidLicensePlate(string? licensePlateNumber)
		{
			if (string.IsNullOrWhiteSpace(licensePlateNumber))
			{
				return false;
			}

			string trimmed = licensePlateNumber.Trim();

			if (trimmed.Length < MinimumLicensePlateLength)
			{
				return false;
			}

			foreach (char c in trimmed)
			{
				if (!char.IsLetterOrDigit(c))
				{
					return false;
				}
			}

			return true;
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
