using System.Threading.Tasks;

namespace ParaConcurrent.App
{
    public abstract class SetOfTasks
    {
        public abstract Task Task1();
        public abstract Task Task2();
        public Task NormalTask()
        {
            System.Console.WriteLine("Normal Task Started");
            Task.Delay(3000).Wait();
            System.Console.WriteLine("Download sync way");
            Task.Delay(1000).Wait();
            System.Console.WriteLine("Normal Task Completed");
            return Task.FromResult("");
        }
    }
}
