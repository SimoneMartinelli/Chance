using Chance.Services;
using Chance.Storage;
using SimplifyCommerce.Payments;
using System.Web.Mvc;

namespace Chance.Controllers
{
    public class HomeController : Controller
    {
        private BuskerStore _store;
        private CustomerStore _customerStore;
        private SimplifyCommerceService _service;

        public HomeController()
        {
            _store = new BuskerStore();
            _customerStore = new CustomerStore();
            _service = new SimplifyCommerceService();
        }

        [HttpGet]
        public ActionResult Index(string cardToken, string name)
        {
            if (string.IsNullOrWhiteSpace(cardToken))
            {
                return View();
            }
            Customer customer = _service.CreateCustomer(cardToken, name);

            Session.Add("customer", customer);
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

            new SimplifyCommerceService().MakePayment(Session["customer"] as Customer, amount);

            return RedirectToAction("Thanks", "Home", new { code = code, amount = amount });
        }

        public ActionResult Thanks()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddCard()
        {
            return View();
        }
    }
}