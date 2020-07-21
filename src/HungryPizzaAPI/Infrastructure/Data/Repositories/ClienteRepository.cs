using HungryPizzariaAPI.Domain.Entities;
using HungryPizzariaAPI.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Infrastructure.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        protected readonly PizzariaContext Context;
        protected readonly DbSet<Cliente> DbSet;

        public ClienteRepository(PizzariaContext context)
        {
            this.Context = context;
            this.DbSet = Context.Set<Cliente>();
        }
        public void Add(Cliente cliente)
        {
            
            DbSet.Add(cliente);
        }

        public void Delete(Cliente cliente)
        {
            DbSet.Remove(cliente);
        }

        public async Task<IList<Cliente>> GetAll()
        {
            return await Context.Set<Cliente>().ToListAsync();
        }

        public Cliente GetById(int id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }

        public Cliente GetByTelefone(string telefone)
        {
            return DbSet.FirstOrDefault(x => x.Telefone == telefone);
        }

        public void Update(Cliente cliente)
        {
            Context.Entry(cliente).State = EntityState.Modified;
            Context.Entry(cliente).Property(x => x.DataCriacao).IsModified = false;

            DbSet.Update(cliente);
        }
    }
}
