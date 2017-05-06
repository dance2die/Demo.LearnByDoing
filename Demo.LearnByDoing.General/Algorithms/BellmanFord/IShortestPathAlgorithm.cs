using System.Collections.Generic;
using Demo.LearnByDoing.General.Algorithms.Graph;

namespace Demo.LearnByDoing.General.Algorithms.BellmanFord
{
	public interface IShortestPathAlgorithm
	{
		object GetShortestPath<T>(Graph<T> graph, Node<T> fromNode, Node<T> toNode);
	}
}