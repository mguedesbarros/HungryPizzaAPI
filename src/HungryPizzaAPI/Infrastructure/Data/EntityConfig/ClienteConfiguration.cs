using HungryPizzariaAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Infrastructure.Data.EntityConfig
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente");

            builder.HasMany(c => c.Pedido)
                    .WithOne(e => e.Cliente);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id);
            builder.Property(p => p.Nome).HasColumnName("nome").HasMaxLength(200).IsRequired();
            builder.Property(p => p.Telefone).HasColumnName("telefone").HasMaxLength(15).IsRequired();
            builder.Property(p => p.Email).HasColumnName("email").HasMaxLength(50);
            builder.Property(p => p.Endereco).HasColumnName("endereco").HasMaxLength(200).IsRequired();
            builder.Property(p => p.Numero).HasColumnName("numero").HasMaxLength(10).IsRequired();
            builder.Property(p => p.Complemento).HasColumnName("complemento").HasMaxLength(20);
            builder.Property(p => p.Bairro).HasColumnName("bairro").HasMaxLength(100);
            builder.Property(p => p.Cidade).HasColumnName("cidade").HasMaxLength(100);
            builder.Property(p => p.CEP).HasColumnName("cep").HasMaxLength(8);
            builder.Property(p => p.DataCriacao).HasColumnName("data_criacao").IsRequired();
            builder.Property(p => p.DataAtualizacao).HasColumnName("data_atualizacao").IsRequired();

            builder.Ignore(p => p.Pedido);
        }
    }
}
