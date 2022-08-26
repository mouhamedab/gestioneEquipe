using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Data.MyConfigurations;
using System.Linq;

namespace Data
{
    public class ExamenContext :DbContext
    {
        public DbSet<Equipe> Equipe { get; set; }
        public DbSet<Entraineur> Entraineur { get; set; }
        public DbSet<Joueur> Joueur { get; set; }
        public DbSet<Membre> Membre { get; set; }
        public DbSet<Trophee> Trophee { get; set; }
        public DbSet<Contrat> Contrat { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=FederationDB;Integrated Security=true;MultipleActiveResultSets=True");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contrat>().HasKey(c => new { c.DateContrat, c.EquipeFK, c.MembreFK });
            modelBuilder.Entity<Membre>().HasDiscriminator<string>("Type").HasValue<Entraineur>("E").HasValue<Joueur>("J");
            // cas : TPT
            //modelBuilder.Entity<Entraineur>().ToTable("Entraineurs");
            //modelBuilder.Entity<Joueur>().ToTable("Joueurs");
            new TropheeConfiguration().Configure(modelBuilder.Entity<Trophee>());
            // Configurer toutes les proprietés qui commence par code comme clé primaire
            foreach (var prop in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.Name.StartsWith("Code"))))
            {
                prop.IsPrimaryKey();
                // Configurer toutes les proprietés qui commence par code dans une colonne nommée code
                prop.SetColumnName("Code");
                // Configurer toutes les proprietés qui commence par code obligatoire
                prop.IsNullable = false;
            };
           
            base.OnModelCreating(modelBuilder);
        }
    }
}
