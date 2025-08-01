using System.Collections.Generic;
using DataAccess.CRUD;
using DTOs;

namespace CoreApp
{
    public class CuentaClienteManager : BaseManager
    {
        private readonly ClienteCuentaCrudFactory crud = new();

        public void Create(ClienteCuenta c) => crud.Create(c);
        public void Update(ClienteCuenta c) => crud.Update(c);
        public void Delete(int id) => crud.Delete(new ClienteCuenta { Id = id });
        public List<ClienteCuenta> RetrieveByCliente(int clienteId) => crud.RetrieveByCliente(clienteId);
    }
}
