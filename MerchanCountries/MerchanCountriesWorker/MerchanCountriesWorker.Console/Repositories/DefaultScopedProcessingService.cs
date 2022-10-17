using System.Text.Json;
using MerchanCountriesWorker.Core.Models;
using MerchanCountriesWorker.Data.Repositories.Abstractions;
using MerchanCountriesWorker.Domain;

namespace MerchanCountriesWorker.Console.Repositories
{
    public class DefaultScopedProcessingService : IScopedProcessingService
    {
        private readonly ILogger<DefaultScopedProcessingService> _logger;
        private readonly ICountryRepository _countryRepository;
        private readonly IHttpClientFactory _httpClientFactory;

        public IEnumerable<Country>? _country { get; set; }

        public DefaultScopedProcessingService(
            ILogger<DefaultScopedProcessingService> logger,
            ICountryRepository context,
            IHttpClientFactory httpClientFactory) =>
        (_logger, _countryRepository, _httpClientFactory) = (logger, context, httpClientFactory);

        public async Task DoWorkAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {                
                try
                {
                    //Here, we request from programs to get base API
                    var countries = await DoHttpClient(_httpClientFactory.CreateClient("RestCountries"));
                    
                    await _countryRepository.AddManyAsync(countries);

                    //Here we can define time to repeat.
                    await Task.Delay(60000, stoppingToken);
                }
                catch (System.Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw ex;
                }
                
            }
        }

        public async Task<IEnumerable<Country>?> DoHttpClient(HttpClient httpClient)
        {
            var httpResponseMessage = await httpClient.GetAsync("all");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                return await JsonSerializer.DeserializeAsync
                 <IEnumerable<Country>>(contentStream);
            }else{
                return null;
            }
        }
    }
}