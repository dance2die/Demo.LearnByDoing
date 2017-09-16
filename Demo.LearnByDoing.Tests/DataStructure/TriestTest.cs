using System;
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

	public class TrieNode
	{
		public bool IsCompleteWord { get; set; } = false;

		public Dictionary<char, TrieNode> Children { get; } = new Dictionary<char, TrieNode>();
	}
}
