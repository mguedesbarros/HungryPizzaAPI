using AutoMapper;
using HungryPizzariaAPI.Application.Models.Cliente;
using HungryPizzariaAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Application.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile() => MapCreateCliente();

        private void MapCreateCliente()
        {
            CreateMap<ClienteModel, Cliente>();

            CreateMap<CreateClienteRequest, Cliente>();

            CreateMap<ResultEntity<Cliente>, CreateClienteResponse>()
                .ForMember(d => d.Success, opt => opt.MapFrom(o => o.IsSuccess))
                .ForMember(d => d.Erros, opt => opt.MapFrom(o => o.Erros));

            CreateMap<UpdateClienteRequest, Cliente>()
               .ForMember(d => d.Id, opt => opt.MapFrom(o => o.Id))
               .ForMember(d => d.Telefone, opt => opt.MapFrom(o => o.Telefone))
               .ForMember(d => d.Email, opt => opt.MapFrom(o => o.Email))
               .ForMember(d => d.Endereco, opt => opt.MapFrom(o => o.Endereco))
               .ForMember(d => d.Numero, opt => opt.MapFrom(o => o.Numero))
               .ForMember(d => d.Complemento, opt => opt.MapFrom(o => o.Complemento))
               .ForMember(d => d.Bairro, opt => opt.MapFrom(o => o.Bairro))
               .ForMember(d => d.Cidade, opt => opt.MapFrom(o => o.Cidade))
               .ForMember(d => d.CEP, opt => opt.MapFrom(o => o.CEP));

            CreateMap<ResultEntity<Cliente>, UpdateClienteResponse>()
                .ForMember(d => d.Success, opt => opt.MapFrom(o => o.IsSuccess))
                .ForMember(d => d.Erros, opt => opt.MapFrom(o => o.Erros));

            CreateMap<ResultEntity<Cliente>, DeleteClienteResponse>()
                .ForMember(d => d.Success, opt => opt.MapFrom(o => o.IsSuccess))
                .ForMember(d => d.Erros, opt => opt.MapFrom(o => o.Erros));
        }
    }
}
