using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchanCountriesWorker.Core.Models;

namespace MerchanCountriesWorker.Domain
{
    public class Country : Entity
    {
        public String Name { get; set; }
        public String Symbol { get; set; }
        public String Language { get; set; }
        public String Capital { get; set; }
        public long Population { get; set; }
        public String Flag { get; set; }

        public Country(Guid id, string name, string symbol, string language, string capital, long population, string flag) : base(id)
        {
            Name = name;
            Symbol = symbol;
            Language = language;
            Capital = capital;
            Population = population;
            Flag = flag;
        }
    }
}