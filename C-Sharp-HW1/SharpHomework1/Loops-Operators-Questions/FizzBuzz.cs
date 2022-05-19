using System;
namespace Loops_Operators_Questions
{
	public static class FizzBuzz
	{
		public static void Run(int number)
		{
			if (number % 3 == 0 && number % 5 == 0) { Console.WriteLine("FizzBuzz"); }
			else if (number % 3 == 0) Console.WriteLine("Fizz");
			else if (number % 5 == 0) Console.WriteLine("Buzz");
		}
	}
}

