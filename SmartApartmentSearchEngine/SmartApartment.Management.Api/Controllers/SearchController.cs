using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartApartment.Management.Application.Features.Scopes.Query.GetMarketScope;
using SmartApartment.Management.Application.Features.Search.Query.GetSmartHomeSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartApartment.Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : Controller
    {
        private readonly IMediator _mediator;

        private readonly ILogger<SearchController> _logger;

        public SearchController(IMediator mediator, ILogger<SearchController> logger)
        {
            _mediator = mediator;

            _logger = logger;
        }

        [HttpGet("market")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<StateAndCities>> GetMarketScope()
        {
            _logger.LogInformation($"About to call {nameof(GetMarketScope)} handler");

            var marketScopeQuery = new GetScopeQuery();

            var marketScope = await _mediator.Send(marketScopeQuery);

            return Ok(marketScope);
        }


        [HttpGet]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<SearchResultVm>> GetAppartmentSearchResult(string searchQuery, string scope)
        {
            var getSearch = new GetSearchQuery{ searchQuery = searchQuery, scope = scope };
            var returnSearchResult = await _mediator.Send(getSearch);

            return Ok(returnSearchResult);
        }



    }
}
