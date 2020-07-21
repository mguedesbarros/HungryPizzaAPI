using HungryPizzariaAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Infrastructure.Data.EntityConfig
{
    public class ItemPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.ToTable("item_pedido");
            builder.HasKey(p => p.Id);

            builder.HasOne(c => c.Pedido)
                .WithMany(c => c.ItensPedido);

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Quantidade).HasColumnName("quantidade").IsRequired();
            builder.Property(p => p.ValorUnitario).HasColumnName("valor_unitario").HasColumnType("decimal(8, 2)").IsRequired();
            builder.Property(p => p.QuantidadeSabores).HasColumnName("quantidade_sabor").IsRequired();
            builder.Property(p => p.PedidoID).HasColumnName("pedido_id").IsRequired();
            builder.Property(p => p.PizzaID1).HasColumnName("pizza_id1").IsRequired();
            builder.Property(p => p.PizzaID2).HasColumnName("pizza_id2");

            builder.Ignore(p => p.Pizzas);
            builder.Ignore(p => p.CodPedido);
            builder.Ignore(p => p.DataCriacao);
            builder.Ignore(p => p.DataAtualizacao);
        }
    }
}
