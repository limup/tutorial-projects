using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MerchanCountriesWorker.Core.Models;
using MerchanCountriesWorker.Data.Repositories.Abstractions;
using MerchanCountriesWorker.Domain;
using Microsoft.Extensions.Http;

namespace MerchanCountriesWorker.Console.Repositories
{
    public class DefaultScopedProcessingService : IScopedProcessingService
    {
        private readonly ILogger<DefaultScopedProcessingService> _logger;
        private readonly ICountryRepository _countryRepository;
        private readonly IHttpClientFactory _httpClientFactory;
        public IEnumerable<Country>? _country { get; set; }

        public DefaultScopedProcessingService(ILogger<DefaultScopedProcessingService> logger, ICountryRepository context, IHttpClientFactory httpClientFactory) =>
        (_logger, _countryRepository,_httpClientFactory) = (logger, context, httpClientFactory);

        public async Task DoWorkAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    //Here, we request from programs to get base API
                    var httpClient = _httpClientFactory.CreateClient("RestCountries");

                    var httpResponseMessage = await httpClient.GetAsync("all");

                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        using var contentStream =
                            await httpResponseMessage.Content.ReadAsStreamAsync();

                        _country = await JsonSerializer.DeserializeAsync
                         <IEnumerable<Country>> (contentStream);

                         var Brasil = _country.Where(x=> x.Name.Common.Equals("Brazil")).FirstOrDefault();
                        
                        _logger.LogInformation("Conection API Success.");
                    }

                    var teste = await _countryRepository.Get();
                    _logger.LogInformation("Data: ", teste.ToString());

                    await Task.Delay(1000, stoppingToken);
                }
                catch (System.Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw ex;
                }
                
            }
        }
    }
}