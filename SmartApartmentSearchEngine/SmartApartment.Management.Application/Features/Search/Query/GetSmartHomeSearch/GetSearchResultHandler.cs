using MediatR;
using SmartApartment.Management.Application.Contracts.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartApartment.Management.Application.Features.Search.Query.GetSmartHomeSearch
{
    class GetSearchResultHandler : IRequestHandler<GetSearchQuery, SearchResultVm>
    {
        private readonly ISearchService _searchService;

        public GetSearchResultHandler(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public async Task<SearchResultVm> Handle(GetSearchQuery request, CancellationToken cancellationToken)
        {
            var searchResultResponse = new SearchResultVm();

            var validator = new GetSearchResultValidator();

            var validationResult = validator.Validate(request);

            if (validationResult.Errors.Count > 0)
            {
                searchResultResponse.Success = false;

                foreach (var item in validationResult.Errors)
                {
                    searchResultResponse.ValidationErrors.Add(item.ErrorMessage);
                }
            }
            else
            {
                searchResultResponse.data = await _searchService.SearchSmartHomesAppartment(request.searchQuery, request.scope);
            }

            return searchResultResponse;
        }
    }
}
