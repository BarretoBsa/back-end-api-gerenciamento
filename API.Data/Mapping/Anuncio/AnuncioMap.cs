using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class AnuncioMap : IEntityTypeConfiguration<AnuncioEntity>
    {
        public void Configure(EntityTypeBuilder<AnuncioEntity> builder)
        {
            builder.ToTable("tb_AnuncioWebmotors");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Marca)
                .IsRequired()
                .HasMaxLength(45);
            builder.Property(a => a.Modelo)
                .IsRequired()
                .HasMaxLength(45);
            builder.Property(a => a.Versao )
                 .IsRequired()
                .HasMaxLength(45);
            builder.Property(a => a.Ano)
                 .IsRequired();
            builder.Property(a => a.Quilometragem)
                 .IsRequired();
            builder.Property(a => a.Observacao)
                 .IsRequired();
            builder.Property(a => a.CreateAt)
                .IsRequired();
            builder.Property(a => a.UpdateAt);

        }
    }

}
