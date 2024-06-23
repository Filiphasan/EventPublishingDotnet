using Core.Models.OptionModels;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Data.Contexts;

public class MongoDbContext(
    IMongoClient mongoClient,
    IOptions<AppsettingOption> appsettingOption
)
{
    public IMongoDatabase Database { get; } = mongoClient.GetDatabase(appsettingOption.Value.Mongo.DatabaseName);

    //Collections

    public IMongoCollection<TEntity> GetCollection<TEntity>(MongoCollectionSettings? settings = null)
    {
        return Database.GetCollection<TEntity>(typeof(TEntity).Name, settings);
    }
}
