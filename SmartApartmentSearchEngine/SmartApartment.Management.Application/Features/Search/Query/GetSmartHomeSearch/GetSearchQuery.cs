using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApartment.Management.Application.Features.Search.Query.GetSmartHomeSearch
{
    public class GetSearchQuery:IRequest<SearchResultVm>
    {
        public string searchQuery { get; set; }

        public string scope { get; set; }

    }
}
