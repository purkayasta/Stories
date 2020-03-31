using System.Collections.Generic;
using DependencyInjection.Models;

namespace DependencyInjection.Injection
{
    public class ConstructorBased
    {
        private readonly IDataLayer _dataLayer;
        public ConstructorBased(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }
        public List<Article> GetAllAritcles() => _dataLayer.GetAllArticles();
    }
}