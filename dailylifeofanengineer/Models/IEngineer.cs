using System.Threading.Tasks;

namespace dailylifeofanengineer.Models
{
    public interface IEngineer
    {
        public void SelfStudy(int seconds);
        public Task MakeCoffeeAsync(int seconds);
        public void MakeCoffee(int seconds);
        public void DrinkCoffee(int seconds);
        public Task DrinkCoffeeAsync(int seconds);
    }
}