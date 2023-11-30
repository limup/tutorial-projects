using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepositoryPattern.Core.Models;
using RepositoryPattern.Data.Repositories.Abstractions;
using RepositoryPattern.Domain;

namespace RepositoryPattern.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IRepositoryBase<Usuario> _repositoryBase;

        public UsuarioRepository(IRepositoryBase<Usuario> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task AddAsync(Usuario entity)
        {
            await _repositoryBase.AddAsync(entity);
        }
    }
}