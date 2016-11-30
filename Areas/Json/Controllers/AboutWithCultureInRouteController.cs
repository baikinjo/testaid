using SecondAid.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace SecondAid.Areas.Json.Controllers
{
    [ServiceFilter(typeof(LanguageActionFilter))]
    //[Produces("application/json")]
    [Route("json/{culture}/[controller]")]
    public class AboutWithCultureInRouteController : Controller
    {
        // http://localhost:5000/json/api/it-CH/AboutWithCultureInRoute

        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;


        public AboutWithCultureInRouteController(IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _sharedLocalizer = sharedLocalizer;
        }

        [HttpGet]
        public string Get()
        {
            return _sharedLocalizer["Name"];
        }
    }
}
