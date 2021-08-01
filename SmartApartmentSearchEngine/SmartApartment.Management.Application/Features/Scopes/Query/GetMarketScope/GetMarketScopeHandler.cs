using MediatR;
using SmartApartment.Management.Application.Contracts.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartApartment.Management.Application.Features.Scopes.Query.GetMarketScope
{
    public class GetMarketScopeHandler : IRequestHandler<GetScopeQuery, IEnumerable<SateAndCityVm>>
    {
        private readonly ISearchService _searchService;

        public GetMarketScopeHandler(ISearchService searchService)
        {
            _searchService = searchService;
        }
        public async Task<IEnumerable<SateAndCityVm>> Handle(GetScopeQuery request, CancellationToken cancellationToken)
        {
            var marketScopeResponse = await _searchService.GetMarketScope();

            return marketScopeResponse;
            
        }
    }
}
