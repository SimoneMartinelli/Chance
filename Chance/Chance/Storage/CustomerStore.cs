using System;
using System.Collections.Generic;

namespace Chance.Storage
{
    public class CustomerStore : IStore<CustomerWrapper>
    {
        private Dictionary<int, CustomerWrapper> _customers;
        private Dictionary<string, int> _codes;
        private int _available;

        public CustomerStore()
        {
            _customers = new Dictionary<int, CustomerWrapper>();
            _codes = new Dictionary<string, int>();

            _available = 1;
        }

        public CustomerWrapper get(int id)
        {
            if (_customers.ContainsKey(id))
            {
                return _customers[id];
            }

            return null;
        }

        public CustomerWrapper get(string code)
        {
            if (_codes.ContainsKey(code))
            {
                CustomerWrapper busker;
                _customers.TryGetValue(_codes[code], out busker);
                return busker;
            }

            return null;
        }

        public bool put(CustomerWrapper storable)
        {
            _customers[_available] = storable;

            var code = Guid.NewGuid().ToString("N").Substring(0, 4);

            _codes[code] = _available;

            _available++;

            return true;
        }
    }
}