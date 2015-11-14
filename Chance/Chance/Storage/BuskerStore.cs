using System;
using System.Collections.Generic;

namespace Chance.Storage
{
    public class BuskerStore : IStore<Busker>
    {
        private Dictionary<int, Busker> _buskers;
        private Dictionary<string, int> _codes;
        private int _available;

        public BuskerStore()
        {
            _buskers = new Dictionary<int, Busker>()
            {
                { 1, new Busker("Dan Cohen") }
            };
            _codes = new Dictionary<string, int>()
            {
                { "abc", 1 }
            };

            _available = 2;
        }

        public Busker get(int id)
        {
            if (_buskers.ContainsKey(id))
            {
                return _buskers[id];
            }

            return null;
        }

        public Busker get(string code)
        {
            if (_codes.ContainsKey(code))
            {
                Busker busker;
                _buskers.TryGetValue(_codes[code], out busker);
                return busker;
            }

            return null;
        }

        public bool put(Busker storable)
        {
            _buskers[_available] = storable;

            var code = Guid.NewGuid().ToString("N").Substring(0, 4);

            _codes[code] = _available;

            _available++;

            return true;
        }
    }
}