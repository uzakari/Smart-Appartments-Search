using Moq;
using Shouldly;
using SmartApartment.Management.Application.Contracts.Infrastructure;
using SmartApartment.Management.Application.Features.Scopes.Query.GetMarketScope;
using SmartApartment.Management.Application.Features.Search.Query.GetSmartHomeSearch;
using SmartApartment.Management.Unittest.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SmartApartment.Management.Unittest.Features.Search.Queries.GetSmartHomeSearch
{
    public class GetSmartSearchHandlerTest
    {
        private readonly Mock<ISearchService> _mockSearchService;


        public GetSmartSearchHandlerTest()
        {
            _mockSearchService = ConfigureApplicationMocks.GetSearchServiceProcessor();
        }

        [Fact]
        public async Task GetSearchResultTest()
        {
            var handler = new GetSearchResultHandler(_mockSearchService.Object);

            var result = await handler.Handle(new GetSearchQuery(), CancellationToken.None);

            Assert.IsType<SearchResultVm>(result);
        }

    }
}
