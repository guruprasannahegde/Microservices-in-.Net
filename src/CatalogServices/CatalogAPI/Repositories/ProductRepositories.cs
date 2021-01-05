using CatalogAPI.Data.Interfaces;
using CatalogAPI.Entities;
using CatalogAPI.Repositories.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Repositories
{
    public class ProductRepositories : IProductRepositories
    {
        private readonly ICatalogContext _context;

        public ProductRepositories(ICatalogContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.Find(x => true).ToListAsync();
        }
        public async Task<Product> GetProduct(string ID)
        {
            return await _context.Products.Find(x => x.ID == ID).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Name, name);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(p => p.Category, categoryName);
            return await _context.Products.Find(filter).ToListAsync();
        }


        public async Task Create(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task<bool> Update(Product product)
        {
            var updateResults = await _context.Products.ReplaceOneAsync(filter: g => g.ID == product.ID, replacement: product);
            return updateResults.IsAcknowledged && updateResults.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string ID)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.ID, ID);

            var deletedResults = await _context.Products.DeleteOneAsync(filter);
            return deletedResults.IsAcknowledged && deletedResults.DeletedCount > 0;
        }

    }
}
