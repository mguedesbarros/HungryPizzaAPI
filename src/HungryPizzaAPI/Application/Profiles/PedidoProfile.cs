using AutoMapper;
using HungryPizzariaAPI.Application.Models.ItemPedido;
using HungryPizzariaAPI.Application.Models.Pedido;
using HungryPizzariaAPI.Application.Models.Pizza;
using HungryPizzariaAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Application.Profiles
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile() => MapCreatePedido();

        private void MapCreatePedido()
        {
            CreateMap<Pedido, PedidoModel>()
                 .ForMember(d => d.ClienteID, opt => opt.MapFrom(o => o.ClienteID))
                 .ForMember(d => d.CodPedido, opt => opt.MapFrom(o => o.CodPedido))
                 .ForMember(d => d.ItensPedido, opt => opt.MapFrom(o => o.ItensPedido));

            CreateMap<ItemPedidoModel, ItemPedido>()
                .ForMember(d => d.Quantidade, opt => opt.MapFrom(o => o.Quantidade))
                .ForMember(d => d.QuantidadeSabores, opt => opt.MapFrom(o => o.QuantidadeSabores))
                .ForMember(d => d.PizzaID1, opt => opt.MapFrom(o => o.PizzaID1))
                .ForMember(d => d.PizzaID2, opt => opt.MapFrom(o => o.PizzaID2))
                .ForMember(d => d.ValorUnitario, opt => opt.MapFrom(o => o.ValorUnitario));

            CreateMap<ItemPedido, ItemPedidoModel>()
                .ForMember(d => d.Quantidade, opt => opt.MapFrom(o => o.Quantidade))
                .ForMember(d => d.ValorUnitario, opt => opt.MapFrom(o => o.ValorUnitario))
                .ForMember(d => d.QuantidadeSabores, opt => opt.MapFrom(o => o.QuantidadeSabores))
                .ForMember(d => d.Pizzas, opt => opt.MapFrom(o => o.Pizzas));

            CreateMap<CreatePedidoRequest, Pedido>()
                .ForMember(d => d.ClienteID, opt => opt.MapFrom(o => o.ClienteID))
                .ForMember(d => d.ItensPedido, opt => opt.MapFrom(o => o.ItensPedido));

            CreateMap<ResultEntity<Pedido>, CreatePedidoResponse>()
                .ForMember(d => d.CodPedido, opt => opt.MapFrom(o => o.Value().CodPedido))
                .ForMember(d => d.Success, opt => opt.MapFrom(o => o.IsSuccess))
                .ForMember(d => d.Erros, opt => opt.MapFrom(o => o.Erros));            

            CreateMap<ResultEntity<Pedido>, DeletePedidoResponse>()
                .ForMember(d => d.Success, opt => opt.MapFrom(o => o.IsSuccess))
                .ForMember(d => d.Erros, opt => opt.MapFrom(o => o.Erros));
        }
    }
}
