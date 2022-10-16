using System.Linq.Expressions;

namespace MerchanCountriesWorker.Core.Models
{
    public interface IRepositoryBase<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> Get();

        Task AddAsync(TEntity entity);
        
        Task Update(TEntity entity);
    }
}