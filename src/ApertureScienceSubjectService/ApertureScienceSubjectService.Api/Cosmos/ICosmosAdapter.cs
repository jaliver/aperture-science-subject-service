namespace ApertureScienceSubjectService.Api.Cosmos
{
    public interface ICosmosAdapter<T> where T : BaseEntity
    {
        Task<T> CreateItemAsync(T entity);
    }
}
