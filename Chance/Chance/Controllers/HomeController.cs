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
            Session["amount"] = amount;
            Session["code"] = code;
            if(Session["customer"] == null)
            {
                return RedirectToAction("AddCard");
            }

            var busker = _store.get(code);
            if (busker == null)
            {
                return RedirectToAction("Index", "Home", new { notFound = code });
            }

            Session["busker"] = busker;

            return RedirectToAction("Thanks", "Home", new { code = code, amount = amount });
        }

        public ActionResult Thanks()
        {
            new SimplifyCommerceService().MakePayment(Session["customer"] as Customer, (decimal)Session["amount"]);
            return View();
        }

        [HttpGet]
        public ActionResult AddCard(string cardToken, string name)
        {
            if (string.IsNullOrWhiteSpace(cardToken))
            {
                return View();
            }

            Customer customer = _service.CreateCustomer(cardToken, name);

            Session["customer"] = customer;

            return RedirectToAction("Thanks", "Home", new { code=Session["code"], amount = Session["amount"]});
        }
    }
}