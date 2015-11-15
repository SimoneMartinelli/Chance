using Chance.Storage;

namespace Chance.Models
{
    public class Donation
    {
        public Donation(string code, decimal amount)
        {
            var beneficiary = StorageSingletons.BeneficiaryStore.get(code);
            Beneficiary = beneficiary;
            Amount = amount;
        }

        public decimal Amount { get; set; }
        public Beneficiary Beneficiary { get; set; }
    }
}