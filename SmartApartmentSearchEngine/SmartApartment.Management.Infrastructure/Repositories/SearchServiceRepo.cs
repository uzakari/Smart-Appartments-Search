using Microsoft.Extensions.Logging;
using Nest;
using SmartApartment.Management.Application.Contracts.Infrastructure;
using SmartApartment.Management.Application.Features.Scopes.Query.GetMarketScope;
using SmartApartment.Management.Application.Features.Search.Query.GetSmartHomeSearch;
using SmartApartment.Management.Infrastructure.Helpers;
using SmartApartment.Management.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SmartApartment.Management.Infrastructure.Repositories
{
    public class SearchServiceRepo : ISearchService
    {
        private readonly ILogger<SearchServiceRepo> _logger;

        public SearchServiceRepo(ILogger<SearchServiceRepo> logger)
        {
            _logger = logger;
        }
        public Task<List<SateAndCityVm>> GetMarketScope()
        {
            var listStateAndCity = new List<SateAndCityVm>();


            try
            {
                var marketScopes = SearchHelper.GetFileToParse("states");

                _logger.LogInformation("About to parse states file");

                var parseMarketScope = SearchHelper.ParseDocument<StateAndCities>(marketScopes);
                Type myType = parseMarketScope.GetType();
                IList<dynamic> states = new List<dynamic>(myType.GetProperties());

                foreach (var state in states)
                {
                    object cities = state.GetValue(parseMarketScope, null);

                    listStateAndCity.Add( new SateAndCityVm
                    {
                        state = state.Name,
                        cities = (List<string>)cities
                    });
                }

            }
            catch (Exception ex)
            {
                var methodName = nameof(GetMarketScope);
                _logger.LogError("An Error Occured while {GetMarketScope} --- {ex}", methodName, ex);
            }
  

            return Task.FromResult(listStateAndCity);
        }

        public Task<IEnumerable<SearchResultContents>> SearchSmartHomesAppartment(string searchQuery, string scope)
        {
            _logger.LogInformation("About to search for appartments with {searchQuery} -- in a scome of {scope}", searchQuery, scope);

            IEnumerable<SearchResultContents> combineSearchResultResponse = new List<SearchResultContents>();

            try
            {
                var settings = new ConnectionSettings(new Uri("http://127.0.0.1:9200")).DefaultIndex("apartments");

                var client = new ElasticClient(settings);
                var propertyResult = new List<SearchResultContents>();
                var managementResult = new List<SearchResultContents>();

                SearchHelper.FormSearchResult(searchQuery, scope, client, out propertyResult, out managementResult, out combineSearchResultResponse);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Unable To Perform Search {ex}", ex);
            }
            return Task.FromResult(combineSearchResultResponse);

        }

    }
}
