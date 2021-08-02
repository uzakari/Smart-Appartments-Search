using Microsoft.Extensions.Logging;
using Nest;
using SmartApartment.Management.Application.Contracts.Infrastructure;
using SmartApartment.Management.Infrastructure.Helpers;
using SmartApartment.Management.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApartment.Management.Infrastructure.Repositories
{
    public class UploadServiceRepo : IUploadService
    {
        private readonly ILogger<UploadServiceRepo> _logger;

        public UploadServiceRepo(ILogger<UploadServiceRepo> logger)
        {
            _logger = logger;
        }
        public async Task ProcessDocumentIndexer()
        {
            var settings = new ConnectionSettings(new Uri("http://127.0.0.1:9200")).DefaultIndex("apartments");

            var client = new ElasticClient(settings);

            var management = SearchHelper.GetFileToParse("management");

            var parseMangements = SearchHelper.ParseDocument<IEnumerable<ManagementRoot>>(management);

            var managementindexResponse = new BulkResponse();

            var managementContentCollection = new List<ManagementContent>();
            foreach (var item in parseMangements)
            {
                managementContentCollection.Add(item.mgmt);
            }

            managementindexResponse = await client.IndexManyAsync(managementContentCollection);
            managementindexResponse.LogIndexManyResponse(_logger);


            var property = SearchHelper.GetFileToParse("propertise");

            var parseProperties = SearchHelper.ParseDocument<IEnumerable<PropertyRoot>>(property);
            var propertiseindexResponse = new BulkResponse();
            var propertyContentCollection = new List<PropertyContent>();

            foreach (var item in parseProperties)
            {
                propertyContentCollection.Add(item.property);
            }
            propertiseindexResponse = await client.IndexManyAsync(propertyContentCollection);

            propertiseindexResponse.LogIndexManyResponse(_logger);




        }


    }
}
