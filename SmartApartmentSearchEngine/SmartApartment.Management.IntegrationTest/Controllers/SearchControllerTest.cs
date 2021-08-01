using Newtonsoft.Json;
using SmartApartment.Management.Api;
using SmartApartment.Management.Application.Features.Scopes.Query.GetMarketScope;
using SmartApartment.Management.Application.Features.Search.Query.GetSmartHomeSearch;
using SmartApartment.Management.IntegrationTest.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartApartment.Management.IntegrationTest.Controllers
{
    public class SearchControllerTest: IClassFixture<ApplicationFactory<Startup>>
    {
        private readonly ApplicationFactory<Startup> _factory;

        public SearchControllerTest(ApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task CheckHealtStateOfApi()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/health/live");

            response.EnsureSuccessStatusCode();

            Assert.Equal(200, (int)response.StatusCode);
        }

        [Fact]
        public async Task GetMarketScope()
        {
            var clientfactory = _factory.GetAnonymousClient();

            var result = new List<StateAndCities>();

            var response = await clientfactory.GetAsync("/api/Search/market");

            response.EnsureSuccessStatusCode();

            Assert.Equal(200, (int)response.StatusCode);

            Assert.IsType<List<StateAndCities>>(result);
        }

        [Fact]
        public async Task SearchForAppartment()
        {
            var clientfactory = _factory.GetAnonymousClient();

            var searchquery = "Idlewylde";

            var scope = "Atlanta";

            var response = await clientfactory.GetAsync($"/api/search?searchQuery={searchquery}&scope={scope}");
            response.EnsureSuccessStatusCode();

            Assert.Equal(200, (int)response.StatusCode);

            var searchContent = await response.Content.ReadAsStringAsync();

            var returnSearchContent =  JsonConvert.DeserializeObject<SearchResultVm>(searchContent);

            var searchResultContent = returnSearchContent.data;

            Assert.IsType<SearchResultVm>(returnSearchContent);

            Assert.Single(searchResultContent);
        }
    }
}
