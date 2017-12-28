using System;
using System.Collections.Generic;
using System.Text;

namespace DevA
{
    class BubbleSortClass : RunableClass
    {
        public void BubbleSort<T>(List<T> sortingList, Func<T, T, bool> isDesOrder)
        {

            for (int i = 0; i <= sortingList.Count - 1; i++)
            {

                for (int j = sortingList.Count - 1; j >= i + 1; j--)
                {

                    if (isDesOrder(sortingList[j - 1], sortingList[j]))
                    {
                        T swap = sortingList[j];
                        sortingList[j] = sortingList[j - 1];
                        sortingList[j - 1] = swap;
                    }
                }
            }
        }


        public void Run()
        {

            List<int> list = new List<int>();
            list.Add(5);
            list.Add(1);
            list.Add(3);
            list.Add(2);
            list.Add(12);
            list.Add(6);
            list.Add(234);
            
            List<string> stringList = new List<string>();
            stringList.Add("H");
            stringList.Add("F");
            stringList.Add("G");
            stringList.Add("E");
            stringList.Add("C");
            stringList.Add("D");
            stringList.Add("B");
            stringList.Add("A");

            BubbleSort(list, (arg1, arg2) => arg1 > arg2);

            BubbleSort(stringList, (arg1, arg2) => string.Compare(arg1,arg2) == 1);
           
            Console.WriteLine("DONE");

        }

    }
}
