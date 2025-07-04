using DTOs;
using DataAccess.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp
{
    public class ClienteManager : BaseManager
    {

        public void Create(Cliente cliente)
        {
            try
            {
                if (IsOver18(cliente))
                {
                    var cCrud = new ClienteCrudFactory();

                    var cExist = cCrud.RetrieveByCedula<Cliente>(cliente);

                    if (cExist == null)
                    {
                        cExist = cCrud.RetrieveByEmail<Cliente>(cliente);

                        if (cExist == null)
                        {
                            cCrud.Create(cliente);

                            if ((cExist == null))
                            {
                                cExist = cCrud.RetrieveByTelefono<Cliente>(cliente);
                            }
                            else
                            {
                                throw new Exception("Ese telefono no esta disponible.");
                            }
                        }
                        else
                        {
                            throw new Exception("El email ya esta registrado");
                        }
                    }
                    else
                    {
                        throw new Exception("Esa cedula no esta disponible");
                    }
                }
                else
                {
                    throw new Exception("No cumple con la edad minima");
                }
            }

            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        public List<Cliente> RetrieveAll()
        {
            var cCrud = new ClienteCrudFactory();
            return cCrud.RetrieveAll<Cliente>();

        }

        public Cliente RetrieveById(Cliente cliente)
        {
            var cCrud = new ClienteCrudFactory();
            return cCrud.RetrieveById<Cliente>(cliente);
        }

        public Cliente RetrieveByEmail(Cliente cliente)
        {
            var uCrud = new ClienteCrudFactory();
            return uCrud.RetrieveByEmail<Cliente>(cliente);
        }

        public Cliente RetrieveByCedula(Cliente cliente)
        {
            var cCrud = new ClienteCrudFactory();
            return cCrud.RetrieveByCedula<Cliente>(cliente);
        }

        public Cliente RetrieveByTelefono(Cliente cliente)
        {
            var cCrud = new ClienteCrudFactory();
            return cCrud.RetrieveByTelefono<Cliente>(cliente);
        }

        public void Update(Cliente cliente)
        {
            try
            {
                if (IsOver18(cliente))
                {
                    var cCrud = new ClienteCrudFactory();
                    var cExist = cCrud.RetrieveById<Cliente>(cliente);
                    if (cExist != null)
                    {
                        cCrud.Update(cliente);
                    }
                    else
                    {
                        throw new Exception("No existe un cliente con ese ID");
                    }
                }
                else
                {
                    throw new Exception("No cumple con la edad minima");
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var cCrud = new ClienteCrudFactory();
                var cliente = new Cliente { Id = id };
                var cExist = cCrud.RetrieveById<Cliente>(cliente);
                if (cExist != null)
                {
                    cCrud.Delete(cliente);
                }
                else
                {
                    throw new Exception("No existe un cliente con ese ID");
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }


        private bool IsOver18(Cliente cliente)
        {
            var currentDate = DateTime.Now;
            int age = currentDate.Year - cliente.fechaNacimiento.Year;

            var birthDate = cliente.fechaNacimiento.ToDateTime(TimeOnly.MinValue);

            if (birthDate > currentDate.AddYears(-age))
            {
                age--;
            }
            return age >= 18;
        }
    }
}
