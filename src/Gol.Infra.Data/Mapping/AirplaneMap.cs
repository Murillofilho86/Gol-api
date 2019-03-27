using Gol.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gol.Infra.Data.Mapping
{
    public class AirplaneMap : IEntityTypeConfiguration<Airplane>
    {
        public void Configure(EntityTypeBuilder<Airplane> builder)
        {
            builder.ToTable("Airplane");

            builder.HasKey(x => x.Id).HasName("Id");

            builder.Property(x => x.Code)
                .HasColumnName("Code")
                .HasMaxLength(30)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(x => x.Model)
                .HasColumnName("Model")
                .HasMaxLength(80)
                .HasColumnType("varchar(80)")
                .IsRequired();

            builder.Property(x => x.PassengersQuantity)
                .HasColumnName("QtdPassagers")
                .IsRequired();

            builder.Property(x => x.CreateDate)
                .HasColumnName("CreateDate")
                .IsRequired();
        }
    }
}
