using HungryPizzariaAPI.Application.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Application.Services.Interfaces
{
    public interface IClienteAppService
    {
        CreateClienteResponse Create(CreateClienteRequest request);
        UpdateClienteResponse Update(UpdateClienteRequest request);
        Task<IList<ClienteModel>> GetAll();
        ClienteModel GetById(int id);
        DeleteClienteResponse Delete(int id);
    }
}
