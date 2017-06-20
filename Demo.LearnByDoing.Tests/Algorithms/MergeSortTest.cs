using System.Collections.Generic;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Algorithms
{
	/// <summary>
	/// Implementing Merge Sort using algorithm on this YouTube video by mycodeschool
	/// https://www.youtube.com/watch?v=TzeBrDU-JaY&t=852s
	/// </summary>
	public class MergeSortTest : BaseTest
	{
		private readonly MergeSort _sut = new MergeSort();

		public MergeSortTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[ClassData(typeof(MergeSortTestData))]
		public void TestMergeSort(int[] a, int[] expected)
		{
			int[] actual = _sut.Sort(a);

			Assert.Equal(expected, actual);
		}
	}

	public class MergeSort
	{
		public int[] Sort(int[] a)
		{

		}
	}

	public class MergeSortTestData : TestDataBase
	{
		public override List<object[]> Data { get; set; } = new List<object[]>
		{
			new object[] {new[] {2, 4, 1, 6, 8, 5, 3, 7}, new[] {1, 2, 3, 4, 5, 6, 7, 8}}
		};
	}
}
