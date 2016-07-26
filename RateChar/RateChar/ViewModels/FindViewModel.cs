using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MBODM.RateChar
{
    public sealed class FindViewModel : BaseViewModel
    {
        public IEnumerable<BlizzardApiRealmStatus> Realms { get; set; }

        [Required(ErrorMessage = "Realm is required.")]
        public string Realm { get; set; }

        [Required(ErrorMessage = "Character is required.")]
        public string Character { get; set; }
    }
}
