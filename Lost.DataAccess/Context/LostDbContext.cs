using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Lost.Model;

namespace Lost.DataAccess.Context
{
    public class LostDbContext : DbContext
    {
        public LostDbContext(DbContextOptions<LostDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Groupe> Groupe { get; set; }
        public DbSet<Personne> Personne { get; set; }
        public DbSet<Semaine> Semaine { get; set; }
        public DbSet<TauxBlanchiment> TauxBlanchiment { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Utilisateur> Utilisateur { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
