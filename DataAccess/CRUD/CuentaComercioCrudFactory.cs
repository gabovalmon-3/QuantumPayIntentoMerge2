﻿using DataAccess.DAOs;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public class CuentaComercioCrudFactory : CrudFactory
    {

        public CuentaComercioCrudFactory()
        {
            _sqlDao = SQL_DAO.GetInstance();
        }


        public override void Create(BaseDTO baseDTO)
        {
            var cuentaComercio = baseDTO as CuentaComercio;
            var sqlOperation = new SQLOperation() { ProcedureName = "CRE_CUENTACOMERCIO_PR" };

            sqlOperation.ProcedureName = "CRE_CUENTACOMERCIO_PR";

            sqlOperation.AddStringParameter("P_nombreUsuario", cuentaComercio.NombreUsuario);
            sqlOperation.AddStringParameter("P_contrasena", cuentaComercio.Contrasena);
            sqlOperation.AddStringParameter("P_cedulaJuridica", cuentaComercio.CedulaJuridica);
            sqlOperation.AddIntParam("P_telefono", cuentaComercio.Telefono);
            sqlOperation.AddStringParameter("P_correoElectronico", cuentaComercio.CorreoElectronico);
            sqlOperation.AddStringParameter("P_direccion", cuentaComercio.Direccion);

            _sqlDao.ExecuteProcedure(sqlOperation);

        }

        public override T Retrieve<T>()
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstCuentasComercio = new List<T>();

            var sqlOperation = new SQLOperation() { ProcedureName = "RET_ALL_CUENTACOMERCIO_PR" };

            var lstResult = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResult.Count > 0)
            {
                foreach (var row in lstResult)
                {
                    var cuentaComercio = BuildCuentasComercio(row);
                    lstCuentasComercio.Add((T)(object)cuentaComercio);
                }
            }

            return lstCuentasComercio;
        }


        public override T RetrieveById<T>(int Id)
        {
            var sqlOperation = new SQLOperation() { ProcedureName = "RET_CUENTACOMERCIO_BY_ID_PR" };

            sqlOperation.AddIntParam("P_idCuenta", Id);

            var lstResult = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResult.Count > 0)
            {
                var row = lstResult[0];
                var cuentaComercio = BuildCuentasComercio(row);
                return (T)Convert.ChangeType(cuentaComercio, typeof(T));
            }

            return default(T);
        }


        public T RetrieveByUserName<T>(string NombreUsuario)
        {
            var sqlOperation = new SQLOperation() { ProcedureName = "RET_CUENTACOMERCIO_BY_USERNAME_PR" };

            sqlOperation.AddStringParameter("P_nombreUsuario", NombreUsuario);

            var lstResult = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResult.Count > 0)
            {
                var row = lstResult[0];
                var cuentaComercio = BuildCuentasComercio(row);

                return (T)Convert.ChangeType(cuentaComercio, typeof(T));
            }

            return default(T);
        }

        public T RetrieveByTelefono<T>(int Telefono)
        {
            var sqlOperation = new SQLOperation() { ProcedureName = "RET_CUENTACOMERCIO_BY_TELEFONO_PR" };

            sqlOperation.AddIntParam("P_telefono", Telefono);

            var lstResult = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResult.Count > 0)
            {
                var row = lstResult[0];
                var cuentaComercio = BuildCuentasComercio(row);

                return (T)Convert.ChangeType(cuentaComercio, typeof(T));
            }

            return default(T);
        }

        public T RetrieveByEmail<T>(string CorreoElectronico)
        {
            var sqlOperation = new SQLOperation() { ProcedureName = "RET_CUENTACOMERCIO_BY_EMAIL_PR" };

            sqlOperation.AddStringParameter("P_correoElectronico", CorreoElectronico);

            var lstResult = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResult.Count > 0)
            {
                var row = lstResult[0];
                var cuentaComercio = BuildCuentasComercio(row);
                return (T)Convert.ChangeType(cuentaComercio, typeof(T));
            }
            return default(T);
        }

        public override void Update(BaseDTO baseDTO)
        {
            var cuentaComercio = baseDTO as CuentaComercio;
            var sqlOperation = new SQLOperation() { ProcedureName = "UPD_CUENTACOMERCIO_PR" };

            sqlOperation.AddIntParam("P_idCuenta", cuentaComercio.Id);
            sqlOperation.AddStringParameter("P_nombreUsuario", cuentaComercio.NombreUsuario);
            sqlOperation.AddStringParameter("P_contrasena", cuentaComercio.Contrasena);
            sqlOperation.AddStringParameter("P_cedulaJuridica", cuentaComercio.CedulaJuridica);
            sqlOperation.AddIntParam("P_telefono", cuentaComercio.Telefono);
            sqlOperation.AddStringParameter("P_correoElectronico", cuentaComercio.CorreoElectronico);
            sqlOperation.AddStringParameter("P_direccion", cuentaComercio.Direccion);

            _sqlDao.ExecuteProcedure(sqlOperation);
        }


        public override void Delete(BaseDTO baseDTO)
        {
            var cuentaComercio = baseDTO as CuentaComercio;
            var sqlOperation = new SQLOperation() { ProcedureName = "DEL_CUENTACOMERCIO_PR" };
            sqlOperation.AddIntParam("P_idCuenta", cuentaComercio.Id);
            _sqlDao.ExecuteProcedure(sqlOperation);
        }

        //Metodo que convierte diccionario en un usuario
        private CuentaComercio BuildCuentasComercio(Dictionary<string, object> row)
        {
            return new CuentaComercio()
            {
                Id = (int)row["idCuenta"],
                NombreUsuario = row["nombreUsuario"].ToString(),
                Contrasena = row["contrasena"].ToString(),
                CedulaJuridica = row["cedulaJuridica"].ToString(),
                Telefono = row["telefono"] == DBNull.Value ? 0 : Convert.ToInt32(row["telefono"]),
                CorreoElectronico = row["correoElectronico"].ToString(),
                Direccion = row["direccion"].ToString()
            };
        }

        public override T RetrieveById<T>()
        {
            throw new NotImplementedException();
        }

        public T RetrieveByEmail<T>(T cuentaComercio)
        {
            throw new NotImplementedException();
        }
    }
}
