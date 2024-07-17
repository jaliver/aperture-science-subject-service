namespace ApertureScienceSubjectService.Api.Cosmos
{
    public interface ICosmosRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
    }
}
