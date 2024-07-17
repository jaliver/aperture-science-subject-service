using ApertureScienceSubjectService.Api.Extensions;
using Microsoft.Azure.Cosmos;

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
            var container = await GetContainer();

            var itemResponse = await container.CreateItemAsync(entity);

            return itemResponse;
        }

        private async Task<Container> GetContainer()
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

            var container = await database.Database.CreateContainerIfNotExistsAsync(
                id: _cosmosAttribute.CollectionName,
                partitionKeyPath: "/id");

            return container;
        }
    }
}
