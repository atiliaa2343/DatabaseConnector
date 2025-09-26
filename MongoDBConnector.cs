using MongoDB.Bson;
using MongoDB.Driver;

namespace DatabaseConnector
{
    public class MongoDBConnector
    {
        private readonly IMongoDatabase _database;
        private readonly MongoClient _client;

        public MongoDBConnector(string connectionString, string databaseName)
        {
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(databaseName);
        }

        // Expose the database if needed
        public IMongoDatabase GetDatabase()
        {
            return _database;
        }

        // ✅ New method: Ping MongoDB to check connectivity
        public bool Ping()
        {
            try
            {
                var command = new BsonDocument("ping", 1);
                _database.RunCommand<BsonDocument>(command);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
