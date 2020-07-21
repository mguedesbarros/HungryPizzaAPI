using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Infrastructure.Mapper
{
    public interface ITypeAdapter
    {
        TTarget Adapt<TSource, TTarget>(TSource source) where TTarget : class where TSource : class;
        TTarget Adapt<TTarget>(object source) where TTarget : class;
    }
}
