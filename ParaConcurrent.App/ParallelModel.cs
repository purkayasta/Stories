using System.Threading;
using System.Threading.Tasks;

namespace ParaConcurrent.App
{
    /// <summary>
    /// Parallelism means doing a lot of things at once
    /// </summary>
    class ParallelModel : SetOfTasks
    {
        public override Task Task1()
        {
            System.Console.WriteLine("Task1 started....");
            Task.Delay(5000);
            System.Console.WriteLine("Task1 Finished");
            return Task.CompletedTask;
        }

        public override Task Task2()
        {
            System.Console.WriteLine("Task2 started....");
            Task.Delay(5000);
            System.Console.WriteLine("Task2 Finished");
            return Task.CompletedTask;
        }
    }
}
