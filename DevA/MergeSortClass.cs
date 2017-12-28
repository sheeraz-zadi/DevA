using System;
using System.Collections.Generic;
using System.Text;

namespace DevA
{
    class MergeSortClass : RunableClass
    {

        public void Merge(int[] array, int begin, int middle, int end) {
            Console.WriteLine("MERGE");

            int SizeFirstHalf = middle - begin +1;
            int SizeSecondHalf = end - middle;

            Console.WriteLine("SizeFirstHalf="+SizeFirstHalf+" - SizeSecondHalf="+SizeSecondHalf);

            int[] firstHalf = new int[SizeFirstHalf + 1];
            int[] secondHalf = new int[SizeSecondHalf + 1];
            
            int i, j;

            for (i = 0; i < SizeFirstHalf; i++) {
                firstHalf[i] = array[begin + i];
            }
            for (j = 0; j < SizeSecondHalf; j++) {
                secondHalf[j] = array[middle + j];
            }
            Console.WriteLine("firstHalf=" + string.Join(",", firstHalf) + " - secondHalf=" + string.Join(",", secondHalf));

            firstHalf[SizeFirstHalf] = int.MaxValue;
            secondHalf[SizeSecondHalf] = int.MaxValue;

            Console.WriteLine("firstHalf=" + string.Join(",", firstHalf) + " - secondHalf=" + string.Join(",", secondHalf));

            i = j = 0;

            for (int k = begin; k < end; k++) {
                if (firstHalf[i] <= secondHalf[j])
                {
                    array[k] = firstHalf[i];
                    i++;
                }
                else {
                    array[k] = secondHalf[j];
                    j++;
                }
            }
            
            Console.WriteLine("array=" + string.Join(",", array));

        }

        public void MergeSort(int [] array, int begin, int end) {

            Console.WriteLine("MergeSort: Begin="+begin+" - End="+end);
            if (begin < end) {
                int middle = (begin + end) / 2;
                Console.WriteLine("Middle = "+middle);

                MergeSort(array, begin, middle);
                MergeSort(array, middle+1, end);
                Merge(array, begin,middle,end);
            }
        }
        

        public void Run()
        {
            int[] testArray = new int[] { 3, 5, 6, 8, 9, 1 };
            MergeSort(testArray, 0, testArray.Length);
        }
    }
}
