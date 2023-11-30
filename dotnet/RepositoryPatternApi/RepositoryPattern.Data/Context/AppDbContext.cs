using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Domain;

namespace RepositoryPattern.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Carro> Carros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}