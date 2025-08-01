using System;
using System.Collections.Generic;
using DataAccess.DAOs;
using DTOs;

namespace DataAccess.CRUD
{
    public class TransaccionCrudFactory : CrudFactory
    {
        public TransaccionCrudFactory() => _sqlDao = SQL_DAO.GetInstance();

        public override void Create(BaseDTO dto)
        {
            var t = (Transaccion)dto;
            var op = new SQLOperation { ProcedureName = "dbo.SP_INS_TRANSACCION" };

            // IdCuentaBancaria sigue siendo INT para la FK
            op.AddIntParam("P_IdCuentaBancaria", t.IdCuentaBancaria);
            // Nuevo parámetro IBAN como VARCHAR
            op.AddVarcharParam("P_IBAN", t.IBAN, 30);

            op.AddIntParam("P_IdCuentaComercio", t.IdCuentaComercio);
            op.AddDoubleParam("P_Monto", (double)t.Monto);
            op.AddDoubleParam("P_Comision", (double)t.Comision);
            op.AddDoubleParam("P_DescuentoAplicado", (double)t.DescuentoAplicado);
            op.AddDateTimeParam("P_Fecha", t.Fecha);
            op.AddVarcharParam("P_MetodoPago", t.MetodoPago, 50);

            _sqlDao.ExecuteProcedure(op);
        }

        public override void Update(BaseDTO dto)
        {
            var t = (Transaccion)dto;
            var op = new SQLOperation { ProcedureName = "dbo.SP_UPD_TRANSACCION" };

            op.AddIntParam("P_Id", t.Id);
            op.AddIntParam("P_IdCuentaBancaria", t.IdCuentaBancaria);
            op.AddVarcharParam("P_IBAN", t.IBAN, 30);
            op.AddIntParam("P_IdCuentaComercio", t.IdCuentaComercio);
            op.AddDoubleParam("P_Monto", (double)t.Monto);
            op.AddDoubleParam("P_Comision", (double)t.Comision);
            op.AddDoubleParam("P_DescuentoAplicado", (double)t.DescuentoAplicado);
            op.AddDateTimeParam("P_Fecha", t.Fecha);
            op.AddVarcharParam("P_MetodoPago", t.MetodoPago, 50);

            _sqlDao.ExecuteProcedure(op);
        }

        public override void Delete(BaseDTO dto) => throw new NotImplementedException();
        public override T Retrieve<T>() => throw new NotImplementedException();
        public override T RetrieveById<T>(int id) => throw new NotImplementedException();

        public override List<T> RetrieveAll<T>()
        {
            var op = new SQLOperation { ProcedureName = "dbo.SP_RET_ALL_TRANSACCION" };
            var rows = _sqlDao.ExecuteQueryProcedure(op);
            var lst = new List<T>();

            foreach (var r in rows)
            {
                var x = new Transaccion
                {
                    Id = (int)r["Id"],
                    IdCuentaBancaria = Convert.ToInt32(r["IdCuentaBancaria"]),
                    IBAN = r["IBAN"].ToString(),
                    IdCuentaComercio = (int)r["IdCuentaComercio"],
                    Monto = Convert.ToDecimal(r["Monto"]),
                    Comision = Convert.ToDecimal(r["Comision"]),
                    DescuentoAplicado = Convert.ToDecimal(r["DescuentoAplicado"]),
                    Fecha = (DateTime)r["Fecha"],
                    MetodoPago = r["MetodoPago"].ToString()
                };
                lst.Add((T)Convert.ChangeType(x, typeof(T)));
            }

            return lst;
        }

        public List<Transaccion> RetrieveByBanco(string iban)
        {
            var op = new SQLOperation { ProcedureName = "dbo.SP_RET_TRANS_POR_CUENTA" };
            op.AddVarcharParam("P_IdCuentaBancaria", iban, 30);

            var rows = _sqlDao.ExecuteQueryProcedure(op);
            var lst = new List<Transaccion>();

            foreach (var r in rows)
            {
                lst.Add(new Transaccion
                {
                    Id = (int)r["Id"],
                    IdCuentaBancaria = Convert.ToInt32(r["IdCuentaBancaria"]),
                    IBAN = r["IBAN"].ToString(),
                    IdCuentaComercio = (int)r["IdCuentaComercio"],
                    Monto = Convert.ToDecimal(r["Monto"]),
                    Comision = Convert.ToDecimal(r["Comision"]),
                    DescuentoAplicado = Convert.ToDecimal(r["DescuentoAplicado"]),
                    Fecha = (DateTime)r["Fecha"],
                    MetodoPago = r["MetodoPago"].ToString()
                });
            }

            return lst;
        }

        public List<Transaccion> RetrieveByComercio(int idComercio)
        {
            var op = new SQLOperation { ProcedureName = "dbo.SP_RET_TRANS_POR_COMERCIO" };
            op.AddIntParam("P_IdCuentaComercio", idComercio);

            var rows = _sqlDao.ExecuteQueryProcedure(op);
            var lst = new List<Transaccion>();

            foreach (var r in rows)
            {
                lst.Add(new Transaccion
                {
                    Id = (int)r["Id"],
                    IdCuentaBancaria = Convert.ToInt32(r["IdCuentaBancaria"]),
                    IBAN = r["IBAN"].ToString(),
                    IdCuentaComercio = (int)r["IdCuentaComercio"],
                    Monto = Convert.ToDecimal(r["Monto"]),
                    Comision = Convert.ToDecimal(r["Comision"]),
                    DescuentoAplicado = Convert.ToDecimal(r["DescuentoAplicado"]),
                    Fecha = (DateTime)r["Fecha"],
                    MetodoPago = r["MetodoPago"].ToString()
                });
            }

            return lst;
        }

        public List<Transaccion> RetrieveByCliente(int clienteId)
        {
            var op = new SQLOperation { ProcedureName = "dbo.SP_SEL_TRANSACCIONES_POR_CLIENTE" };
            op.AddIntParam("ClienteId", clienteId);

            var rows = _sqlDao.ExecuteQueryProcedure(op);
            var lst = new List<Transaccion>();

            foreach (var r in rows)
            {
                lst.Add(new Transaccion
                {
                    Id = (int)r["Id"],
                    IdCuentaBancaria = Convert.ToInt32(r["IdCuentaBancaria"]),
                    IBAN = r["IBAN"].ToString(),
                    IdCuentaComercio = (int)r["IdCuentaComercio"],
                    Monto = Convert.ToDecimal(r["Monto"]),
                    Comision = Convert.ToDecimal(r["Comision"]),
                    DescuentoAplicado = Convert.ToDecimal(r["DescuentoAplicado"]),
                    Fecha = (DateTime)r["Fecha"],
                    MetodoPago = r["MetodoPago"].ToString()
                });
            }

            return lst;
        }
    }
}
