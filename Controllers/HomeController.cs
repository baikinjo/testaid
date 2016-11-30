using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SecondAid.Resources;
using Microsoft.AspNetCore.Mvc.Localization;

namespace SecondAid.Controllers
{
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = _controllerLocalizer["Your application description page."];

            return View();
        }

        // http://healthscope.azurewebsites.net/home/contact?culture=it-CH
        public IActionResult Contact()
        {
            ViewData["Message"] = _controllerLocalizer["Hello"];

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
