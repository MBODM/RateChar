using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MBODM.RateChar
{
    public sealed class ShowViewModel : BaseViewModel
    {
        public string NotFound { get; set; }

        public string Realm { get; set; }

        public string Character { get; set; }

        public BlizzardApiCharacterProfile Profile { get; set; }

        public string Avatar
        {
            get
            {
                if ((Profile != null) && (Profile.thumbnail != null))
                {
                    return "http://render-api-eu.worldofwarcraft.com/static-render/eu/" + Profile.thumbnail;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
