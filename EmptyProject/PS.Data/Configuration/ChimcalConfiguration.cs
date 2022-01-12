using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Data.Configuration
{
    class ChimcalConfiguration : IEntityTypeConfiguration<Chemical>
    {
        public void Configure(EntityTypeBuilder<Chemical> builder)
        {

            builder.OwnsOne(ch => ch.adresse)   //apple de type complexe adresse
                   .Property(ad => ad.City)         // choisi le type
                   .HasColumnName("MyCity").IsRequired();    // smiha mycity w obligatoir




        }
    }
}
