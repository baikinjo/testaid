using SecondAid.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;

namespace SecondAid.Areas.Apis.Controllers
{
    [Area("Json")]
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;
        private readonly IStringLocalizer<HomeController> _controllerLocalizer;
        private readonly IHtmlLocalizer _htmlLocalizer;

        public HomeController(IStringLocalizer<SharedResource> sharedLocalizer,
            IStringLocalizer<HomeController> controllerLocalizer,
            IHtmlLocalizer<HomeController> htmlLocalizer)
        {
            _sharedLocalizer = sharedLocalizer;
            _controllerLocalizer = controllerLocalizer;
            _htmlLocalizer = htmlLocalizer;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewData["Message"] = _controllerLocalizer["Your 'Json' area Index page."];

            return View();
        }
    }
}
