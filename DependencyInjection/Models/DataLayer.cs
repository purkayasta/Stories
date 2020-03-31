using System.Collections.Generic;
namespace DependencyInjection.Models
{
    public interface IDataLayer
    {
        List<Article> GetAllArticles();
    }
    public class DataLayer : IDataLayer
    {
        public List<Article> GetAllArticles()
        {
            return Article.SeedData();
        }
    }
}