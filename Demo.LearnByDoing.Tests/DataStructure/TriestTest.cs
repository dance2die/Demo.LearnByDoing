﻿using System;
using System.Collections.Generic;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.DataStructure
{
	public class TriestTest : BaseTest
	{
		private readonly TrieBuilder _sut = new TrieBuilder();

		public TriestTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestCreation()
		{
			//var words = new[] {"abc", "abgl", "cdf", "abcd", "lmn"};
			var words = new[] {"abc", "abgl"};

			TrieNode root = _sut.BuildTrie(words);
			Console.WriteLine(root);
		}

		[Theory]
		[MemberData(nameof(GetTestData))]
		public void TestCompleteWordSearch(bool expected, string word, string[] source)
		{
			bool actual = _sut.BuildTrie(source).CompleteWordSearch(word);

			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> GetTestData()
		{
			yield return new object[] { true, "abc", new[] { "abc", "abgl", "cdf", "abcd", "lmn" } };
			yield return new object[] { true, "abgl", new[] { "abc", "abgl", "cdf", "abcd", "lmn" } };
			yield return new object[] { true, "cdf", new[] { "abc", "abgl", "cdf", "abcd", "lmn" } };
			yield return new object[] { true, "abcd", new[] { "abc", "abgl", "cdf", "abcd", "lmn" } };
			yield return new object[] { true, "lmn", new[] { "abc", "abgl", "cdf", "abcd", "lmn" } };
			yield return new object[] { false, "ab", new[] { "abc", "abgl", "cdf", "abcd", "lmn" } };
			yield return new object[] { false, "abg", new[] { "abc", "abgl", "cdf", "abcd", "lmn" } };
			yield return new object[] { false, "cd", new[] { "abc", "abgl", "cdf", "abcd", "lmn" } };
			yield return new object[] { false, "abcx", new[] { "abc", "abgl", "cdf", "abcd", "lmn" } };
			yield return new object[] { false, "abglx", new[] { "abc", "abgl", "cdf", "abcd", "lmn" } };
			yield return new object[] { false, "cdfx", new[] { "abc", "abgl", "cdf", "abcd", "lmn" } };
			yield return new object[] { false, "abcdx", new[] { "abc", "abgl", "cdf", "abcd", "lmn" } };
			yield return new object[] { false, "lmnx", new[] { "abc", "abgl", "cdf", "abcd", "lmn" } };
		}

	}

	public class TrieNode
	{
		public bool IsCompleteWord { get; set; } = false;

		public Dictionary<char, TrieNode> Children { get; } = new Dictionary<char, TrieNode>();

		/// <summary>
		/// Search for a complete word, not a prefix search.
		/// </summary>
		public bool CompleteWordSearch(string word)
		{
			var current = this;
			foreach (char c in word)
			{
				if (current.Children.TryGetValue(c, out TrieNode node))
				{
					current = node;
				}
				else
				{
					return false;
				}
			}

			return current.IsCompleteWord;
		}
	}

	/// <summary>
	/// Based on https://www.youtube.com/watch?v=AXjmTQ8LEoI by Tushar Roy
	/// </summary>
	public class TrieBuilder
	{
		public TrieNode BuildTrie(IEnumerable<string> words)
		{
			TrieNode root = new TrieNode();
			foreach (var word in words)
			{
				Insert(root, word);
			}

			return root;
		}

		private void Insert(TrieNode current, string word)
		{
			foreach (char c in word)
			{
				current.Children.TryGetValue(c, out TrieNode node);
				if (node == null)
				{
					node = new TrieNode();
					current.Children.Add(c, node);
				}
				current = node;
			}

			current.IsCompleteWord = true;
		}
	}
}
