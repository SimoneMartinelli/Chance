namespace Chance.Storage
{
    public static class StorageSingletons
    {
        private static BeneficiaryStore _beneficiaryStore;

        public static BeneficiaryStore BeneficiaryStore
        {
            get
            {
                if (_beneficiaryStore == null)
                {
                    _beneficiaryStore = new BeneficiaryStore();
                }
                return _beneficiaryStore;
            }
        }

        private static CustomerStore _customerStore;

        public static CustomerStore CustomerStore
        {
            get
            {
                if (_customerStore == null)
                {
                    _customerStore = new CustomerStore();
                }
                return _customerStore;
            }
        }
    }
}