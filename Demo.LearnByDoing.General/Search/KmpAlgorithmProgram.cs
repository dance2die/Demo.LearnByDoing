using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.General.Search
{
	public class KmpAlgorithmProgram
	{
		public static void Main(string[] args)
		{
			string word = "abxabcabcabyabcaby";
			string searchWord = "abcaby";
			searchWord = "abcdabca";
			//searchWord = "acacabacacabacacac";
			//searchWord = "abxc";
			//searchWord = "abcdabd";

			KmpSearch kmpSearch = new KmpSearch();
			//KmpSearch2 kmpSearch2 = new KmpSearch2();

			//bool isFound = kmpSearch2.SearchUsingKmp(word, searchWord);
			bool isFound = SearchUsingKmp(word, searchWord);
			Console.WriteLine($"{searchWord} is found within {word}? {isFound}");
		}

		private static bool SearchUsingKmp(string word, string searchWord)
		{
			int[] prefixTable = BuildPrefixTable(searchWord);
			return false;
		}

		/// <summary>
		/// Build Prefix table using Algorithm in YouTube video
		/// https://youtu.be/GTJr8OvyEVQ
		/// </summary>
		/// <param name="searchWord"></param>
		/// <returns></returns>
		private static int[] BuildPrefixTable(string searchWord)
		{
			int j = 0;
			int i = j + 1;
			int[] T = Enumerable.Repeat(0, searchWord.Length).ToArray();
			T[0] = 0;

			while (i < searchWord.Length)
			{
				if (searchWord[i] == searchWord[j])
				{
					T[i] = j + 1;
					j++;
					i++;
				}
				else
				{
					//T[i] = 0;
					//i++;

					// Move to the index pointed by the previous item.
					//j = T[j - 1];
					//while (j - 1 >= 0 && searchWord[T[j - 1]] != T[i])
					while (j - 1 >= 0 && searchWord[T[j - 1]] != searchWord[i])
					{
						j--;
						j = T[j];

						if (j - 1 >= 0 && searchWord[i] == searchWord[T[j - 1]])
						{
							T[i] = j - 1;
							j++;
						}
					}

					i++;
				}
			}

			return T;
		}
	}
}
