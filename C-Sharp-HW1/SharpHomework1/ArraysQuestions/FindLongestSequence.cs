using System;
namespace ArraysQuestions
{
	public class FindLongestSequence
	{
		public static int[] Run(int[] seq) {
			int max_number = seq[0];
			int max_length = 1;
			int cur = seq[0];
			int cur_length = 1;
			for (int i = 1; i < seq.Length; i++) {
				if (seq[i] != cur) {
					cur = seq[i];
					cur_length = 1;
					continue;
				}
				cur_length++;
				if (cur_length > max_length) {
					max_number = seq[i];
					max_length = cur_length;
				}
			}
			int[] res = new int[max_length];
			for (int i = 0; i < max_length; i++) res[i] = max_number;
			return res;
		}
	}
}

