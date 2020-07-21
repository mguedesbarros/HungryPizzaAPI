using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Infrastructure.Mapper
{
    public class AutoMapperTypeAdapterFactory : ITypeAdapterFactory
    {

        public AutoMapperTypeAdapterFactory()
        {

            var profiles = AppDomain.CurrentDomain.GetAssemblies()
                .Where(p => p.FullName.StartsWith("HungryPizzaria"))
                .SelectMany(p => p.GetTypes())
                .Where(p => p.BaseType == typeof(Profile))
                .ToList();


            AutoMapper.Mapper.Initialize(cfg => {

                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;

                foreach (var profile in profiles)
                {
                    cfg.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            });
            AutoMapper.Mapper.Configuration.CompileMappings();

        }

        public ITypeAdapter Create()
        {
            return new AutoMapperTypeAdapter();
        }



    }
}
