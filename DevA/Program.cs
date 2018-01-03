using System;

namespace DevA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");

            RunableClass runable = new MergeSortClass();
            runable.Run();

            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
