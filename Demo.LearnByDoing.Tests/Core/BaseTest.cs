using System.Linq;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Core
{
    public abstract class BaseTest
    {
        protected readonly ITestOutputHelper _output;

        protected BaseTest(ITestOutputHelper output)
        {
            _output = output;
        }

        protected bool AreTwoMultidimensionalArraysSame(int[,] matrix1, int[,] matrix2)
        {
            return matrix1.Rank == matrix2.Rank
                   && Enumerable.Range(0, matrix1.Rank)
                       .All(dimension => matrix1.GetLength(dimension) == matrix2.GetLength(dimension))
                   && matrix1.Cast<int>().SequenceEqual(matrix2.Cast<int>());
        }
    }
}