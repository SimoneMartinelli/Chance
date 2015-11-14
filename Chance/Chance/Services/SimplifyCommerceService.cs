using SimplifyCommerce.Payments;

namespace Chance.Services
{
    public class SimplifyCommerceService
    {
        public void Test()
        {
            PaymentsApi.PublicApiKey = "sbpb_MDllNDA0OTctZWFkYS00YjU4LThjNjQtNzlkOWRkNmYyOTdl";
            PaymentsApi.PrivateApiKey = "0mGscVpVCqrGTNQD/yIYRei75eyUxPr+CRqv7ce9Zzx5YFFQL0ODSXAOkNtXTToq";

            PaymentsApi api = new PaymentsApi();

            CardToken cardToken = new CardToken();
            Card card = new Card();
            card.Cvc = "123";
            card.ExpMonth = 11;
            card.ExpYear = 19;
            card.Number = "5105105105105100";

            Customer customer = new Customer();
            customer.Card = card;
            customer.Email = "customer@mastercard.com";
            customer.Name = "Customer Customer";
            customer.Reference = "Ref1";

            customer = (Customer)api.Create(customer);

            Payment payment = new Payment();
            payment.Amount = 1000;
            payment.Currency = "USD";
            payment.Description = "payment description";
            payment.Reference = "7a6ef6be31";
            payment.Customer = customer;

            payment = (Payment)api.Create(payment);
        }
    }
}