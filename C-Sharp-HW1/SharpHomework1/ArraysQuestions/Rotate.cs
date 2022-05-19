using System;
namespace ArraysQuestions
{
	public class Rotate
	{
		public static int[] Run(int[] arr, int k)
		{
			int n = arr.Length;
			int[] result = new int[n];
			for (int i = 1; i <= k; i++) {
				Console.WriteLine(String.Join(',', result));
				for (int j = 0; j < n; j++) {
					result[j] += arr[convertIndex(j-i, n)];
				}
			}
			return result;
		}

		public static int convertIndex(int i, int n) {
			if (i < 0) { return n + (i % n); }
			return i % n;
		}
	}
}

