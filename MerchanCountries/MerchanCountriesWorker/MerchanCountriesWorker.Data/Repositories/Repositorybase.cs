using System.Linq.Expressions;
using MerchanCountriesWorker.Core.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace MerchanCountriesWorker.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
    {
        protected readonly IMongoDBContext _mongoContext;
        protected IMongoCollection<TEntity> _dbCollection;

        public RepositoryBase(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbCollection = _mongoContext.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async Task AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(typeof(TEntity).Name + " object is null");
            }
            await _dbCollection.InsertOneAsync(entity);
        }

        /// <summary>
        /// Get all datas of datasource
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> Get()
        {
            var query = await _dbCollection.FindAsync(Builders<TEntity>.Filter.Empty);
            return await query.ToListAsync();
        }

        public async Task Update(TEntity entity)
        {
            await _dbCollection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", entity.Id), entity);
        }
    }
}