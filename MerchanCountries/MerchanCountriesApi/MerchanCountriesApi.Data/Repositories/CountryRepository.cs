using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchanCountriesApi.Core.Models;
using MerchanCountriesApi.Data.Repositories.Abstractions;
using MerchanCountriesApi.Domain;

namespace MerchanCountriesApi.Data.Repositories
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(IMongoDBContext context) : base(context)
        {
        }
    }
}