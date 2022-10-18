using System.Linq.Expressions;

namespace RepositoryPattern.Core.Models
{
    public interface IRepositoryBase<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetByIdAsync(Guid id);
        Task AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task Update(TEntity entity);
    }
}