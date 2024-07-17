using System.Linq.Expressions;

namespace ApertureScienceSubjectService.Api.Cosmos
{
    public interface ICosmosAdapter<T> where T : BaseEntity
    {
        Task<T> CreateItemAsync(T entity);
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> expression);
    }
}
