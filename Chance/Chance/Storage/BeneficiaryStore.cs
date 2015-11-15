using System;
using System.Collections.Generic;

namespace Chance.Storage
{
    public class BeneficiaryStore : IStore<Beneficiary>
    {
        private Dictionary<int, Beneficiary> _beneficiary;
        private Dictionary<string, int> _codes;
        private int _available;

        public BeneficiaryStore()
        {
            _beneficiary = new Dictionary<int, Beneficiary>()
            {
                { 1, new Beneficiary("The British Heart Foundation", 1, "bhf", "/Assets/bhf.png", "Our vision is a world in which people do not die prematurely or suffer from heart disease.\n Thanks to you, we’ve made great progress. With you, we’ll beat it.") },
                { 2, new Beneficiary("Cancer Research UK", 2, "cruk", "/Assets/cruk.png", "Every step we make towards beating cancer relies on every pound donated.") }
            };
            _codes = new Dictionary<string, int>()
            {
                { "bhf", 1 },
                {"cruk", 2 }
            };

            _available = 3;
        }

        public Beneficiary get(int id)
        {
            if (_beneficiary.ContainsKey(id))
            {
                return _beneficiary[id];
            }

            return null;
        }

        public Beneficiary get(string code)
        {
            if (_codes.ContainsKey(code))
            {
                Beneficiary beneficiary;
                _beneficiary.TryGetValue(_codes[code], out beneficiary);
                return beneficiary;
            }

            return null;
        }

        public bool put(Beneficiary storable)
        {
            _beneficiary[_available] = storable;

            var code = Guid.NewGuid().ToString("N").Substring(0, 4);

            _codes[code] = _available;

            _available++;

            return true;
        }
    }
}