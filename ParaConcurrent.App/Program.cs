using System;
using System.Threading.Tasks;

namespace ParaConcurrent.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program Started..");
            Console.WriteLine("1. Parallelism \n2. Concurrency \nChoice: ");

            int.TryParse(Console.ReadLine(), out int option);
            switch (option)
            {
                case 1:
                    InvokeParallelModel();
                    break;
                case 2:
                    InvokeConcurrentModel();
                    break;
                default:
                    break;
            }

            Console.WriteLine("Program Finished..");
            Console.ReadKey();
        }

        private static void InvokeConcurrentModel()
        {
            SetOfTasks model = new ConcurrencyModel();
            model.Task1();
            model.Task2();
            model.NormalTask();
        }
        private static void InvokeParallelModel()
        {
            SetOfTasks model = new ParallelModel();
            Task.Factory.StartNew(model.Task1);
            Task.Factory.StartNew(model.Task2);
            Task.Factory.StartNew(model.NormalTask);
        }
    }
}
