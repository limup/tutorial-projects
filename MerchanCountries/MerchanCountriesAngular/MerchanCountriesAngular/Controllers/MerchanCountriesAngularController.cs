using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchanCountriesAngular.Data.Repositories.Abstractions;
using MerchanCountriesAngular.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MerchanCountriesAngular.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MerchanCountriesAngularController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public MerchanCountriesAngularController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Country>> Get()
        {
           return await _countryRepository.GetAsync();
        }
    }
}