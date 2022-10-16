using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchanCountriesWorker.Core.Models;
using MerchanCountriesWorker.Data.Repositories.Abstractions;
using MerchanCountriesWorker.Domain;

namespace MerchanCountriesWorker.Data.Repositories
{
    public class CurrencyRepository : RepositoryBase<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(IMongoDBContext context) : base(context)
        {
        }
    }
}