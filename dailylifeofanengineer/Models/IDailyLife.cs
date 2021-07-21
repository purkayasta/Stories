using System.Threading.Tasks;

namespace dailylifeofanengineer.Models
{
    public interface IDailyLife
    {
        public void WakeUp(int seconds);
        public Task MakeBreakfastAsync(int seconds);
        public void MakeBreakfast(int seconds);
        public void EatBreakFast(int seconds);
        public Task EatBreakFastAsync(int seconds);
        public void DoOffice(int seconds);
        public Task DoOfficeAsync(int seconds);
        public Task EatLunchAsync(int seconds);
        public void EatLunch(int seconds);
        public void Sleep(int seconds);
    }
}