using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.MissionInterview._01_DataStructures
{
	public class QueueTest
	{
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

		[Fact]
		public void TestPeek()
		{
			var sut = new SungQueue<int>();
			Assert.Equal(0, sut.Peek());

			const int upto = 10;
			for (int i = 1; i <= upto; i++)
			{
				sut.Enqueue(i);
			}
		}

		[Fact]
		public void TestDequeue()
		{
			var sut = new SungQueue<int>();

			const int upto = 10;
			for (int i = 1; i <= upto; i++)
			{
				sut.Enqueue(i);
			}

			for (int expected = 1; expected <= upto; expected++)
			{
				var actual = sut.Dequeue();
				Assert.Equal(expected, actual);
			}

			Assert.Throws<InvalidOperationException>(() => sut.Dequeue());
		}
	}

	public class SungQueue<T>
	{
		private int _count = 0;
		private readonly DoublySungLinkedList<T> _list = new DoublySungLinkedList<T>();

		public void Enqueue(T value)
		{
			_count++;
			_list.Append(value);
		}

		public IEnumerable<T> Traverse()
		{
			return _list.Traverse().Select(a => a.Value);
		}

		public T Dequeue()
		{
			if (_count == 0)
				throw new InvalidOperationException("Queue empty.");

			_count--;
			var result = _list.Head;
			_list.Remove(_list.Head);
			return result.Value;
		}

		public T Peek()
		{
			return _list.Head == null ? default(T) : _list.Head.Value;
		}
	}
}
