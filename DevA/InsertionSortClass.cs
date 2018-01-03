using System;
using System.Collections.Generic;
using System.Text;

namespace DevA
{
    class InsertionSortClass : RunableClass
    {
       
        public void InsertionSort<T>(List<T> sortingList, Func<T,T, bool> isDesOrder) {

            for (int i = 1; i <= sortingList.Count - 1; i++) {

                T compData = sortingList[i];
                int j = i - 1;

                while (j > -1 && isDesOrder(compData, sortingList[j])) {
                    sortingList[j + 1] = sortingList[j];
                    j--;
                }
                sortingList[j+1] = compData;
            }
        }

       
        public void Run() {

            List<int> list = new List<int>();
            list.Add(5);
            list.Add(1);
            list.Add(3);
            list.Add(2);
            list.Add(12);
            list.Add(6);
            list.Add(4);

            List<string> stringList = new List<string>();
            stringList.Add("H");
            stringList.Add("F");
            stringList.Add("G");
            stringList.Add("E");
            stringList.Add("C");
            stringList.Add("D");
            stringList.Add("B");
            stringList.Add("A");

            Console.WriteLine("DONE");

        }
    }
}
