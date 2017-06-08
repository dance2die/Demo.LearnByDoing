using System;
using Demo.LearnByDoing.Core;

namespace Demo.LearnByDoing.General.Algorithms.PalindromePartition
{
	/// <summary>
	/// Implementation of Palindrome Partitioning using Dynamic Programming
	/// after watching a video by Tushar Roy on https://youtu.be/lDYIvtBVmgo
	/// </summary>
	public class PalindromePartitionProgram
	{
		public static void Main(string[] args)
		{
			const string word = "abcbm";
			int minimumSplitCount = GetMinimumPalindromeSplitCount(word);
			Console.WriteLine(minimumSplitCount);
		}

		private static readonly PalinedromeChecker palinedromeChecker = new PalinedromeChecker();

		private static int GetMinimumPalindromeSplitCount(string word)
		{
			// initial matrix is initialized with all 0's.
			int[,] matrix = new int[word.Length, word.Length];

			for (int i = 0; i < word.Length; i++)
			{
				for (int j = i + 1; j < word.Length; j++)
				{
					if (palinedromeChecker.IsPalindrome(word.Substring(i, j - i)))
					{
						matrix[i, j] = 0;
					}
					else
					{
						matrix[i, j] = GetMinimumBetween(matrix, i, j - 1);
					}
				}
			}

			return matrix[0, word.Length - 1];
		}

		private static int GetMinimumBetween(int[,] matrix, int i, int j)
		{
			var value = 1 + matrix[i, i] + matrix[i + 1, j];
			int min = value;

			for (int k = i + 1; k <= j - 1; k++)
			{
				value = 1 + matrix[i, k] + matrix[k + i, j];
				if (min > value)
					min = value;
			}

			return min;
		}
	}
}
