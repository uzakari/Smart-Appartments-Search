using SmartApartment.Management.Application.Features.Scopes.Query.GetMarketScope;
using SmartApartment.Management.Application.Features.Search.Query.GetSmartHomeSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApartment.Management.Application.Contracts.Infrastructure
{
    public interface ISearchService
    {
        public Task<IEnumerable<SearchResultContents>> SearchSmartHomesAppartment(string searchQuery, string scope);
        public Task<List<SateAndCityVm>> GetMarketScope();
    }
}
