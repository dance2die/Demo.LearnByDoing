using System.Collections.Generic;

namespace Demo.LearnByDoing.Tests.MissionInterview._01_DataStructures
{
	public class SungGraphTest
	{
	}

	public class SungVertex<T>
	{
		public T Value { get; set; }
		public Dictionary<SungVertex<T>, int> Edges { get; }

		public SungVertex(T value)
		{
			Value = value;
			Edges = new Dictionary<SungVertex<T>, int>();
		}

		public SungVertex<T> To(SungVertex<T> toVertex, int cost)
		{
			if (!Edges.ContainsKey(toVertex))
				Edges.Add(toVertex, cost);
			return this;
		}
	}
}
