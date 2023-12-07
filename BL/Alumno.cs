using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Alumno
    {

        public static ML.Result GetAll(string nombre, int idCultural, int idDeportiva, int idEducativa)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.NCastilloAlfaSolucionesContext context = new DL.NCastilloAlfaSolucionesContext())
                {

                    var query = context.Alumnos.FromSqlRaw($"AlumnoBusqueda '{nombre}', {idCultural}, {idDeportiva}, {idEducativa}").ToList();
                                    

                    result.Objects = new List<Object>();

                    if (query != null)
                    {
                        foreach (var registro in query)
                        {
                            ML.Alumno alumno = new ML.Alumno();

                            alumno.IdAlumno = registro.IdAlumno;

                            alumno.Nombre = registro.Nombre;

                            alumno.Genero = registro.Genero;

                            alumno.Edad = registro.Edad.Value;

                            alumno.IdBecaCultural = registro.IdBecaCultural.Value;


                            alumno.BecaCultural = new ML.BecaCultural();

                            alumno.BecaCultural.NombreCultural = registro.NombreCultural;

                           

                            alumno.IdBecaDeportiva = registro.IdBecaDeportiva.Value;

                            alumno.BecaDeportiva = new ML.BecaDeportiva();

                            alumno.BecaDeportiva.NombreDeportiva = registro.NombreDeportiva;

                           

                            alumno.IdBecaEducativa = registro.IdBecaEducativa.Value;

                            alumno.BecaEducativa = new ML.BecaEducativa();

                            alumno.BecaEducativa.NombreEducativa = registro.NombreEducativa;

                            result.Objects.Add(alumno);
                        }

                        result.Correct = true;


                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error";
                    }


                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }






        //public static ML.Result GetAll()
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (DL.NCastilloAlfaSolucionesContext context = new DL.NCastilloAlfaSolucionesContext())
        //        {

        //            var query = (from OAlumno in context.Alumnos
        //                         join OBecaCultural in context.BecaCulturals
        //                         on OAlumno.IdBecaCultural equals OBecaCultural.IdBecaCultural
        //                         join OBecaDeportiva in context.BecaDeportivas
        //                         on OAlumno.IdBecaDeportiva equals OBecaDeportiva.IdBecaDeportiva
        //                         join OBecaEducativa in context.BecaEducativas
        //                         on OAlumno.IdBecaEducativa equals OBecaEducativa.IdBecaEducativa
        //                         select new
        //                         {
        //                             IdAlumno = OAlumno.IdAlumno,
        //                             Nombre = OAlumno.Nombre,
        //                             Genero = OAlumno.Genero,
        //                             Edad = OAlumno.Edad,
        //                             IdBecaCultural = OBecaCultural.IdBecaCultural,
        //                             NombreCultural = OBecaCultural.NombreCultural,
        //                             IdBecaDeportiva = OBecaDeportiva.IdBecaDeportiva,
        //                             NombreDeportiva = OBecaDeportiva.NombreDeportiva,
        //                             IdBecaEducativa = OBecaEducativa.IdBecaEducativa,
        //                             NombreEducativa = OBecaEducativa.NombreEducativa
        //                         }).ToList();

        //            result.Objects = new List<Object>();

        //            if (query != null)
        //            {
        //                foreach (var registro in query)
        //                {
        //                    ML.Alumno alumno = new ML.Alumno();

        //                    alumno.IdAlumno = registro.IdAlumno;

        //                    alumno.Nombre = registro.Nombre;

        //                    alumno.Genero = registro.Genero;

        //                    alumno.Edad = registro.Edad.Value;

        //                    alumno.BecaCultural = new ML.BecaCultural();

        //                    alumno.BecaCultural.IdBecaCultural = registro.IdBecaCultural;

        //                    alumno.BecaCultural.NombreCultural = registro.NombreCultural;

        //                    alumno.BecaDeportiva = new ML.BecaDeportiva();

        //                    alumno.BecaDeportiva.IdBecaDeportiva = registro.IdBecaDeportiva;

        //                    alumno.BecaDeportiva.NombreDeportiva = registro.NombreDeportiva;

        //                    alumno.BecaEducativa = new ML.BecaEducativa();

        //                    alumno.BecaEducativa.IdBecaEducativa = registro.IdBecaEducativa;

        //                    alumno.BecaEducativa.NombreEducativa = registro.NombreEducativa;

        //                    result.Objects.Add(alumno);
        //                }

        //                result.Correct = true;


        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "Ocurrio un error";
        //            }


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }

        //    return result;
        //}


        public static ML.Result GetById(int IdAlumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.NCastilloAlfaSolucionesContext context = new DL.NCastilloAlfaSolucionesContext())
                {
                    var query = (from OAlumno in context.Alumnos
                                 join OBecaCultural in context.BecaCulturals
                                 on OAlumno.IdBecaCultural equals OBecaCultural.IdBecaCultural
                                 join OBecaDeportiva in context.BecaDeportivas
                                 on OAlumno.IdBecaDeportiva equals OBecaDeportiva.IdBecaDeportiva
                                 join OBecaEducativa in context.BecaEducativas
                                 on OAlumno.IdBecaEducativa equals OBecaEducativa.IdBecaEducativa
                                 where OAlumno.IdAlumno == IdAlumno
                                 select new
                                 {

                                     IdAlumno = OAlumno.IdAlumno,
                                     Nombre = OAlumno.Nombre,
                                     Genero = OAlumno.Genero,
                                     Edad = OAlumno.Edad,
                                     IdBecaCultural = OBecaCultural.IdBecaCultural,
                                     NombreCultural = OBecaCultural.NombreCultural,
                                     IdBecaDeportiva = OBecaDeportiva.IdBecaDeportiva,
                                     NombreDeportiva = OBecaDeportiva.NombreDeportiva,
                                     IdBecaEducativa = OBecaEducativa.IdBecaEducativa,
                                     NombreEducativa = OBecaEducativa.NombreEducativa


                                 }).SingleOrDefault();

                    result.Object = new List<Object>();

                    if(query != null)
                    {
                        ML.Alumno alumno = new ML.Alumno();

                        alumno.IdAlumno = query.IdAlumno;

                        alumno.Nombre = query.Nombre;

                        alumno.Genero = query.Genero;

                        alumno.Edad = query.Edad.Value;

                       

                        alumno.IdBecaCultural = query.IdBecaCultural;

                        alumno.BecaCultural = new ML.BecaCultural();

                        alumno.BecaCultural.NombreCultural = query.NombreCultural;

                       

                        alumno.IdBecaDeportiva = query.IdBecaDeportiva;

                        alumno.BecaDeportiva = new ML.BecaDeportiva();

                        alumno.BecaDeportiva.NombreDeportiva = query.NombreDeportiva;

                       

                        alumno.IdBecaEducativa = query.IdBecaEducativa;

                        alumno.BecaEducativa = new ML.BecaEducativa();

                        alumno.BecaEducativa.NombreEducativa = query.NombreEducativa;

                        result.Object = alumno;

                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error";
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


        public static ML.Result Add(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.NCastilloAlfaSolucionesContext context = new DL.NCastilloAlfaSolucionesContext())
                {
                    DL.Alumno alumnoEntity = new DL.Alumno();

                    alumnoEntity.Nombre = alumno.Nombre;

                    alumnoEntity.Genero = alumno.Genero;

                    alumnoEntity.Edad = alumno.Edad;

                    alumnoEntity.IdBecaCultural = alumno.IdBecaCultural;

                    alumnoEntity.IdBecaDeportiva = alumno.IdBecaDeportiva;

                    alumnoEntity.IdBecaEducativa = alumno.IdBecaEducativa;

                    context.Alumnos.Add(alumnoEntity);

                    int filasAfectadas = context.SaveChanges();

                    if(filasAfectadas > 0)
                    {
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
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            
            
            }

            return result;  

        }

        public static ML.Result Update(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.NCastilloAlfaSolucionesContext context = new DL.NCastilloAlfaSolucionesContext())
                {
                    var query = (from OAlumno in context.Alumnos
                                 where OAlumno.IdAlumno == alumno.IdAlumno
                                 select OAlumno).SingleOrDefault();

                    if(query != null)
                    {
                        query.Nombre = alumno.Nombre;

                        query.Genero = alumno.Genero;

                        query.Edad = alumno.Edad;

                        query.IdBecaCultural = alumno.IdBecaCultural;

                        query.IdBecaDeportiva = alumno.IdBecaDeportiva;

                        query.IdBecaEducativa = alumno.IdBecaEducativa;

                        int filasAfectadas = context.SaveChanges();

                        if(filasAfectadas > 0)
                        {
                            result.Correct = true;
                            
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrio un error";
                        }
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
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }

            return result;
        }

        public static ML.Result Delete(int IdAlumno)
        {
            ML.Result result = new ML.Result(); try
            {
                using(DL.NCastilloAlfaSolucionesContext context = new DL.NCastilloAlfaSolucionesContext())
                {
                    var query = (from OAlumno in context.Alumnos
                                 where OAlumno.IdAlumno == IdAlumno
                                 select OAlumno).First();

                    context.Alumnos.Remove(query);

                    int filasAfectadas = context.SaveChanges();

                    if(filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error";
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