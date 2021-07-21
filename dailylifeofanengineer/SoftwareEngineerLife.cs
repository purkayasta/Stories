using System;
using System.Threading.Tasks;
using dailylifeofanengineer.Models;

namespace dailylifeofanengineer
{
    public class SoftwareEngineerLife : IEngineer, IDailyLife
    {
        public void DoOffice(int seconds)
        {
            Console.WriteLine("Attending Office");
            Task.Delay(System.TimeSpan.FromSeconds(seconds)).Wait();
            Console.WriteLine("Office - done");
        }

        public async Task DoOfficeAsync(int seconds)
        {
            Console.WriteLine("Attending Office");
            await Task.Delay(System.TimeSpan.FromSeconds(seconds));
            Console.WriteLine("Office - done");
        }

        public void DrinkCoffee(int seconds)
        {
            Console.WriteLine("Drinking Coffee");
            Task.Delay(System.TimeSpan.FromSeconds(seconds)).Wait();
            Console.WriteLine("Drinking Coffee - done");
        }

        public async Task DrinkCoffeeAsync(int seconds)
        {
            Console.WriteLine("Drinking Coffee");
            await Task.Delay(System.TimeSpan.FromSeconds(seconds));
            Console.WriteLine("Drinking Coffee - done");
        }

        public void EatBreakFast(int seconds)
        {
            Console.WriteLine("Eating Breakfast");
            Task.Delay(System.TimeSpan.FromSeconds(seconds)).Wait();
            Console.WriteLine("Eating Breakfast - done");
        }

        public async Task EatBreakFastAsync(int seconds)
        {
            Console.WriteLine("Eating Breakfast");
            await Task.Delay(System.TimeSpan.FromSeconds(seconds));
            Console.WriteLine("Eating Breakfast - done");
        }

        public void EatLunch(int seconds)
        {
            Console.WriteLine("Eating Lunch");
            Task.Delay(System.TimeSpan.FromSeconds(seconds)).Wait();
            Console.WriteLine("Eating lunch - done");
        }

        public async Task EatLunchAsync(int seconds)
        {
            Console.WriteLine("Eating Lunch");
            await Task.Delay(System.TimeSpan.FromSeconds(seconds));
            Console.WriteLine("Eating lunch - done");
        }

        public void MakeBreakfast(int seconds)
        {
            Task.Delay(System.TimeSpan.FromSeconds(seconds)).Wait();
            Console.WriteLine("Making Breakfast (🍞, 🥚, 🥒)- done");
        }

        public async Task MakeBreakfastAsync(int seconds)
        {
            await Task.Delay(System.TimeSpan.FromSeconds(seconds));
            Console.WriteLine("Making Breakfast (🍞, 🥚, 🥒)- done");
        }

        public void MakeCoffee(int seconds)
        {
            Console.WriteLine("Making Coffee");
            Task.Delay(System.TimeSpan.FromSeconds(seconds)).Wait();
            Console.WriteLine("Coffee is ready to rock - done");
        }

        public async Task MakeCoffeeAsync(int seconds)
        {
            Console.WriteLine("Making Coffee");
            await Task.Delay(System.TimeSpan.FromSeconds(seconds));
            Console.WriteLine("Coffee is ready to rock - done");
        }

        public void SelfStudy(int seconds)
        {
            Console.WriteLine("Self Study in Progress");
            Task.Delay(System.TimeSpan.FromSeconds(seconds)).Wait();
            Console.WriteLine("Self Study - done");
        }

        public void Sleep(int seconds)
        {
            Console.WriteLine("The Day is over");
            Task.Delay(System.TimeSpan.FromSeconds(seconds)).Wait();
        }

        public void WakeUp(int seconds)
        {
            Console.WriteLine("A new day, A new morning, A new work life");
            Task.Delay(System.TimeSpan.FromSeconds(seconds)).Wait();
            Console.WriteLine("Waked up.. ");
        }
    }
}