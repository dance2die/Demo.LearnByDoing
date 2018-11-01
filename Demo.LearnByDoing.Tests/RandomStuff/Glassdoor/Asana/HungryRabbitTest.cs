using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.RandomStuff.Glassdoor.Asana
{
    public class HungryRabbitTest
    {
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void TestHungryRabbits(int expected, int[,] input)
        {
            var actual = GetCarrotCount(input);
            Assert.Equal(expected, actual);
        }

        private int GetCarrotCount(int[,] m)
        {
            var center = GetCenter(m);
            var max = center.Value;
            var next = GetNext(center.X, center.Y, m);

            do
            {
                max += next.Value;
                next = GetNext(next.X, next.Y, m);
            } while (next.Value != 0);

            return max;
        }

        private Location GetNext(int x, int y, int[,] m)
        {
            Location top = GetValueAt(x, y - 1, m);
            Location right = GetValueAt(x + 1, y, m);
            Location bottom = GetValueAt(x - 1, y, m);
            Location left = GetValueAt(x, y - 1, m);

            var locations = new[] {top, right, bottom, left};
            int max = locations.Max(_ => _.Value);
            return locations.FirstOrDefault(_ => _.Value == max);
        }

        private Location GetValueAt(int x, int y, int[,] m)
        {
            var result = new Location();
            if ((0 <= x && x < m.GetLength(0)) &&
                (0 <= y && y < m.GetLength(1)))
            {
                result.X = x;
                result.Y = y;
                result.Value = m[x, y];
            }

            return result;
        }

        private Location GetCenter(int[,] m)
        {
            int rs = 0;
            int re = 0;
            var rowLength = m.GetLength(0);
            if (rowLength % 2 == 1)
            {
                rs = rowLength / 2;
                re = rs;
            }
            else
            {
                rs = rowLength / 2 - 1;
                re = rowLength / 2;
            }

            int cs = 0;
            int ce = 0;
            var colLength = m.GetLength(1);
            if (colLength % 2 == 1)
            {
                cs = colLength / 2;
                ce = cs;
            }
            else
            {
                cs = colLength / 2 - 1;
                ce = colLength / 2;
            }

            var max = new Location { Value = 0 };

            for (int r = rs; r <= re; r++)
            {
                for (int c = cs; c <= ce; c++)
                {
                    var curr = m[r, c];
                    if (curr > max.Value)
                    {
                        max.Value = curr;
                        max.X = r;
                        max.Y = c;
                    }
                }
            }

            return max;
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[]
            {
                27,
                new[,]
                {
                    {5, 7, 8, 6, 3},
                    {0, 0, 7, 0, 4},
                    {4, 7, 3, 4, 9},
                    {3, 1, 0, 5, 8},
                }
            };
            yield return new object[]
            {
                27,
                new[,]
                {
                    {5, 7, 8, 6},
                    {0, 0, 7, 0},
                    {4, 6, 3, 4},
                    {3, 1, 0, 5}
                }
            };
            yield return new object[]
            {
                22,
                new[,]
                {
                    {5, 7, 8},
                    {0, 0, 7},
                }
            };
            yield return new object[]
            {
                20,
                new[,]
                {
                    {5, 7, 8, 6, 3},
                }
            };
        }
    }

    class Location
    {
        public int Value { get; set; } = 0;
        public int X { get; set; }
        public int Y { get; set; }
    }
}
