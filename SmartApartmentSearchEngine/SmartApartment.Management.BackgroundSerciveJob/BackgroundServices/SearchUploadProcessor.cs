using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SmartApartment.Management.Application.Contracts.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartApartment.Management.BackgroundSerciveJob
{
    public class SearchUploadProcessor : BackgroundService
    {
        private readonly ILogger<SearchUploadProcessor> _logger;
        private readonly IUploadService _uploderService;

        public SearchUploadProcessor(ILogger<SearchUploadProcessor> logger, IUploadService uploderService)
        {
            _logger = logger;
            _uploderService = uploderService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                await  _uploderService.ProcessDocumentIndexer();

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
