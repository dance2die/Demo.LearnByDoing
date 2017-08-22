using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Algorithms
{
	/// <summary>
	/// Re-implementing Bellman-Ford algorithm after reading "The Imposter's Syndrome".
	/// </summary>
	public class BellmanFordRepriseTest : BaseTest
	{
		public BellmanFordRepriseTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void TestBellmanFord()
		{
			var vertices = new[] {"S", "A", "B", "C", "D", "E"};
			var memo = new Dictionary<string, int>
			{
				{"S", 0},
				{"A", int.MaxValue},
				{"B", int.MaxValue},
				{"C", int.MaxValue},
				{"D", int.MaxValue},
				{"E", int.MaxValue},
			};
			var graph = new BellmanFordEdge[]
			{
				new BellmanFordEdge(@from: "S", to: "A", cost: 4),
				new BellmanFordEdge(@from: "S", to: "E", cost: -5),
				new BellmanFordEdge(@from: "A", to: "C", cost: 6),
				new BellmanFordEdge(@from: "B", to: "A", cost: 3),
				new BellmanFordEdge(@from: "C", to: "B", cost: -2),
				new BellmanFordEdge(@from: "D", to: "C", cost: 3),
				new BellmanFordEdge(@from: "D", to: "A", cost: 10),
				new BellmanFordEdge(@from: "E", to: "D", cost: 8),
			};
		}

	}

	public class BellmanFordEdge
	{
		public string From { get; set; }
		public string To { get; set; }
		public int Cost { get; set; }

		public BellmanFordEdge(string @from, string to, int cost)
		{
			From = @from;
			To = to;
			Cost = cost;
		}
	}

	public class BellmanFordReprise
	{
		
	}
}
