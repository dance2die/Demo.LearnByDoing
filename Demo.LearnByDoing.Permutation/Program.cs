using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.Permutation
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "abc";
            //Permutation(input);

            //Console.WriteLine("++++++++++");

            IEnumerable<string> permutations = GetPermutations(input).ToList();
            foreach (var permutation in permutations)
            {
                Console.WriteLine(permutation);
            }
        }

        private static IEnumerable<string> GetPermutations(string str)
        {
            return GetPermutations(str, "");
        }

        private static IEnumerable<string> GetPermutations(string str, string prefix)
        {
            Console.WriteLine("str:prefix => {0}:{1} ", str, prefix);

            if (str.Length == 0)
            {
                Console.WriteLine("\tstr.Length == 0: prefix: '{0}'", prefix);
                yield return prefix;
            }

            for (int i = 0; i < str.Length; i++)
            {
                string remainder = str.Substring(0, i) + str.Substring(i + 1);
                //Console.WriteLine("'{0}' => remainder: {1}", i, remainder);
                //Console.WriteLine("\tprefix:str.Substring(0, i) => str.Substring(i + 1) {0}:{1}{2}", prefix, str.Substring(0, i), str.Substring(i + 1));

                foreach (var permutation in GetPermutations(remainder, prefix + str[i]).ToList())
                {
                    //Console.WriteLine("\tpermutation: {0}", permutation);
                    yield return permutation;
                }
            }
        }

        private static void Permutation(string str, string prefix = "")
        {
            if (str.Length == 0)
            {
                Console.WriteLine(prefix);
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    string remainder = str.Substring(0, i) + str.Substring(i + 1);
                    Permutation(remainder, prefix + str[i]);
                }
            }
        }
    }
}
