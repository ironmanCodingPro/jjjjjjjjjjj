using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.ToTable("Mycategory");   //tbdel isem l base kif mt7ebh
            builder.HasKey(c => c.CategoryId);   //bch ta3tiha id
            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();  //tkhtar l'attribut eli bch tkhdem 3lih lhna name t7oto obligatoir w max 50 carc

        }
    }
}
