using AutoMapper;
using HungryPizzariaAPI.Application.Models.Pizza;
using HungryPizzariaAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Application.Profiles
{
    public class PizzaProfile : Profile
    {
        public PizzaProfile() => MapCreatePizza();

        private void MapCreatePizza()
        {
            CreateMap<PizzaModel, Pizza>();

            CreateMap<CreatePizzaRequest, Pizza>();

            CreateMap<ResultEntity<Pizza>, CreatePizzaResponse>()
                .ForMember(d => d.Success, opt => opt.MapFrom(o => o.IsSuccess))
                .ForMember(d => d.Erros, opt => opt.MapFrom(o => o.Erros));

            CreateMap<UpdatePizzaRequest, Pizza>()
               .ForMember(d => d.Id, opt => opt.MapFrom(o => o.Id))
               .ForMember(d => d.Sabor, opt => opt.MapFrom(o => o.Sabor))
               .ForMember(d => d.Valor, opt => opt.MapFrom(o => o.Valor));

            CreateMap<ResultEntity<Pizza>, UpdatePizzaResponse>()
                .ForMember(d => d.Success, opt => opt.MapFrom(o => o.IsSuccess))
                .ForMember(d => d.Erros, opt => opt.MapFrom(o => o.Erros));

            CreateMap<ResultEntity<Pizza>, DeletePizzaResponse>()
                .ForMember(d => d.Success, opt => opt.MapFrom(o => o.IsSuccess))
                .ForMember(d => d.Erros, opt => opt.MapFrom(o => o.Erros));
        }
    }
}
