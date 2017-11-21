using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// Temperature Tracker
	/// https://www.interviewcake.com/question/csharp/temperature-tracker
	/// </summary>
	public class Question007Test
	{
		[Theory]
		[MemberData(nameof(GetTestInsertData))]
		public void TestInsert(int[] input, int max, int min, double mean, int mode)
		{
			var sut = new TemperatureTracker();
			input.ToList().ForEach(n => sut.Insert(n));

			Assert.Equal(max, sut.GetMax());
			Assert.Equal(min, sut.GetMin());
			Assert.Equal(mean, sut.GetMean(), 2);
			//Assert.Equal(mode, sut.GetMode());
		}

		public static IEnumerable<object[]> GetTestInsertData()
		{
			// [3]
			yield return new object[] {new []{3}, 3, 3, 3, 3};
			// [3, 3]
			yield return new object[] { new[] { 3, 3 }, 3, 3, 3, 3};
			// [3, 3, 1]
			yield return new object[] { new[] { 3, 3, 1 }, 3, 1, (double)7/3, 3};
			// [3, 3, 1, 2]
			yield return new object[] { new[] { 3, 3, 1, 2 }, 3, 1, (double)9/4, 3};
			// [3, 3, 1, 2, 1]
			yield return new object[] { new[] { 3, 3, 1, 2, 1 }, 3, 1, 2, 3};
		}
	}

	class TemperatureTracker
	{
		/// <summary>
		/// key = unique value, value = count of items
		/// </summary>
		//private readonly Dictionary<int, int> _map = new Dictionary<int, int>();

		private int _max = int.MinValue;
		private int _min = int.MaxValue;

		// For keeping track of mean.
		private int _sum = 0;
		private int _count = 0;
		private double _mean = 0;


		private int _mode = 0;

		public void Insert(int newItem)
		{
			//if (!_map.ContainsKey(newItem))
			//	_map.Add(newItem, 0);
			//_map[newItem]++;

			if (newItem > _max) _max = newItem;
			if (newItem < _min) _min = newItem;

			//_mean = (double)_map.Sum(p => p.Key * p.Value) / _map.Values.Sum();
			_sum += newItem;
			_count++;
			_mean = (double) _sum / _count;

			//int maxOccurrence = _map.Max(p => p.Value);
			//_mode = _map.First(p => p.Value == maxOccurrence).Key;
		}


		public int GetMax() => _max;
		public int GetMin() => _min;
		public double GetMean() => _mean;
		public int GetMode() => _mode;
	}
}
