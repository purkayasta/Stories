using System;
using DependencyInjection.Injection;
using DependencyInjection.Models;
namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting !");
            MethodBased();
            Console.WriteLine("Ending !");
        }
        static void MethodBased()
        {
            var methodBasedService = new MethodBased().GetArticles(new DataLayer());
            methodBasedService.ForEach(article =>
            {
                Console.WriteLine($"This {article.Name} was published by {article.AuthorName}");
            });
        }
        static void PropertyBased()
        {
            var propertyBased = new PropertyBased();
            propertyBased.dataLayerObject = new DataLayer();
            var service = propertyBased.GetAllAritcles();
            service.ForEach(article =>
            {
                Console.WriteLine($"This {article.Name} was published by {article.AuthorName}");
            });
        }
        static void ConstructorBased()
        {
            var service = new ConstructorBased(new DataLayer());
            service.GetAllAritcles().ForEach(article =>
            {
                Console.WriteLine($"This {article.Name} was published by {article.AuthorName}");
            });
        }
    }
}
