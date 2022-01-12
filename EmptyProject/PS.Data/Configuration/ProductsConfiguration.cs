using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.Domain;

namespace PS.Data.Configuration 
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(prod => prod.Providers)  //Providers mn table prduct jibtha min aka list des providers eli declaritha
                .WithMany(provi => provi.Products)   // kifkif
                .UsingEntity(a => a.ToTable("Providings"));  //esm table eli bch tajm3hom lzouz


            builder.HasOne(prod => prod.MyCategory)
                   .WithMany(cat => cat.Products)
                   .OnDelete(DeleteBehavior.Cascade);    // lhna disable   kif n7b nraj3ah tkhdem nzid godem .cascade.Enable              



        }
    }
}
