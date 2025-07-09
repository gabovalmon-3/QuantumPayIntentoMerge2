using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using DataAccess.CRUD;

namespace BaseManager
{
    public class TransaccionManager
    {
        private readonly TransaccionCrudFactory crud = new();

        public void Registrar(Transaccion t) => crud.Create(t);
        public List<Transaccion> ObtenerPorBanco(int idBanco) => crud.RetrieveByBanco(idBanco);
        public List<Transaccion> ObtenerPorComercio(int idComercio)
                                                              => crud.RetrieveByComercio(idComercio);
    }
}