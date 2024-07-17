using ApertureScienceSubjectService.Api.Extensions;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Linq.Expressions;

namespace ApertureScienceSubjectService.Api.Cosmos
{
    public class CosmosAdapter<T> : ICosmosAdapter<T> where T : BaseEntity
    {
        private readonly IConfiguration _config;
        private readonly CosmosEntityAttribute _cosmosAttribute;

        public CosmosAdapter(IConfiguration config)
        {
            ArgumentNullException.ThrowIfNull(config, nameof(config));

            _config = config;
            _cosmosAttribute = typeof(T).GetCosmosEntityAttribute();
        }

        public async Task<T> CreateItemAsync(T entity)
        {
            var container = await GetContainerAsync();

            var itemResponse = await container.CreateItemAsync(entity);

            return itemResponse;
        }

        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            var container = await GetContainerAsync();

            var queryable = container.GetItemLinqQueryable<T>();
            var iterator = queryable.Where(expression).ToFeedIterator();
            var feedResponse = await iterator.ReadNextAsync();

            return feedResponse.ToList();
        }

        private async Task<Container> GetContainerAsync()
        {
            var endpoint = _config["Cosmos:Account.Endpoint"];
            var key = _config["Cosmos:Primary.Key"];
            var databaseName = _config["Cosmos:Database.Name"];

            var client = new CosmosClient(
                accountEndpoint: endpoint,
                authKeyOrResourceToken: key);

            var database = await client.CreateDatabaseIfNotExistsAsync(
                id: databaseName,
                throughput: 400);

            var containerProperties = new ContainerProperties()
            {
                Id = _cosmosAttribute.CollectionName,
                PartitionKeyPath = "/id",
                // Expire all documents after 180 days
                DefaultTimeToLive = 180 * 60 * 60 * 24
            };

            var container = await database.Database.CreateContainerIfNotExistsAsync(containerProperties);

            return container;
        }
    }
}
