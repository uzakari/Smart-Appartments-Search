using Microsoft.Extensions.Logging;
using Nest;
using Newtonsoft.Json;
using SmartApartment.Management.Application.Features.Search.Query.GetSmartHomeSearch;
using SmartApartment.Management.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApartment.Management.Infrastructure.Helpers
{
    public static class SearchHelper
    {

        public static string GetFileToParse(string mainPath)
        {
            //var currentDirectory = Directory.GetCurrentDirectory();

            //var filePath = System.IO.Path.Combine(currentDirectory, "Uploads");
            var @file = Directory.GetFiles($"C:/Uploads/{mainPath}").Where(a => a.EndsWith(".json")).FirstOrDefault();


            return file;

        }

        public static T ParseDocument<T>(string fileContent)
        { 
             var contentToReturn = JsonConvert.DeserializeObject<T>(File.ReadAllText(fileContent));

            return contentToReturn;
        }

        public static BulkResponse LogIndexManyResponse(this BulkResponse indexManyResponse, ILogger _logger)
        {
            if (indexManyResponse.Errors)
            {
                foreach (var itemWithError in indexManyResponse.ItemsWithErrors)
                {
                    _logger.LogInformation($"Failed to index document {itemWithError.Id}: {itemWithError.Error}");
                }
            }

            return indexManyResponse;
        }

        public static void FormSearchResult(string searchQuery, string scope, ElasticClient client, out List<SearchResultContents> propertyResult, out List<SearchResultContents> managementResult, out IEnumerable<SearchResultContents> combineSearchResultResponse)
        {
            if (scope != "ALL")
            {
                var searchPropertyResponse = client.Search<PropertyContent>(s => s
                                 .From(0)
                                 .Query(q => q.Bool(b => b
                                      .Must(mu => mu
                                      .MultiMatch(m => m
                                             .Fields(f => f.Field(ff => ff.formerName)
                                             .Field(f => f.name))
                                             .Query(searchQuery)), mn => mn
                                              .Match(m => m
                                                  .Field(f => f.market)
                                                  .Query(scope))
                                             ))));

                propertyResult = searchPropertyResponse.Documents.Select(pro => new SearchResultContents
                {
                    name = pro.name,
                    market = pro.market,
                    isManagement = false
                }).ToList();

                var managementSearcResponse = client.Search<ManagementContent>(s => s
                                            .From(0)
                                            .Query(q => q
                                                    .Bool(b => b
                                                    .Must(mu => mu
                                                        .Match(m => m
                                                            .Field(f => f.name)
                                                            .Query(searchQuery)
                                                        ), mn => mn
                                                        .Match(m => m
                                                            .Field(f => f.market)
                                                            .Query(scope)
                                                         )))));

                managementResult = managementSearcResponse.Documents.Select(pro => new SearchResultContents
                {
                    name = pro.name,
                    market = pro.market,
                    isManagement = true
                }).ToList();
            }
            else
            {
                var searchPropertyResponse = client.Search<PropertyContent>(s => s
                 .From(0)
                 .Query(q => q.Bool(b => b
                      .Must(mu => mu
                      .MultiMatch(m => m
                             .Fields(f => f.Field(ff => ff.formerName)
                             .Field(f => f.name))
                             .Query(searchQuery))
                             ))));

                propertyResult = searchPropertyResponse.Documents.Select(pro => new SearchResultContents
                {
                    name = pro.name,
                    market = pro.market,
                    isManagement = false
                }).ToList();

                var managementSearcResponse = client.Search<ManagementContent>(s => s
                                            .From(0)
                                            .Query(q => q
                                                    .Bool(b => b
                                                    .Must(mu => mu
                                                        .Match(m => m
                                                            .Field(f => f.name)
                                                            .Query(searchQuery)
                                                        )))));

                managementResult = managementSearcResponse.Documents.Select(pro => new SearchResultContents
                {
                    name = pro.name,
                    market = pro.market,
                    isManagement = true
                }).ToList();

            }

            combineSearchResultResponse = propertyResult.Concat(managementResult).Take(25);
        }

    }
}
