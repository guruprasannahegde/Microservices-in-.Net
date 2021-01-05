using CatalogAPI.Data.Interfaces;
using CatalogAPI.Entities;
using CatalogAPI.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Data
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }

        public CatalogContext(ICatalogDatabaseSettings settings)
        {
            var mongoClient = new MongoClient(settings.ConnectionString);

            var databaseName = mongoClient.GetDatabase(settings.DatabaseName);

            Products = databaseName.GetCollection<Product>(settings.CollectionName);

            CatalogContextSeed.SeedData(Products);
        }
    }
}
