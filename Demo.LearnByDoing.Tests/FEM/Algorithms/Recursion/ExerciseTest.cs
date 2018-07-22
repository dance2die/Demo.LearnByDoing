using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.FEM.Algorithms.Recursion
{
    /// <summary>
    /// https://github.com/kuychaco/algoClass/blob/master/recursion/recursionIntro.js
    /// </summary>
    public class ExerciseTest
    {
        public static IEnumerable<object[]> GetSampleCaseFor1And2()
        {
            yield return new object[] { new[] { 5, 4, 3, 2, 1, 0 }, 5 };
        }

        /// <summary>
        /// 1. Write a function that loops through the numbers n down to 0.
        /// If you haven't done so try using a while loop to do this.
        /// </summary>
        [Theory]
        [MemberData(nameof(GetSampleCaseFor1And2))]
        public void TestExercise1(int[] expected, int n)
        {
            var actual = Exercise1(n);
            Assert.True(expected.SequenceEqual(actual));
        }

        private IEnumerable<int> Exercise1(int n)
        {
            for (int i = n; i >= 0; i--) yield return i;
        }

        /// <summary>
        /// 2. Next, try looping just like above except using recursion
        /// </summary>
        [Theory]
        [MemberData(nameof(GetSampleCaseFor1And2))]
        public void TestExercise2(int[] expected, int n)
        {
            var actual = Exercise2(n);
            Assert.True(expected.SequenceEqual(actual));
        }

        private IEnumerable<int> Exercise2(int n)
        {
            if (n <= 0)
            {
                yield return 0;
                yield break;
            }

            yield return n;
            foreach (var i in Exercise2(n - 1).ToList()) yield return i;
        }

        public static IEnumerable<object[]> GetSampleCaseFor3And4()
        {
            yield return new object[] { 64, 8, 2 };
            yield return new object[] { 27, 3, 3 };
            yield return new object[] { 1, 1, 3 };
            yield return new object[] { 256, 2, 8 };
            yield return new object[] { 512, 2, 9 };
            yield return new object[] { 1024, 2, 10 };
        }

        /// <summary>
        /// 3. Write a function 'exponent' that takes two arguments base, and expo,
        /// uses a while loop to return the exponenet value of the base.
        /// </summary>
        [Theory]
        [MemberData(nameof(GetSampleCaseFor3And4))]
        public void TestExercise3(int expected, int @base, int expo)
        {
            var actual = Exercise3(@base, expo);
            Assert.Equal(expected, actual);
        }

        private int Exercise3(int @base, int expo)
        {
            var result = @base;
            for (int i = 1; i < expo; i++)
            {
                result *= @base;
            }

            return result;
        }

        ///// <summary>
        ///// 4. Write a function 'RecursiveExponent' that takes two arguments 
        ///// base, and expo, recursively returns exponent value of the base.
        ///// </summary>
        //[Theory]
        //[MemberData(nameof(GetSampleCaseFor3And4))]
        //public void TestExercise4(int[] expected, int n)
        //{

        //}

        ///// <summary>
        ///// 5. Write a function 'recursiveMultiplier' that takes two arguments, 
        ///// 'arr and num', and multiplies each arr value into by num and returns an array of the values.
        ///// </summary>
        //[Theory]
        //[MemberData(nameof(GetSampleCaseFor1And2))]
        //public void TestExercise5(int[] expected, int n)
        //{

        //}

        ///// <summary>
        ///// 6. Write a function 'recursiveReverse' that takes an array 
        ///// and uses recursion to return its contents in reverse
        ///// </summary>
        //[Theory]
        //[MemberData(nameof(GetSampleCaseFor1And2))]
        //public void TestExercise6(int[] expected, int n)
        //{

        //}
    }
}
