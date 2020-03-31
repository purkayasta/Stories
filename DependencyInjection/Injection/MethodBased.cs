using System.Collections.Generic;
using DependencyInjection.Models;

namespace DependencyInjection.Injection
{
    public class MethodBased
    {
        private IDataLayer _dataLayer;
        public List<Article> GetArticles(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
            return _dataLayer.GetAllArticles();
        }
    }
}