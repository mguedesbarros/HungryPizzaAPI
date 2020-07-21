using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Domain.Entities
{
    public class ResultEntity<T> where T : BaseEntity
    {
        private ResultEntity(T entity)
        {
            this.entity = entity;
            this.IsSuccess = true;
        }

        public bool IsSuccess { get; private set; }
        public IList<string> Erros { get; private set; }
        private readonly T entity;

        public T Value()
        {
            return entity;
        }

        internal void AddError(string error)
        {
            if (this.Erros == null)
                this.Erros = new List<string>();

            this.Erros.Add(error);
            this.IsSuccess = false;
        }

        static internal ResultEntity<T> Fail(T entity, string error)
        {
            var result = new ResultEntity<T>(entity);
            result.AddError(error);
            return result;
        }

        static internal ResultEntity<T> Success(T entity) => new ResultEntity<T>(entity);
    }
}
