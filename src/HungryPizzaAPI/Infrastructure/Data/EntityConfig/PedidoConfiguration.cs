using HungryPizzariaAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Infrastructure.Data.EntityConfig
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("pedido");
            builder.HasMany(c => c.ItensPedido)
                   .WithOne();

            builder.HasOne(c => c.Cliente)
                .WithMany(e => e.Pedido);

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id);

            builder.Property(p => p.CodPedido).HasColumnName("cod_pedido").HasMaxLength(10).IsRequired();
            //builder.Property(p => p.ValorTotal).HasColumnName("valor_total").HasColumnType("decimal(8, 2)").IsRequired();
            builder.Property(p => p.ClienteID).HasColumnName("cliente_id").IsRequired();
            builder.Property(p => p.DataCriacao).HasColumnName("data_criacao").IsRequired();
            builder.Property(p => p.DataAtualizacao).HasColumnName("data_atualizacao").IsRequired();            

            //builder.Ignore(p => p.Cliente);
            //builder.Ignore(p => p.ItemsPedido);
        }
    }
}
