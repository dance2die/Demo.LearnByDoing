using System;
using System.Linq;

namespace Demo.LearnByDoing.General.Search
{
	public class KmpAlgorithmProgram
	{
		public static void Main(string[] args)
		{
			string word = "abxabcabcabyabcaby";
			string searchWord = "abcaby";
			//searchWord = "abcdabca";
			//searchWord = "acacabacacabacacac";
			//searchWord = "abxc";
			//searchWord = "abcdabd";

			KmpSearch kmpSearch = new KmpSearch();
			//KmpSearch2 kmpSearch2 = new KmpSearch2();

			word = "abcabcabc";
			searchWord = "abcabc";

			bool isFound = kmpSearch.SearchUsingKmp(word, searchWord);
			//bool isFound = SearchUsingKmp(word, searchWord);
			Console.WriteLine($"{searchWord} is found within {word}? {isFound}");
		}

		private static bool SearchUsingKmp(string word, string searchWord)
		{
			int[] prefixTable = BuildPrefixTable(searchWord);
			int[] foundIndices = SearchByKmp(word, searchWord, prefixTable);

			if (foundIndices.Any(a => a == -1) || foundIndices.Length == 0)
				return false;
			return true;
		}

		private static int[] SearchByKmp(string word, string searchWord, int[] prefixTable)
		{
			return null;
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
					//while (j - 1 >= 0 && searchWord[T[j - 1]] != searchWord[i])
					//{
					//	j = T[--j];

					//	//if (j - 1 >= 0 && searchWord[i] == searchWord[T[j - 1]])
					//	//{
					//	//	T[i] = j - 1;
					//	//	j++;
					//	//	break;
					//	//}
					//}

					while (j >= 1 && searchWord[j] != searchWord[i])
					{
						j = T[j - 1];
						if (j == 0) break;
					}

					if (searchWord[j] == searchWord[i])
						T[i] = j + 1;

					i++;
				}
			}

			return T;
		}
	}
}
