using Chance.Models;
using Chance.Services;
using Chance.Storage;
using SimplifyCommerce.Payments;
using System.Web.Mvc;

namespace Chance.Controllers
{
    public class HomeController : Controller
    {
        private SimplifyCommerceService _service;

        public HomeController()
        {
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
            var beneficiary = StorageSingletons.BeneficiaryStore.get(code);
            Session["beneficiary"] = beneficiary;

            if (beneficiary == null)
            {
                return RedirectToAction("Index", "Home", new { notFound = code });
            }

            if (Session["customer"] == null)
            {
                return RedirectToAction("AddCard");
            }

            return RedirectToAction("Thanks", "Home", new { code = code, amount = amount });
        }

        public ActionResult Thanks(string code, decimal amount)
        {
            new SimplifyCommerceService().MakePayment(Session["customer"] as Customer, (decimal)Session["amount"],  Session["beneficiary"] as Beneficiary);

            var donation = new Donation(code, amount);

            return View(donation);
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

            return RedirectToAction("Thanks", "Home", new { code = Session["code"], amount = Session["amount"] });
        }

        [HttpGet]
        public ActionResult Beneficiary(int id)
        {
            var beneficiary = StorageSingletons.BeneficiaryStore.get(id);

            if (id == 0 || beneficiary == null)
            {
                return new HttpNotFoundResult();
            }

            return View(beneficiary);
        }
    }
}