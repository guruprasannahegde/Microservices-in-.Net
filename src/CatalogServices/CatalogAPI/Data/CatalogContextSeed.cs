using CatalogAPI.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> mongoCollection)
        {
            bool productExists = mongoCollection.Find(p => true).Any();

            if (!productExists)
            {
                mongoCollection.InsertManyAsync(GetSeedValues());
            }
        }

        private static IEnumerable<Product> GetSeedValues()
        {
            return new List<Product>() {

                    new Product()
                    {
                        Name = "Samsung Galaxy Z",
                        Category ="Phone",
                        Description = "Best Product",
                        Summary = "Best Product",
                        ImageFile = "ImageFile",
                        Price = 1000
                    },
                    new Product()
                    {
                        Name = "Hp Laptop",
                        Category ="Laptop",
                        Description = "Best Laptop",
                        Summary = "Best Laptop",
                        ImageFile = "ImageFile",
                        Price = 1000
                    },
                    new Product()
                    {
                        Name = "Dell Monitor",
                        Category ="Monitor",
                        Description = "Best Monitor",
                        Summary = "Best Monitor",
                        ImageFile = "ImageFile",
                        Price = 1000
                    },
                    new Product()
                    {
                        Name = "ASUS Desktop",
                        Category ="Desktop",
                        Description = "Best Desktop",
                        Summary = "Best Desktop",
                        ImageFile = "ImageFile",
                        Price = 1000
                    },
                    new Product()
                    {
                        Name = "IPad",
                        Category ="Tablet",
                        Description = "Best Apple Ipad",
                        Summary = "Best IPad",
                        ImageFile = "ImageFile",
                        Price = 1000
                    }
                };
        }
    }
}
