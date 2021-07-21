using System;
using System.Diagnostics;
using System.Threading.Tasks;
using dailylifeofanengineer.Models;
using Humanizer;

namespace dailylifeofanengineer
{
    class Program
    {
        async static Task Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Person person = new()
            {
                Firstname = "Pritom",
                Lastname = "Purkayasta"
            };
            Console.WriteLine("==== Program Starting ====");
            Console.WriteLine("\n*** Sync Way *** 💤💤\n");
            stopWatch.Start();
            DailyLifeOfAnSoftwareEngineer(person);
            var syncTiming = stopWatch.Elapsed.Humanize();
            stopWatch.Stop();

            System.Console.WriteLine("\n*** Async Way 🎉🍌 ***\n");

            stopWatch.Restart();
            await DailyLifeOfAnSoftwareEngineerAsync(person);
            var asyncTiming = stopWatch.Elapsed.Humanize();
            stopWatch.Stop();

            Console.WriteLine("\n\n ===========================================");
            Console.WriteLine($"Sync Timing => {syncTiming} and Async Timing => {asyncTiming}");

            Console.WriteLine("=== Program Ended === ☑☑☑");
        }
        private static async Task DailyLifeOfAnSoftwareEngineerAsync(Person person)
        {
            person.WakeUp(1);
            var preparingBreakfast = person.MakeBreakfastAsync(3);
            var preparingCoffee = person.MakeCoffeeAsync(2);
            await Task.WhenAll(preparingBreakfast, preparingCoffee);

            var eatingBreakfast = person.EatBreakFastAsync(3);
            var drinkingCoffee = person.DrinkCoffeeAsync(2);
            await eatingBreakfast;
            await drinkingCoffee;

            var office = person.DoOfficeAsync(10);
            var eatingLunch = person.EatLunchAsync(2);
            await office;
            await eatingLunch;

            person.SelfStudy(2);
            person.Sleep(1);
        }
        private static void DailyLifeOfAnSoftwareEngineer(Person person)
        {
            person.WakeUp(1);
            person.MakeBreakfast(3);
            person.MakeCoffee(2);
            person.EatBreakFast(3);
            person.DrinkCoffee(2);
            person.DoOffice(10);
            person.EatLunch(2);
            person.SelfStudy(2);
            person.Sleep(1);
        }
    }
}
