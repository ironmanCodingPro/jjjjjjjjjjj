using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PS.Data.Configuration;
using PS.Domain;
using System;
using System.Linq;

namespace PS.Data
{ 
    public class PSContext:DbContext
    {

        
        public PSContext()
        {
            //Database.EnsureCreated();   

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {




            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog = ProductStore;   
                                        Integrated Security = true");    
        }

        //la creation des tables ici
           
        public DbSet<Product> PRODUCTS { get; set; }
        public DbSet<Category> CATEGORIE { get; set; }
        public DbSet<Chemical> CHIMICAL { get; set; }
        public DbSet<Provider>  PROVIDER{ get; set; }
        public DbSet<Biological> BILOGICAL { get; set; }


        //appliquer flunet API confgiuration

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.ApplyConfiguration(new CategoryConfiguration());  // appel et active FLUNET API
            modelBuilder.ApplyConfiguration(new ChimcalConfiguration());
            modelBuilder.ApplyConfiguration(new ProductsConfiguration());



        }

    }
}
