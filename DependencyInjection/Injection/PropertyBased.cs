using System.Collections.Generic;
using DependencyInjection.Models;

namespace DependencyInjection.Injection
{
    public class PropertyBased
    {
        private IDataLayer _dataLayer;
        public IDataLayer dataLayerObject
        {
            set 
            {
                this._dataLayer = value;
            }
            get 
            {
                if (dataLayerObject == null)
                    return null; // Failed to intialized Datalayer object
                else
                    return _dataLayer;
            }
        }
        public List<Article> GetAllAritcles() => _dataLayer.GetAllArticles();
    }
}