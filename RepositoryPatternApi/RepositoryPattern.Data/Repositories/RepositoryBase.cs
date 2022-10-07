using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RepositoryPattern.Core.Models;
using RepositoryPattern.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace RepositoryPattern.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
    {
        public readonly DbSet<TEntity> _DbSet;
        public readonly AppDbContext _AppDbContext;

        public RepositoryBase(AppDbContext appContext)
        {
            _DbSet = appContext.Set<TEntity>();
            _AppDbContext = appContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _DbSet.AddAsync(entity);
            await _AppDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _DbSet.Remove(entity);
            await _AppDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = _DbSet.AsQueryable();

            if (filter != null)
                query = query
                    .Where(filter)
                    .AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _DbSet.FindAsync(id);
        }

        public async Task Update(TEntity entity)
        {
            _DbSet.Update(entity);
            await _AppDbContext.SaveChangesAsync();
        }
    }
}