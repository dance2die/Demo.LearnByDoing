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
		[ClassData(typeof(MergeSortTestData_Merge))]
		public void TestMergingTwoListSorted(int[] left, int[] right, int[] expected)
		{
			int[] actual = new int[left.Length + right.Length];
			_sut.Merge(left, right, actual);

			Assert.Equal(expected, actual);
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
		public void Merge(int[] left, int[] right, int[] a)
		{
			int i = 0;
			int j = 0;
			int k = 0;

			while (i < left.Length && j < right.Length)
			{
				if (left[i] < right[j])
				{
					a[k] = left[i];
					i++;
				}
				else
				{
					a[k] = right[j];
					j++;
				}

				k++;
			}

			while (i < left.Length)
			{
				a[k] = left[i];
				k++;
				i++;
			}

			while (j < right.Length)
			{
				a[k] = right[j];
				k++;
				j++;
			}
		}

		public int[] Sort(int[] a)
		{
			int n = a.Length;
			if (n < 2) return a;

			int mid = n / 2;
			var left = new int[mid];
			var right = new int[mid];

			// fill left array
			for (int i = 0; i < mid; i++)
			{
				left[i] = a[i];
			}

			// fill right array
			for (int i = mid; i < n; i++)
			{
				right[i - mid] = a[i];
			}

			// sort left & right
			Sort(left);
			Sort(right);

			// merge left & right
			Merge(left, right, a);

			return a;
		}
	}

	public class MergeSortTestData : TestDataBase
	{
		public override List<object[]> Data { get; set; } = new List<object[]>
		{
			new object[] {new[] {2, 4, 1, 6}, new[] {1, 2, 4, 6}},
			new object[] {new[] {8, 5, 3, 7}, new[] {3, 5, 7, 8}},
			new object[] {new[] {2, 4, 1, 6, 8, 5, 3, 7}, new[] {1, 2, 3, 4, 5, 6, 7, 8}}
		};
	}

	public class MergeSortTestData_Merge : TestDataBase
	{
		public override List<object[]> Data { get; set; } = new List<object[]>
		{
			new object[] {new[] {1, 2, 4, 6}, new[] {3, 5, 7, 8}, new[] {1, 2, 3, 4, 5, 6, 7, 8}},
			new object[] {new[] {2, 4}, new[] {1, 6}, new[] {1, 2, 4, 6}},
			new object[] {new[] {5, 8}, new[] {3, 7}, new[] {3, 5, 7, 8}},
			new object[] {new[] {2}, new[] {4}, new[] {2, 4}},
			new object[] {new[] {1}, new[] {6}, new[] {1, 6}},
			new object[] {new[] {8}, new[] {5}, new[] {5, 8}},
			new object[] {new[] {3}, new[] {7}, new[] {3, 7}}
		};
	}
}
