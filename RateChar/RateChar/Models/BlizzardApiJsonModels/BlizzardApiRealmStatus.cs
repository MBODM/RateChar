using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBODM.RateChar
{
    public sealed class BlizzardApiRealmStatus
    {
        public string type { get; set; }
        public string population { get; set; }
        public bool queue { get; set; }
        public bool status { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string battlegroup { get; set; }
        public string locale { get; set; }
        public string timezone { get; set; }
        public List<string> connected_realms { get; set; }
    }
}
