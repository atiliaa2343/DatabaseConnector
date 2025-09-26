using MongoDB.Driver; // Make sure you have MongoDB.Driver NuGet package installed

namespace DatabaseConnector
{
    public class MongoDBConnector
    {
        private readonly IMongoDatabase _database; // field to hold the database connection

        public MongoDBConnector(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        // Optional: expose the database so it can be used in other classes
        public IMongoDatabase GetDatabase()
        {
            return _database;
        }
    }
}
