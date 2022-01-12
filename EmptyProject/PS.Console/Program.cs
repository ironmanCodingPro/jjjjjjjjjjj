using PS.Data;
using PS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PS.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Category cat1 = new Category() { Name = "CAT1" };
            Category cat2 = new Category() { Name = "CAT2" };
            Category cat3 = new Category() { Name = "CAT3" };

            Product prod1 = new Product() { Name = "PROD1" };
            Product prod2 = new Product() { Name = "PROD2" };
            Product prod3 = new Product() { Name = "PROD3" };
            Product prod4 = new Product() { Name = "PROD4" };
            Product prod5 = new Product() { Name = "PROD5" };
            Product prod6 = new Product() { Name = "PROD6" };

            Provider prov1 = new Provider() { UserName = "PROV1" };
            Provider prov2 = new Provider() { UserName = "PROV2" };
            Provider prov3 = new Provider() { UserName = "PROV3" };
            Provider prov4 = new Provider() { UserName = "PROV4" };
            Provider prov5 = new Provider() { UserName = "PROV5" };

            prod1.MyCategory = cat1;
            prod2.MyCategory = cat1;
            prod5.MyCategory = cat2;
            prod3.MyCategory = cat3;
            prod6.MyCategory = cat3;

            prov1.Products = new List<Product>() { prod1, prod2, prod3 };
            prov2.Products = new List<Product>() { prod1, prod5 };
            prov3.Products = new List<Product>() { prod1, prod4 };
            prov4.Products = new List<Product>() { prod6, prod4 };
            prov5.Products = new List<Product>() { prod6, prod4 };

            prod1.Providers = new List<Provider>() { prov1, prov2, prov3 };
            prod2.Providers = new List<Provider>() { prov1 };
            prod3.Providers = new List<Provider>() { prov1 };
            prod4.Providers = new List<Provider>() { prov3, prov4, prov5 };
            prod5.Providers = new List<Provider>() { prov2 };
            prod6.Providers = new List<Provider>() { prov4, prov5 };

            // ps.PRODUCTS.Add(prod1);




            PSContext ps = new PSContext();

            System.Console.WriteLine("data base concted");

            ps.SaveChanges();          //kol ma bbadel haja n3mel commit 3ibar

        }
    }
}
