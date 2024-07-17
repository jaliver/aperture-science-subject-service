namespace ApertureScienceSubjectService.Api.Cosmos
{
    public class CosmosRepository<T> : ICosmosRepository<T> where T : BaseEntity
    {
        private readonly ICosmosAdapter<T> _cosmosAdapter;

        public CosmosRepository(ICosmosAdapter<T> cosmosAdapter)
        {
            ArgumentNullException.ThrowIfNull(cosmosAdapter, nameof(cosmosAdapter));
            
            _cosmosAdapter = cosmosAdapter;
        }

        public async Task<T> AddAsync(T entity)
        {
            return await _cosmosAdapter.CreateItemAsync(entity);
        }
    }
}
