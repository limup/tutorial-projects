using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepositoryPattern.Data.Context;
using RepositoryPattern.Data.Repositories.Abstractions;
using RepositoryPattern.Domain;

namespace RepositoryPattern.Data.Repositories
{
    public class CarroRepository : RepositoryBase<Carro>, ICarroRepository
    {
        public CarroRepository(AppDbContext appContext) : base(appContext){
            
        }
        
    }
}