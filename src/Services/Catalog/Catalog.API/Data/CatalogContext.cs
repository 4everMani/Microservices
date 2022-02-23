using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("Databasesettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("Databasesettings:DatabaseName"));
            Products = database.GetCollection<Product>(configuration.GetValue<string>("Databasesettings:CollectionName"));
            
        }
        public IMongoCollection<Product> Products { get;}
    }
}