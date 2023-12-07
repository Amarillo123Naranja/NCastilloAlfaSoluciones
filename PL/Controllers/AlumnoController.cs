using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class AlumnoController : Controller
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            //Instanciamos
            ML.Alumno alumno = new ML.Alumno();
            alumno.BecaCultural = new ML.BecaCultural();
            alumno.BecaDeportiva = new ML.BecaDeportiva();
            alumno.BecaEducativa = new ML.BecaEducativa();
            alumno.Nombre = "";
            alumno.BecaCultural.IdBecaCultural = 0;
            alumno.BecaDeportiva.IdBecaDeportiva = 0;
            alumno.BecaEducativa.IdBecaEducativa = 0;


            //Mandamos a llamar a los metodos
            ML.Result result = BL.Alumno.GetAll(alumno.Nombre, alumno.BecaCultural.IdBecaCultural, alumno.BecaDeportiva.IdBecaDeportiva, alumno.BecaEducativa.IdBecaEducativa);
            ML.Result resultCultural = BL.BecaCultural.GetAll();
            ML.Result resultDeportiva = BL.BecaDeportiva.GetAll();
            ML.Result resultEducativa = BL.BecaEducativa.GetAll();


            //Traemos a la vista el resultado
            alumno.Alumnos = result.Objects;
            alumno.BecaCultural.BecasCulturales = resultCultural.Objects;
            alumno.BecaDeportiva.BecasDeportivas = resultDeportiva.Objects;
            alumno.BecaEducativa.BecasEducativas = resultEducativa.Objects;

            return View(alumno);
        }

        [HttpPost]
        public IActionResult GetAll(string nombre, int IdBecaCultural, int IdBecaDeportiva, int IdBecaEducativa)
        {

            //Instanciamos
            ML.Alumno alumno = new ML.Alumno();
            alumno.BecaCultural = new ML.BecaCultural();
            alumno.BecaDeportiva = new ML.BecaDeportiva();
            alumno.BecaEducativa = new ML.BecaEducativa();

            if(alumno.Nombre == null)
            {
                alumno.Nombre = "";
            }
            if(alumno.BecaCultural.IdBecaCultural == 0)
            {
                alumno.BecaCultural.IdBecaCultural = 0;
            }
            if (alumno.BecaDeportiva.IdBecaDeportiva == 0)
            {
                alumno.BecaDeportiva.IdBecaDeportiva = 0;
                
            }
            if(alumno.BecaEducativa.IdBecaEducativa == 0)
            {
                alumno.BecaEducativa.IdBecaEducativa = 0; 

            }


            //Mandamos a llamar a los metodos
            ML.Result result = BL.Alumno.GetAll(nombre, IdBecaCultural, IdBecaDeportiva, IdBecaEducativa);
            ML.Result resultCultural = BL.BecaCultural.GetAll();
            ML.Result resultDeportiva = BL.BecaDeportiva.GetAll();
            ML.Result resultEducativa = BL.BecaEducativa.GetAll();


            //Traemos a la vista el resultado
            alumno.Alumnos = result.Objects;
            alumno.BecaCultural.BecasCulturales = resultCultural.Objects;
            alumno.BecaDeportiva.BecasDeportivas = resultDeportiva.Objects;
            alumno.BecaEducativa.BecasEducativas = resultEducativa.Objects;

            return View(alumno);


        }



        //API REST
        //http://localhost:5112

        //public IActionResult GetAll()
        //{
        //    ML.Alumno alumno = new ML.Alumno();
        //    alumno.Alumnos = new List<Object>();

        //    //Llamando al servicio
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:5112/api/");
        //        var responseTask = client.GetAsync("alumno/getall");
        //        responseTask.Wait();

        //        var resultServicio = responseTask.Result;

        //        if (resultServicio.IsSuccessStatusCode)
        //        {
        //            var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
        //            readTask.Wait();

        //            foreach (var resultAlumno in readTask.Result.Objects)
        //            {
        //                ML.Alumno resultItem = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Alumno>(resultAlumno.ToString());   
        //                alumno.Alumnos.Add(resultItem); 

        //            }

        //        }

        //    }

        //    return View(alumno);    

        //}




        //[HttpGet]
        //public IActionResult Form(int? IdAlumno) 
        //{
        //    ML.Alumno alumno = new ML.Alumno();
        //    alumno.BecaCultural = new ML.BecaCultural();
        //    alumno.BecaDeportiva = new ML.BecaDeportiva();
        //    alumno.BecaEducativa = new ML.BecaEducativa();

        //    ML.Result resultCultural = BL.BecaCultural.GetAll();
        //    ML.Result resultDeportiva = BL.BecaDeportiva.GetAll();
        //    ML.Result resultEducativa = BL.BecaEducativa.GetAll();

        //    if(IdAlumno != null) 
        //    {
        //        ML.Result result = BL.Alumno.GetById(IdAlumno.Value);

        //        if (result.Correct)
        //        {
        //            alumno = (ML.Alumno)result.Object;
        //            alumno.BecaCultural.BecasCulturales = resultCultural.Objects;
        //            alumno.BecaDeportiva.BecasDeportivas = resultDeportiva.Objects;
        //            alumno.BecaEducativa.BecasEducativas = resultEducativa.Objects;

        //        }

        //    }
        //    else
        //    {

        //        alumno.BecaCultural.BecasCulturales = resultCultural.Objects;
        //        alumno.BecaDeportiva.BecasDeportivas = resultDeportiva.Objects;
        //        alumno.BecaEducativa.BecasEducativas = resultEducativa.Objects;

        //    }

        //    return View(alumno);
        //}


        //API REST

        [HttpGet]
        public IActionResult Form(int? IdAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();
            alumno.BecaCultural = new ML.BecaCultural();
            alumno.BecaDeportiva = new ML.BecaDeportiva();
            alumno.BecaEducativa = new ML.BecaEducativa();

            ML.Result resultCultural = BL.BecaCultural.GetAll();
            ML.Result resultDeportiva = BL.BecaDeportiva.GetAll();
            ML.Result resultEducativa = BL.BecaEducativa.GetAll();

            if (IdAlumno != null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5112/api/");
                    var responseTask = client.GetAsync("alumno/getbyid/" + IdAlumno);
                    responseTask.Wait();

                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                      var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        ML.Alumno resultItem = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Alumno>(readTask.Result.Object.ToString());
                        alumno = resultItem;



                    }

                }

                alumno.BecaCultural.BecasCulturales = resultCultural.Objects;
                alumno.BecaDeportiva.BecasDeportivas = resultDeportiva.Objects;
                alumno.BecaEducativa.BecasEducativas = resultEducativa.Objects;

            }
            else
            {

                alumno.BecaCultural.BecasCulturales = resultCultural.Objects;
                alumno.BecaDeportiva.BecasDeportivas = resultDeportiva.Objects;
                alumno.BecaEducativa.BecasEducativas = resultEducativa.Objects;

            }

            return View(alumno);
        }


        //[HttpPost]  
        //public IActionResult Form(ML.Alumno alumno)
        //{
        //    if(alumno.IdAlumno == 0) 
        //    {
        //        ML.Result result = BL.Alumno.Add(alumno);

        //        if (result.Correct)
        //        {
        //            ViewBag.Mensaje = "Agregado!!";
        //        }
        //        else
        //        {
        //            ViewBag.Mensaje = "Ocurrio un error";
        //        }

        //    }
        //    else
        //    {
        //        ML.Result result = BL.Alumno.Update(alumno);

        //        if (result.Correct)
        //        {
        //            ViewBag.Mensaje = "Actualizado!!";
        //        }
        //        else
        //        {
        //            ViewBag.Mensaje = "Ocurrio un error";
        //        }
        //    }

        //    return PartialView("Modal");


        //}


        //API REST

        [HttpPost]
        public IActionResult Form(ML.Alumno alumno)
        {
            if (alumno.IdAlumno == 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5112/api/");

                    var postTask = client.PostAsJsonAsync<ML.Alumno>("alumno/add", alumno);
                    postTask.Wait();

                    var resultServicio = postTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Agregado";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Ocurrio un error";

                    }

                }

            }
            else
            {

                int IdAlumno = alumno.IdAlumno;

                using(var client = new HttpClient()) 
                {
                    client.BaseAddress = new Uri("http://localhost:5112/api/");
                    var putTask = client.PutAsJsonAsync<ML.Alumno>("alumno/" + IdAlumno, alumno);
                    putTask.Wait();

                    var resultServicio = putTask.Result;

                    if(resultServicio.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Actualizado";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error!!";
                    }
                
                
                }

            }

            return PartialView("Modal");

        }

        [HttpGet]

        public IActionResult Delete(int IdAlumno)
        {
            using(var client = new HttpClient()) 
            {
                client.BaseAddress = new Uri("http://localhost:5112/api/");
                var deleteTask = client.DeleteAsync("alumno/" + IdAlumno);
                deleteTask.Wait();

                var resultServicio = deleteTask.Result; 

                if(resultServicio.IsSuccessStatusCode) 
                {

                    ViewBag.Mensaje = "Eliminado";

                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un error";
                }

            }


            return PartialView("Modal");

        }

    }
}
