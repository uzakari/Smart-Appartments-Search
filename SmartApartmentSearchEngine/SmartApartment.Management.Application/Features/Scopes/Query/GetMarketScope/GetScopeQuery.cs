using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApartment.Management.Application.Features.Scopes.Query.GetMarketScope
{
    public class GetScopeQuery: IRequest<IEnumerable<SateAndCityVm>>
    {

    }
}
