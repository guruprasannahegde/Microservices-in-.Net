using CatalogAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Repositories.Interfaces
{
    public interface IProductRepositories
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<IEnumerable<Product>> GetProductsByCategory(string categoryName);

        Task<IEnumerable<Product>> GetProductsByName(string name);

        Task<Product> GetProduct(string ID);

        Task<bool> Update(Product product);

        Task Create(Product product);

        Task<bool> Delete(string ID);

    }
}
