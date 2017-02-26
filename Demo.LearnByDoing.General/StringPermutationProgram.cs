using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.LearnByDoing.General
{
    /// <summary>
    /// Code based on http://www.geeksforgeeks.org/write-a-c-program-to-print-all-permutations-of-a-given-string/
    /// Youtube: https://www.youtube.com/watch?v=AfxHGNRtFac
    /// </summary>
    public class StringPermutationProgram
    {
        public static void Main(string[] args)
        {
            string value = "ABC";
            Permute(value, 0, value.Length - 1);
        }

        private static void Permute(string value, int left, int right)
        {
            if (left == right)
            {
                Console.WriteLine(value);
                return;
            }

            for (int i = left; i <= right; i++)
            {
                Swap(ref value, left, i);
                Permute(value, left + 1, right);
                Swap(ref value, left, i);   // back tracking: set the value to original value
            }
        }

        private static void Swap(ref string value, int i, int j)
        {
            var a = value.ToCharArray();
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
            value = new string(a);
        }
    }
}
