using System;

namespace DevA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");

            //
            //RunableClass runable = new {ClassName}();
            //Change {ClassName} To class that you want to run
            //

            RunableClass runable = new InsertionSortClass();
            runable.Run();

            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
