using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BecaDeportiva
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.NCastilloAlfaSolucionesContext context = new DL.NCastilloAlfaSolucionesContext())
                {
                    var query = (from OBecaDeportiva in context.BecaDeportivas
                                 select new
                                 {
                                     IdBecaDeportiva = OBecaDeportiva.IdBecaDeportiva,
                                     NombreDeportiva = OBecaDeportiva.NombreDeportiva
                                 }).ToList();

                    result.Objects = new List<Object>();

                    if(query != null)
                    {
                        foreach (var registro in query)
                        {
                            ML.BecaDeportiva beca = new ML.BecaDeportiva();

                            beca.IdBecaDeportiva = registro.IdBecaDeportiva;

                            beca.NombreDeportiva = registro.NombreDeportiva;

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
            catch (Exception ex) 
            {
                result.Correct = false;
            }

            return result;  
        }

    }
}
