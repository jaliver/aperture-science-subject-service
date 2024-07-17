using System.Linq.Expressions;

namespace ApertureScienceSubjectService.Api.Cosmos
{
    public interface ICosmosRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> expression);
    }
}
