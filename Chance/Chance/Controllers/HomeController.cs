using Chance.Storage;
using System.Web.Mvc;

namespace Chance.Controllers
{
    public class HomeController : Controller
    {
        private BuskerStore _store;

        public HomeController()
        {
            _store = new BuskerStore();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(decimal amount, string code)
        {
            var busker = _store.get(code);
            if (busker == null)
            {
                return RedirectToAction("Index", "Home", new { notFound = code });
            }

            new Services.SimplifyCommerceService().Test();

            return RedirectToAction("Thanks", "Home", new { code = code, amount = amount });
        }

        public ActionResult Thanks()
        {
            return View();
        }
    }
}