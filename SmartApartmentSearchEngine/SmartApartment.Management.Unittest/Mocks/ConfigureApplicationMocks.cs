using Moq;
using SmartApartment.Management.Application.Contracts.Infrastructure;
using SmartApartment.Management.Application.Features.Scopes.Query.GetMarketScope;
using SmartApartment.Management.Application.Features.Search.Query.GetSmartHomeSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApartment.Management.Unittest.Mocks
{
    public static class ConfigureApplicationMocks
    {
        public static Mock<ISearchService> GetSearchServiceProcessor()
        {

            var searchServiceRepository = new Mock<ISearchService>();


            //searchServiceRepository.Setup(repo => repo.SearchSmartHomesAppartment(It.IsAny<string>(), It.IsAny<string>()));

            //searchServiceRepository.Setup(repo => repo.GetMarketScope()).ReturnsAsync(
            //(List<SateAndCityVm> sateAndCityVms) =>
            //{
            //    return sateAndCityVms;
            //});
            return searchServiceRepository;
        }

    }
}
