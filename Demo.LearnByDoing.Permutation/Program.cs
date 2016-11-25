using System;

namespace Demo.LearnByDoing.Permutation
{
    class Program
    {
        static void Main(string[] args)
        {
            Permutation("abc");
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
