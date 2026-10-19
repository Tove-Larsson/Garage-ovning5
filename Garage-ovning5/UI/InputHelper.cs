using System;

namespace Garage_ovning5.UI
{
	internal static class InputHelper
	{

		public static int ReadInt(string prompt)
		{
			while (true)
			{
				Console.WriteLine(prompt);

				if (int.TryParse(Console.ReadLine(), out int result))
				{
					return result;
				}

				Console.WriteLine("Invalid input, please enter a whole number");
			}
		}

		public static double ReadDouble(string prompt)
		{
			while(true)
			{
				Console.WriteLine(prompt);

				if (double.TryParse(Console.ReadLine(), out double result))
				{
					return result;
				}
				Console.WriteLine("Invalid input, please enter a valid number");
			}
		}

		public static string ReadString(string prompt)
		{
			while (true)
			{
				Console.WriteLine(prompt);
				string? input = Console.ReadLine();

				if (!string.IsNullOrWhiteSpace(input))
				{
					return input;
				}

				Console.WriteLine("Invalid input, please try again");
			}
		}
	}
}
