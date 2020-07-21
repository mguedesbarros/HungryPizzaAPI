using AutoMapper;
using HungryPizzariaAPI.Application.Models.ItemPedido;
using HungryPizzariaAPI.Application.Models.Pizza;
using HungryPizzariaAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Application.Profiles
{
    public class ItemPedidoProfile : Profile
    {
        public ItemPedidoProfile() => MapCreateItemPedido();

        private void MapCreateItemPedido()
        {
            CreateMap<Pizza, PizzaModel>();
            CreateMap<PizzaModel, Pizza>();

            CreateMap<ItemPedido, ItemPedidoModel>()
                .ForMember(d => d.Quantidade, opt => opt.MapFrom(o => o.Quantidade))
                .ForMember(d => d.QuantidadeSabores, opt => opt.MapFrom(o => o.QuantidadeSabores))
                .ForMember(d => d.Pizzas, opt => opt.MapFrom(o => o.Pizzas));

            CreateMap<ItemPedidoModel, ItemPedido>()
                .ForMember(d => d.Quantidade, opt => opt.MapFrom(o => o.Quantidade))
                .ForMember(d => d.QuantidadeSabores, opt => opt.MapFrom(o => o.QuantidadeSabores))
                .ForMember(d => d.ValorUnitario, opt => opt.MapFrom(o => o.ValorUnitario));

            CreateMap<CreateItemPedidoRequest, ItemPedido>()
                .ForMember(d => d.PedidoID, opt => opt.MapFrom(o => o.PedidoID))
                .ForMember(d => d.CodPedido, opt => opt.MapFrom(o => o.CodPedido))
                .ForMember(d => d.QuantidadeSabores, opt => opt.MapFrom(o => o.QuantidadeSabores))
                .ForMember(d => d.PizzaID1, opt => opt.MapFrom(o => o.PizzaID1))
                .ForMember(d => d.PizzaID2, opt => opt.MapFrom(o => o.PizzaID2));

            CreateMap<ResultEntity<ItemPedido>, CreateItemPedidoResponse>()
                .ForMember(d => d.Success, opt => opt.MapFrom(o => o.IsSuccess))
                .ForMember(d => d.Erros, opt => opt.MapFrom(o => o.Erros));

            CreateMap<UpdateItemPedidoRequest, ItemPedido>()
               .ForMember(d => d.Id, opt => opt.MapFrom(o => o.Id));

            CreateMap<ResultEntity<ItemPedido>, UpdateItemPedidoResponse>()
                .ForMember(d => d.Success, opt => opt.MapFrom(o => o.IsSuccess))
                .ForMember(d => d.Erros, opt => opt.MapFrom(o => o.Erros));

            CreateMap<ResultEntity<ItemPedido>, DeleteItemPedidoResponse>()
                .ForMember(d => d.Success, opt => opt.MapFrom(o => o.IsSuccess))
                .ForMember(d => d.Erros, opt => opt.MapFrom(o => o.Erros));
        }
    }
}
