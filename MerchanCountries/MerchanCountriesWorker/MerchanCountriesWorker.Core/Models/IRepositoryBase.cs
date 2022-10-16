using System.Linq.Expressions;

namespace MerchanCountriesWorker.Core.Models
{
    public interface IRepositoryBase<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null);

        Task AddAsync(TEntity entity);
        
        Task Update(TEntity entity);
    }
}