using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Infrastructure.Mapper
{
    public class AutoMapperTypeAdapter : ITypeAdapter
    {
        public TTarget Adapt<TTarget>(object source) where TTarget : class
        {
            return AutoMapper.Mapper.Map(source, source.GetType(), typeof(TTarget)) as TTarget;
        }

        public TTarget Adapt<TSource, TTarget>(TSource source) where TSource : class where TTarget : class
        {
            return AutoMapper.Mapper.Map<TSource, TTarget>(source);
        }
    }
}
