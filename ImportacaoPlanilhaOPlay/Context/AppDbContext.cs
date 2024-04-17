using ImportacaoPlanilhaOPlay.Context.Entities;
using ImportacaoPlanilhaOPlay.Context.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ImportacaoPlanilhaOPlay.Context;

public class AppDbContext : DbContext
{
    public virtual DbSet<ProductVariation> ProductVariations { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=10.0.0.40,10500; Database=op_cor_dev; Integrated Security=True; TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProducVariationMap());
    }
}