using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BecaEducativa
    {

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.NCastilloAlfaSolucionesContext context = new DL.NCastilloAlfaSolucionesContext())
                {
                    var query = (from OBecaEducativa in context.BecaEducativas
                                 select new
                                 {
                                     IdBecaEducativa = OBecaEducativa.IdBecaEducativa,
                                     NombreEducativa = OBecaEducativa.NombreEducativa
                                 }).ToList();

                    result.Objects = new List<Object>();

                    if(query != null)
                    {
                        foreach(var registro in query)
                        {
                            ML.BecaEducativa beca = new ML.BecaEducativa();

                            beca.IdBecaEducativa = registro.IdBecaEducativa;

                            beca.NombreEducativa = registro.NombreEducativa;

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
            }

            return result;  
        }


    }
}
