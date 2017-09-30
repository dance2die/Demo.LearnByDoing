using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.MissionInterview._01_DataStructures
{
	public class QueueTest : BaseTest
	{
		public QueueTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestEnqueue()
		{
			var sut = new SungQueue<int>();

			const int upto = 10;
			for (int i = 1; i <= upto; i++)
			{
				sut.Enqueue(i);
			}

			Assert.True(Enumerable.Range(1, upto).SequenceEqual(sut.Traverse()));
		}
	}

	public class SungQueue<T>
	{
		private int _count = 0;
		private DoublySungLinkedList<T> _list = new DoublySungLinkedList<T>();

		public void Enqueue(T value)
		{
			
		}

		public IEnumerable<T> Traverse()
		{
			return _list.Traverse().Select(a => a.Value);
		}
	}
}
