using Autofac;
using Microsoft.AspNetCore.Mvc;
using PropertyRenting.Web.Models;
using PropertyRenting.Web.Models.Home;
using System.Diagnostics;

namespace PropertyRenting.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILifetimeScope _scope;

        public HomeController(ILogger<HomeController> logger, ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ContactUs()
        {
            var model = _scope.Resolve<ContactModel>();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ContactUs(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                model.Resolve(_scope);
                await model.StoreMessage();
            }
            return View(model);
        }
    }
}