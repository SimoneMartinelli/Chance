using SimplifyCommerce.Payments;

namespace Chance.Storage
{
    public class CustomerWrapper : IStorable
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }

        public CustomerWrapper(Customer customer)
        {
            Customer = customer;
        }
    }
}