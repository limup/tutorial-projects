using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchanCountriesWorker.Core.Models;

namespace MerchanCountriesWorker.Domain
{
    public class Currency : Entity
    {
        public String Name { get; set; }
        
        public String Symbol { get; set; }

        public Currency(Guid id, string name, string symbol) : base(id)
        {
            Name = name;
            Symbol = symbol;
        }
    }
}