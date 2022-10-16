using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchanCountriesWorker.Core.Models;

namespace MerchanCountriesWorker.Domain
{
    public class Border : Entity
    {
        public String Name { get; set; }

        public Border(Guid id, string name) : base(id)
        {
            Name = name;
        }
    }
}