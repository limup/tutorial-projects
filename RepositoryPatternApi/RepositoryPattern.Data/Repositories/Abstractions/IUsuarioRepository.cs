using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepositoryPattern.Domain;

namespace RepositoryPattern.Data.Repositories.Abstractions
{
    public interface IUsuarioRepository
    {
        Task AddAsync(Usuario entity);
    }
}