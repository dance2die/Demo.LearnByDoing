using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.Tests.MissionInterview
{
	public class SungStack<T>
	{
		private readonly SungLinkedList<T> _list;
		private int _count;

		public SungStack()
		{
			_list = new SungLinkedList<T>();
			_count = 0;
		}

		public void Push(T value)
		{
			_count++;
			var newNode = new SungNode<T>(value) {Next = _list.Head};
			_list.Head = newNode;
		}

		public IEnumerable<T> Traverse()
		{
			return _list.Traverse().Select(o => o.Value);
		}

		public T Pop()
		{
			if (_count == 0)
				throw new InvalidOperationException("Stack empty.");

			_count--;
			var result = _list.Head.Value;
			//_list.Head = _list.Head.Next;
			_list.Remove(_list.Head);

			return result;
		}

		public T Peek()
		{
			if (_count == 0)
				return default(T);
			return _list.Head.Value;
		}
	}
}