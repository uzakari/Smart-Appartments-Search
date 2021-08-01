using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApartment.Management.Application.Features.Scopes.Query.GetMarketScope
{
    public class SateAndCityVm
    {
        public string state { get; set; }

        public List<string> cities { get; set; }
    }
}
