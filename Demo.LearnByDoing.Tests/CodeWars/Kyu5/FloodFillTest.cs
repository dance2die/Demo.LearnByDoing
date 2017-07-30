using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	public class FloodFillTest : BaseTest
	{
		public FloodFillTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestExample()
		{
			var expected = new int[,]
			{
				{1,4,3},
				{1,4,4},
				{2,3,4}}
			;

			var actual = new int[,]
			{
				{1,2,3},
				{1,2,2},
				{2,3,2}
			};

			Assert.Equal(expected, Kata.FloodFill(actual, 0, 1, 4));
		}
	}

	public partial class Kata
	{
		public static int[,] FloodFill(int[,] a, int x, int y, int newValue)
		{
			HashSet<Node> visited = new HashSet<Node>();

			var startValue = a[x, y];
			var startNode = new Node(x, y);
			visited.Add(startNode);

			var queue = new Queue<Node>();
			var neighbors = GetNeighbors(a, startNode, startValue).ToList();
			neighbors.Where(n => !visited.Contains(n)).ToList().ForEach(n => queue.Enqueue(n));

			while (queue.Count > 0)
			{
				var node = queue.Dequeue();
				if (visited.Contains(node)) continue;
				visited.Add(node);

				neighbors = GetNeighbors(a, node, startValue).ToList();
				neighbors.ForEach(n => { if (!visited.Contains(n)) { queue.Enqueue(n); } });
				var value = a[node.X, node.Y];
				if (value == newValue) continue;

				a[node.X, node.Y] = newValue;
			}

			return a;
		}

		private static IEnumerable<Node> GetNeighbors(int[,] a, Node node, int startValue)
		{
			Node top = GetNodeAt(a, node.X, node.Y - 1);
			Node right = GetNodeAt(a, node.X + 1, node.Y);
			Node bottom = GetNodeAt(a, node.X, node.Y + 1);
			Node left = GetNodeAt(a, node.X - 1, node.Y);

			if (top != null && a[top.X, top.Y] == startValue) yield return top;
			if (right != null && a[right.X, right.Y] == startValue) yield return right;
			if (bottom != null && a[bottom.X, bottom.Y] == startValue) yield return bottom;
			if (left != null && a[left.X, left.Y] == startValue) yield return left;
		}

		private static Node GetNodeAt(int[,] a, int x, int y)
		{
			if (x < 0 || x >= a.GetLength(0)) return null;
			if (y < 0 || y >= a.GetLength(1)) return null;

			return new Node(x, y);
		}
	}

	public class Node
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Node(int x, int y)
		{
			X = x;
			Y = y;
		}

		public override string ToString()
		{
			return string.Format("X:{0} Y:{1}", X, Y);
		}
	}
}
