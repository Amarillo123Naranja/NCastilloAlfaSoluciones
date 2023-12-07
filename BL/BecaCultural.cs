using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BecaCultural
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.NCastilloAlfaSolucionesContext context = new DL.NCastilloAlfaSolucionesContext())
                {
                    var query = (from OBecaCultural in context.BecaCulturals
                                 select new
                                 {
                                     IdBecaCultural = OBecaCultural.IdBecaCultural,
                                     NombreCultural = OBecaCultural.NombreCultural
                                 }).ToList();

                    result.Objects = new List<Object>();

                    if(query != null)
                    {
                        foreach(var registro in query)
                        {
                            ML.BecaCultural beca = new ML.BecaCultural();

                            beca.IdBecaCultural = registro.IdBecaCultural;

                            beca.NombreCultural = registro.NombreCultural;

                            result.Objects.Add(beca);   

                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }
            }
            catch(Exception ex) 
            {
                result.Correct = false; 
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            
            }

            return result;  

        }

    }
}
