using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepositoryPattern.Core.Models;

namespace RepositoryPattern.Domain
{
    public class Carro : Entity
    {
        public string Nome { get; set; }
        public int Potencia { get; set; }

        public Carro(Guid id, string nome, int potencia) : base(id)
        {
            Nome = nome;
            Potencia = potencia;
        }
    }
}