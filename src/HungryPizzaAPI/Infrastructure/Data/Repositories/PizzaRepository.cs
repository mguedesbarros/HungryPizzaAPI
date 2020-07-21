using HungryPizzariaAPI.Domain.Entities;
using HungryPizzariaAPI.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Infrastructure.Data.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        protected readonly PizzariaContext Context;
        protected readonly DbSet<Pizza> DbSet;

        public PizzaRepository(PizzariaContext context)
        {
            this.Context = context;
            this.DbSet = Context.Set<Pizza>();
        }

        public void Add(Pizza pizza)
        {
            DbSet.Add(pizza);
        }

        public async Task<IList<Pizza>> GetAll()
        {
            return await Context.Set<Pizza>().ToListAsync();
        }

        public Pizza GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Delete(Pizza pizza)
        {
            DbSet.Remove(pizza);
        }

        public void Update(Pizza pizza)
        {
            Context.Entry(pizza).State = EntityState.Modified;
            Context.Entry(pizza).Property(x => x.DataCriacao).IsModified = false;

            DbSet.Update(pizza);
        }

        public Pizza GetBySabor(string sabor)
        {
            return DbSet.FirstOrDefault(x => x.Sabor == sabor);
        }
    }
}
