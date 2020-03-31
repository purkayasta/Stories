using System.Collections.Generic;
namespace DependencyInjection.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }

        public static List<Article> SeedData()
        {
            return new List<Article>
            {
                new Article {
                    Id = 1,
                    Name = "Dependency Injection",
                    Description = "Design pattern tutorial",
                    AuthorName = "Pritom"
                },
                new Article {
                    Id = 2,
                    Name = "Singleton Pattern",
                    Description = "Design pattern tutorial",
                    AuthorName = "Pritom"
                }
            };
        }
    }
}