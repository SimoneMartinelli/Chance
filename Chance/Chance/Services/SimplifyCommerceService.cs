using System;
using SimplifyCommerce.Payments;

namespace Chance.Services
{
    public class SimplifyCommerceService
    {
        private PaymentsApi _api;

        public SimplifyCommerceService()
        {
            _api = new PaymentsApi();

            PaymentsApi.PublicApiKey = "sbpb_MDllNDA0OTctZWFkYS00YjU4LThjNjQtNzlkOWRkNmYyOTdl";
            PaymentsApi.PrivateApiKey = "0mGscVpVCqrGTNQD/yIYRei75eyUxPr+CRqv7ce9Zzx5YFFQL0ODSXAOkNtXTToq";
        }

        public void MakePayment(Customer customer, decimal amount)
        {
            Payment payment = new Payment();
            payment.Amount = (int) (amount * 100);
            payment.Currency = "GBP";
            payment.Description = "payment description";
            payment.Reference = "7a6ef6be31";
            payment.Customer = customer;

            payment = (Payment)_api.Create(payment);
        }

        public Customer CreateCustomer(string cardToken, string name)
        {
            PaymentsApi.PublicApiKey = "sbpb_MDllNDA0OTctZWFkYS00YjU4LThjNjQtNzlkOWRkNmYyOTdl";
            PaymentsApi.PrivateApiKey = "0mGscVpVCqrGTNQD/yIYRei75eyUxPr+CRqv7ce9Zzx5YFFQL0ODSXAOkNtXTToq";

            Customer customer = new Customer();
            customer.Email = "customer@mastercard.com";
            customer.Name = name;
            customer.Reference = "Ref1";
            customer.Token = cardToken;

            customer = (Customer)_api.Create(customer);

            return customer;
        }
    }
}