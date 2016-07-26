using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MBODM.RateChar
{
    public class ShowController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Character(string realm, string character)
        {
            if (string.IsNullOrEmpty(realm) || string.IsNullOrEmpty(character))
            {
                return RedirectToAction("Character", "Find");
            }

            var model = new ShowViewModel();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var url = $"https://eu.api.battle.net/wow/character/{realm}/{character}?locale=de_DE&apikey=k6yde3735ebkaajdkyg34a64g3denaj9";

                    var response = await httpClient.GetAsync(url).ConfigureAwait(false);

                    var jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        model.Profile = (new JavaScriptSerializer()).Deserialize<BlizzardApiCharacterProfile>(jsonString);
                        model.Realm = model.Profile.realm;
                        model.Character = model.Profile.name;
                    }
                    else
                    {
                        if (response.StatusCode == HttpStatusCode.NotFound && jsonString.ToLower().Contains("realm not found"))
                        {
                            model.NotFound = "realm";
                        }
                        else if (response.StatusCode == HttpStatusCode.NotFound && jsonString.ToLower().Contains("character not found"))
                        {
                            model.NotFound = "character";
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                }
            }
            catch
            {
                model.HasError = true;
                model.ErrorText = "Could not receive character profile from Blizzard web api.";
            }

            return View(model);
        }
    }
}
