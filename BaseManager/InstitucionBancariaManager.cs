using DTOs;
using DataAccess.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp
{
    public class InstitucionBancariaManager : BaseManager
    {

        public void Create(InstitucionBancaria institucionBancaria)
        {
            try
            {
                var iCrud = new InstitucionBancariaCrudFactory();

                var iExist = iCrud.RetrieveByCodigoIdentidad<InstitucionBancaria>(institucionBancaria);

                if (iExist == null)
                {
                    iExist = iCrud.RetrieveByIBAN<InstitucionBancaria>(institucionBancaria);

                    if (iExist == null)
                    {
                        iExist = iCrud.RetrieveByEmail<InstitucionBancaria>(institucionBancaria);

                        if (iExist == null)
                        {
                            iExist = iCrud.RetrieveByTelefono<InstitucionBancaria>(institucionBancaria);

                            if(iExist == null)
                            {
                                iCrud.Create(institucionBancaria);
                            }
                            else
                            {
                                throw new Exception("Ese telefono no esta disponible");
                            }
                        }
                        else
                        {
                            throw new Exception("Ese correo electronico no esta disponible.");
                        }
                    }
                    else
                    {
                        throw new Exception("Ese codigo IBAN no esta disponible");
                    }
                }
                else
                {
                    throw new Exception("Ese codigo de identidad no esta disponible");
                }
            }

            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        public List<InstitucionBancaria> RetrieveAll()
        {
            var iCrud = new InstitucionBancariaCrudFactory();
            return iCrud.RetrieveAll<InstitucionBancaria>();

        }

        public InstitucionBancaria RetrieveById(InstitucionBancaria institucionBancaria)
        {
            var iCrud = new InstitucionBancariaCrudFactory();
            return iCrud.RetrieveById<InstitucionBancaria>(institucionBancaria);
        }

        public InstitucionBancaria RetrieveByEmail(InstitucionBancaria institucionBancaria)
        {
            var iCrud = new InstitucionBancariaCrudFactory();
            return iCrud.RetrieveByEmail<InstitucionBancaria>(institucionBancaria);
        }

        public InstitucionBancaria RetrieveByCodigoIdentidad(InstitucionBancaria institucionBancaria)
        {
            var iCrud = new InstitucionBancariaCrudFactory();
            return iCrud.RetrieveByCodigoIdentidad<InstitucionBancaria>(institucionBancaria);
        }

        public InstitucionBancaria RetrieveByTelefono(InstitucionBancaria institucionBancaria)
        {
            var iCrud = new InstitucionBancariaCrudFactory();
            return iCrud.RetrieveByTelefono<InstitucionBancaria>(institucionBancaria);
        }

        public InstitucionBancaria RetrieveByIBAN(InstitucionBancaria institucionBancaria)
        {
            var iCrud = new InstitucionBancariaCrudFactory();
            return iCrud.RetrieveByIBAN<InstitucionBancaria>(institucionBancaria);
        }

        public void Update(InstitucionBancaria institucionBancaria)
        {
            try
            {
                var iCrud = new InstitucionBancariaCrudFactory();
                var iExist = iCrud.RetrieveById<InstitucionBancaria>(institucionBancaria);
                if (iExist != null)
                {
                    iCrud.Update(institucionBancaria);
                }
                else
                {
                    throw new Exception("No existe una institucion bancaria con ese ID");
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
                var iCrud = new InstitucionBancariaCrudFactory();
                var institucionBancaria = new InstitucionBancaria { Id = id };
                var iExist = iCrud.RetrieveById<InstitucionBancaria>(institucionBancaria);
                if (iExist != null)
                {
                    iCrud.Delete(institucionBancaria);
                }
                else
                {
                    throw new Exception("No existe una institucion bancaria con ese ID");
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }
    }
}
