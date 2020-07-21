using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Domain.Entities
{
    public class Pedido : BaseEntity
    {
        private readonly List<ItemPedido> _itemsPedido = new List<ItemPedido>();
        public Pedido() 
        {
            ItensPedido = new List<ItemPedido>();
        }

        public Pedido(int clienteID, string codPedido, List<ItemPedido> itens)
        {            
            ClienteID = clienteID;
            CodPedido = codPedido;
            ItensPedido = itens;
        }

        public void SetClienteId(int clienteID)
        {
            ClienteID = clienteID;
        }

        public void AdicionarItenPedido(List<ItemPedido> itens)
        {
            ItensPedido.AddRange(itens);
        }

        public string CodPedido { get; set; }
        public List<ItemPedido> ItensPedido { get; set; }
        public int ClienteID { get; private set; }
        public virtual Cliente Cliente { get; set; }
    }
}
