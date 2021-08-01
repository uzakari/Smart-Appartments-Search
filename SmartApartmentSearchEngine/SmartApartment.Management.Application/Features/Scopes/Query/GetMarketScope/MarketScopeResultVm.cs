using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApartment.Management.Application.Features.Scopes.Query.GetMarketScope
{
    public class StateAndCities
    {
        [JsonProperty("New York")]
        public List<string> NewYork { get; set; }
        public List<string> California { get; set; }
        public List<string> Illinois { get; set; }
        public List<string> Texas { get; set; }
        public List<string> Pennsylvania { get; set; }
        public List<string> Arizona { get; set; }
        public List<string> Florida { get; set; }
        public List<string> Indiana { get; set; }
        public List<string> Ohio { get; set; }

        [JsonProperty("North Carolina")]
        public List<string> NorthCarolina { get; set; }
        public List<string> Michigan { get; set; }
        public List<string> Tennessee { get; set; }
        public List<string> Massachusetts { get; set; }
        public List<string> Washington { get; set; }
        public List<string> Colorado { get; set; }

        [JsonProperty("District of Columbia")]
        public List<string> DistrictOfColumbia { get; set; }
        public List<string> Maryland { get; set; }
        public List<string> Kentucky { get; set; }
        public List<string> Oregon { get; set; }
        public List<string> Oklahoma { get; set; }
        public List<string> Wisconsin { get; set; }
        public List<string> Nevada { get; set; }

        [JsonProperty("New Mexico")]
        public List<string> NewMexico { get; set; }
        public List<string> Missouri { get; set; }
        public List<string> Virginia { get; set; }
        public List<string> Georgia { get; set; }
        public List<string> Nebraska { get; set; }
        public List<string> Minnesota { get; set; }
        public List<string> Kansas { get; set; }
        public List<string> Louisiana { get; set; }
        public List<string> Hawaii { get; set; }
        public List<string> Alaska { get; set; }

        [JsonProperty("New Jersey")]
        public List<string> NewJersey { get; set; }
        public List<string> Idaho { get; set; }
        public List<string> Alabama { get; set; }
        public List<string> Iowa { get; set; }
        public List<string> Arkansas { get; set; }
        public List<string> Utah { get; set; }

        [JsonProperty("Rhode Island")]
        public List<string> RhodeIsland { get; set; }
        public List<string> Mississippi { get; set; }

        [JsonProperty("South Dakota")]
        public List<string> SouthDakota { get; set; }
        public List<string> Connecticut { get; set; }

        [JsonProperty("South Carolina")]
        public List<string> SouthCarolina { get; set; }

        [JsonProperty("New Hampshire")]
        public List<string> NewHampshire { get; set; }

        [JsonProperty("North Dakota")]
        public List<string> NorthDakota { get; set; }
        public List<string> Montana { get; set; }
        public List<string> Delaware { get; set; }
        public List<string> Maine { get; set; }
        public List<string> Wyoming { get; set; }

        [JsonProperty("West Virginia")]
        public List<string> WestVirginia { get; set; }
        public List<string> Vermont { get; set; }


    }
}
