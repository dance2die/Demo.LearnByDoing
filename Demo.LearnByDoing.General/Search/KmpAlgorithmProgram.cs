using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.LearnByDoing.General.Search
{
	public class KmpAlgorithmProgram
	{
		public static void Main(string[] args)
		{
			string word = "abxabcabcaby";
			string searchWord = "abcaby";
			searchWord = "aabaabaaa";
			searchWord = "abcdabd";

			bool isFound = SearchUsingKmp(word, searchWord);
			Console.WriteLine($"{searchWord} is found within {word}? {isFound}");
		}

		private static bool SearchUsingKmp(string word, string searchWord)
		{
			int[] prefixTable = BuildPrefixTable(searchWord);
			return false;
		}

		/// <summary>
		/// https://en.wikipedia.org/wiki/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm
		/// </summary>
		private static int[] BuildPrefixTable(string word)
		{
			int[] T = Enumerable.Repeat(0, word.Length).ToArray();
			// the current position we are computing in T.
			int pos = 1;
			// the zero-based index in search word of the next character of the current candidate substring.
			int cnd = 0;

			T[0] = -1;

			while (pos < word.Length)
			{
				if (word[pos] == word[cnd])
				{
					T[pos] = T[cnd];
					pos++;
					cnd++;
				}
				else
				{
					T[pos] = cnd;
					// to increase performance.
					cnd = T[cnd];

					while (cnd >= 0 && word[pos] != word[cnd])
					{
						cnd = T[cnd];
					}

					pos++;
					cnd++;
				}
			}

			//T[pos] = cnd;

			return T;
		}
	}
}
