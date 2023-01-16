using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Magazin_Cosmetice.Models;

namespace Magazin_Cosmetice.Data
{
    public class Magazin_CosmeticeContext : DbContext
    {
        public Magazin_CosmeticeContext (DbContextOptions<Magazin_CosmeticeContext> options)
            : base(options)
        {
        }

        public DbSet<Magazin_Cosmetice.Models.Produs> Produs { get; set; } 

       

        public DbSet<Magazin_Cosmetice.Models.Categorie> Categorie { get; set; }

       

        public DbSet<Magazin_Cosmetice.Models.Client> Client { get; set; }

       

        public DbSet<Magazin_Cosmetice.Models.Cumparare> Cumparare { get; set; }
    }
}
