using System.Threading.Tasks;

namespace ParaConcurrent.App
{
    class ConcurrencyModel : SetOfTasks
    {
        public override async Task Task1()
        {
            System.Console.WriteLine("Task1 started....");
            await Task.Delay(5000);
            System.Console.WriteLine("Task1 Finished");
        }

        public override async Task Task2()
        {
            System.Console.WriteLine("Task2 started....");
            await Task.Delay(5000);
            System.Console.WriteLine("Task2 Finished");
        }
    }
}
