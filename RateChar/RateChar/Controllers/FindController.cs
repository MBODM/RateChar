using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MBODM.RateChar
{
    public class FindController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Character()
        {
            var model = new FindViewModel();

            await AddRealmsToModel(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<ActionResult> Character(FindViewModel model)
        {
            if (ModelState.IsValid)
            {
                var realm = model.Realm.First().ToString().ToUpper() + string.Join(string.Empty, model.Realm.Skip(1));
                var character = model.Character.First().ToString().ToUpper() + string.Join(string.Empty, model.Character.Skip(1));

                return Redirect($"Show/Character/{realm}/{character}");
            }
            else
            {
                await AddRealmsToModel(model);

                return View(model);
            }
        }

        private async Task AddRealmsToModel(FindViewModel model)
        {
            try
            {
                var url = "https://eu.api.battle.net/wow/realm/status?locale=de_DE&apikey=k6yde3735ebkaajdkyg34a64g3denaj9";

                using (var httpClient = new HttpClient())
                {
                    var jsonString = await httpClient.GetStringAsync(url).ConfigureAwait(false);

                    jsonString = jsonString.Split(new string[] { "\"realms\":" }, StringSplitOptions.RemoveEmptyEntries).Last().TrimEnd('}');

                    model.Realms = (new JavaScriptSerializer()).Deserialize<List<BlizzardApiRealmStatus>>(jsonString);
                }
            }
            catch
            {
                model.HasError = true;
                model.ErrorText = "Could not receive realm list from Blizzard api.";
            }
        }
    }
}
