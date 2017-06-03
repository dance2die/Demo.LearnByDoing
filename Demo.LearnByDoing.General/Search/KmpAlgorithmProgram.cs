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
			//searchWord = "abxc";
			//searchWord = "abcdabd";

			KmpSearch kmpSearch = new KmpSearch();

			bool isFound = kmpSearch.SearchUsingKmp(word, searchWord);
			Console.WriteLine($"{searchWord} is found within {word}? {isFound}");
		}
	}
}
