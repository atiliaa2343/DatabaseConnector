using System.Threading.Tasks;
using Xunit;
using Testcontainers.MongoDb;

namespace DatabaseConnector.Tests
{
    public class MongoDBConnectorTest : IAsyncLifetime
    {
        private readonly MongoDbContainer _mongoDbContainer;

        public MongoDBConnectorTest()
        {
            // Spin up a MongoDB Docker container for testing
            _mongoDbContainer = new MongoDbBuilder()
                .WithImage("mongo:6.0") // specify version
                .Build();
        }

        // Runs before any test
        public async Task InitializeAsync()
        {
            await _mongoDbContainer.StartAsync();
        }

        // Runs after all tests
        public async Task DisposeAsync()
        {
            await _mongoDbContainer.DisposeAsync();
        }

        [Fact]
        public void Ping_ReturnsTrue_WhenMongoDbIsRunning()
        {
            // Arrange
            var connector = new MongoDBConnector(
                _mongoDbContainer.GetConnectionString(),
                "testdb"
            );

            // Act
            var result = connector.Ping();

            // Assert
            Assert.True(result);
        }
    }
}
