using DTOs;
using DataAccess.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp
{
    public class ComercioManager : BaseManager
    {

        public void Create(Comercio comercio)
        {
            try
            {
                var uCrud = new ComercioCrudFactory();
                
                var uExist = uCrud.RetrieveByComercioName<Comercio>(comercio);
                
                if (uExist == null)
                {
                    uCrud.Create(comercio);
                }
                else
                {
                    throw new Exception("El codigo de usuario no esta disponible");
                }
            }

            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        public List<Comercio> RetrieveAll()
        {
            var uCrud = new ComercioCrudFactory();
            return uCrud.RetrieveAll<Comercio>();

        }

        public Comercio RetrieveById(Comercio comercio)
        {
            var uCrud = new ComercioCrudFactory();
            return uCrud.RetrieveById<Comercio>(comercio);
        }

        public void Update(Comercio comercio)
        {
            try
            {
                var uCrud = new ComercioCrudFactory();
                var uExist = uCrud.RetrieveById<Comercio>(comercio);
                if (uExist != null)
                {
                    uCrud.Update(comercio);
                }
                else
                {
                    throw new Exception("No existe un comercio con ese ID");
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
                var uCrud = new ComercioCrudFactory();
                var comercio = new Comercio { Id = id };
                var uExist = uCrud.RetrieveById<Comercio>(comercio);
                if (uExist != null)
                {
                    uCrud.Delete(comercio);
                }
                else
                {
                    throw new Exception("No existe un usuario con ese ID");
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }
    }
}
