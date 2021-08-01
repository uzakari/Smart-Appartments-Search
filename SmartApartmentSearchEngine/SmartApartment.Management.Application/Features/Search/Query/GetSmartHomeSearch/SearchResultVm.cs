using SmartApartment.Management.Application.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApartment.Management.Application.Features.Search.Query.GetSmartHomeSearch
{
    public class SearchResultVm
    {
        public IEnumerable<SearchResultContents> data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; } = new List<string>();
    }
}
