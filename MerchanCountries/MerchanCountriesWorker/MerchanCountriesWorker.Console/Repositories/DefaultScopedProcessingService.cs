using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchanCountriesWorker.Core.Models;
using MerchanCountriesWorker.Data.Repositories.Abstractions;

namespace MerchanCountriesWorker.Console.Repositories
{
    public class DefaultScopedProcessingService : IScopedProcessingService
    {
        private int _executionCount;
        private readonly ILogger<DefaultScopedProcessingService> _logger;
        private readonly ICountryRepository _countryRepository;

        public DefaultScopedProcessingService(ILogger<DefaultScopedProcessingService> logger, ICountryRepository context) =>
        (_logger, _countryRepository)=(logger, context);

        public async Task DoWorkAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                var teste = await _countryRepository.Get();
                _logger.LogInformation("Data: ", teste.ToString());

                ++_executionCount;

                _logger.LogInformation(
                    "{ServiceName} working, execution count: {Count}",
                    nameof(DefaultScopedProcessingService),
                    _executionCount);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}