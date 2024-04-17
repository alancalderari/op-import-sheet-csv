using ImportacaoPlanilhaOPlay.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImportacaoPlanilhaOPlay.Context.Mappings;

public class ProducVariationMap : IEntityTypeConfiguration<ProductVariation>
{
    public void Configure(EntityTypeBuilder<ProductVariation> builder)
    {
        builder.ToTable("variacao_produto");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("variacao_produto")
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .HasColumnName("nome")
            .HasColumnType("VARCHAR(1110)")
            .HasMaxLength(1100)
            .IsRequired();
        
        builder.Property(x => x.MeasurementUnit)
            .HasColumnName("unidade")
            .HasColumnType("VARCHAR(50)")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(x => x.Observations)
            .HasColumnName("complemento")
            .HasColumnType("VARCHAR(500)")
            .HasMaxLength(500)
            .IsRequired(false);
        
        builder.Property(x => x.NameComparison)
            .HasColumnName("nome_comparacao")
            .HasColumnType("VARCHAR(1700)")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(x => x.ObraPlayId)
            .HasColumnName("obraplay_id")
            .HasColumnType("INT")
            .IsRequired(false);
        
        builder.Property(x => x.ObraPlayItemId)
            .HasColumnName("obraplay_item_id")
            .HasColumnType("INT")
            .IsRequired(false);
        
        builder.Property(x => x.ObraPlayBrandId)
            .HasColumnName("obraplay_marca_id")
            .HasColumnType("INT")
            .IsRequired(false);
        
        builder.Property(x => x.Active)
            .HasColumnName("ativo")
            .HasColumnType("BIT")
            .IsRequired();

        builder.Property(x => x.Disregard)
            .HasColumnName("flg_desconsiderar")
            .HasColumnType("BIT");

        builder.Property(x => x.CreatedAt)
            .HasColumnName("dt_hora")
            .HasColumnType("DATETIME")
            .IsRequired();
        
        builder.Property(x => x.UpdatedAt)
            .HasColumnName("dt_update")
            .HasColumnType("DATETIME")
            .IsRequired();

    }
}