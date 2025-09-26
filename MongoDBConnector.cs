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

        public IMongoDatabase GetDatabase() => _database;

        // ✅ Ping method handles both success and fail
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
                return false; // failed to connect or run ping
            }
        }
    }
}
