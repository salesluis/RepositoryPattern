using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepositoryStore.Entities;

namespace RepositoryStore.Data.Mapping;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");
        
        builder.HasKey(p => p.Id);
        builder
            .Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .IsRequired(true);

        builder.Property(p => p.Title)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100)
            .IsRequired(true);
    }
}