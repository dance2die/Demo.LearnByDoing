using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.LearnByDoing.General.Algorithms.MaximumSubArraySum
{
	/// <summary>
	/// Implementing Maximum Subarray sum using Kadane's algorithm in https://youtu.be/ohHWQf1HDfU
	/// </summary>
	public class MaximumSubArraySumProgram
	{
		public static void Main(string[] args)
		{
			// https://youtu.be/ohHWQf1HDfU
			int[] a = {1, -3, 2, -5, 7, 6, -1, -4, 11, -23};
			MaximumSubArray maximumSubArray = GetMaximumSubArray(a);
			Console.WriteLine(maximumSubArray);
		}

		private static MaximumSubArray GetMaximumSubArray(int[] a)
		{
			int @from = 0;
			int to = 0;
			int sum = 0;
			int maxSum = 0;

			for (int i = 0; i < a.Length; i++)
			{
				if (sum + a[i] > 0)
				{
					if (sum == 0)
					{
						@from = i;
					}

					sum += a[i];
					
					if (maxSum < sum)
					{
						maxSum = sum;
						to = i;
					}
				}
				else
				{
					sum = 0;
				}
			}

			return new MaximumSubArray(@from, to, maxSum);
		}
	}

	public class MaximumSubArray
	{
		public int From { get; set; }
		public int To { get; set; }
		public int Sum { get; set; }

		public MaximumSubArray(int @from, int to, int sum)
		{
			From = @from;
			To = to;
			Sum = sum;
		}
	}
}
