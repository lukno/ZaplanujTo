using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;

namespace ZaplanujTo.Infrastructure.Persistence;

// ToDo
public class MongoDbContext
{
    public static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["MongoConnectionString"].ConnectionString;
    }
    public MongoDbContext()
    {

        var client = new MongoClient(GetConnectionString());
        //var database = client.GetDatabase(DatabaseName);
        // var collection = database.GetCollection<BsonDocument>("bar");

    }

}
