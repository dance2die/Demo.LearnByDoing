using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.LearnByDoing.General.Sort
{
    /// <summary>
    /// https://www.youtube.com/watch?v=EeQ8pwjQxTM and Cracking the Coding Interview Chapter 10
    /// </summary>
    class MergeSortProgram
    {
        public static void Main(string[] args)
        {
            int[] a = {108, 15, 50, 4, 8, 42, 23, 16};
            int[] helper = new int[a.Length];
            int low = 0;
            int high = a.Length - 1;

            MergeSort(a, helper, low, high);
            a.ToList().ForEach(Console.WriteLine);
        }

        private static void MergeSort(int[] a, int[] helper, int low, int high)
        {
            if (low < high)
            {
                int middle = (low + high) / 2;
                MergeSort(a, helper, low, middle);       // sort left half
                MergeSort(a, helper, middle + 1, high);  // sort right half
                Merge(a, helper, low, middle, high);
            }
        }

        private static void Merge(int[] a, int[] helper, int low, int middle, int high)
        {
            // copy both halves into a helper array
            for (int i = low; i < high; i++)
            {
                helper[i] = a[i];
            }

            int helperLeft = low;
            int helperRight = middle + 1;
            int current = low;

            // Iterate through helper array. 
            // Compare the left and right half, 
            // copying back the smaller element from the two halves into the orignal array
            while (helperLeft <= middle && helperRight <= high)
            {
                if (helper[helperLeft] <= helper[helperRight])
                {
                    a[current] = helper[helperLeft];
                    helperLeft++;
                }
                // Right element is smaller than left element so we copy the right one
                else
                {
                    a[current] = helper[helperRight];
                    helperRight++;
                }

                current++;
            }

            // copy the rest of the left side of the array into the target array
            // ToDO: I don't really understand this part, yet.
            int remaining = middle - helperLeft;
            for (int i = 0; i <= remaining; i++)
            {
                a[current + i] = helper[helperLeft + i];
            }
        }
    }
}
