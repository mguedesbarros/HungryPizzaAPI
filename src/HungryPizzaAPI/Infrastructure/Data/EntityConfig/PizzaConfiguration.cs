using HungryPizzariaAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Infrastructure.Data.EntityConfig
{
    public class PizzaConfiguration : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.ToTable("pizza");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Sabor).HasColumnName("sabor").HasMaxLength(100).IsRequired();
            builder.Property(p => p.Valor).HasColumnName("valor").HasColumnType("decimal(8, 2)").IsRequired();
            builder.Property(p => p.DataCriacao).HasColumnName("data_criacao").IsRequired();
            builder.Property(p => p.DataAtualizacao).HasColumnName("data_atualizacao").IsRequired();

            builder.Ignore(p => p.ItemPedido);

        }
    }
}
