using System;
namespace ArraysQuestions
{
	public class FindFrequentNumber
	{
		public static int Run(int[] arr)
		{
			int max_number = arr[0];
			int max_length = 1;
			Dictionary<int, int> freq = new Dictionary<int, int>();
			foreach (int number in arr) {
				if (freq.ContainsKey(number)) freq[number]++;
				else freq[number] = 1;
				if (freq[number] > max_length) {
					max_number = number;
					max_length = freq[number];
				}
			}
			return max_number;
		}
	}
}

