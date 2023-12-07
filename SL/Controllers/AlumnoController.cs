using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    [Route("api/alumno")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {

        [Route("add")]
        [HttpPost]

        public IActionResult Add(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Add(alumno);

            if (result.Correct)
            {
                return StatusCode(200, result);
            }
            else
            {
                return StatusCode(400, result);
            }
        }

        [Route("{IdAlumno}")]
        [HttpPut]
        
        public IActionResult Update(int IdAlumno, [FromBody] ML.Alumno alumno) 
        {
            alumno.IdAlumno = IdAlumno;

            ML.Result result = BL.Alumno.Update(alumno);

            if (result.Correct)
            {
                return StatusCode(200, result); 
            }
            else
            {
                return StatusCode(400, result);
            }
        
        
        }

        [Route("{IdAlumno}")]
        [HttpGet]
        
        public IActionResult Delete(int IdAlumno)
        {
            ML.Result result = BL.Alumno.Delete(IdAlumno);

            if (result.Correct)
            {
                return StatusCode(200, result); 
            }
            else
            {
                return StatusCode(400, result);
            }
        }

        [Route("getall")]
        [HttpGet]   

        //public IActionResult GetAll()
        //{
        //    ML.Result result = BL.Alumno.GetAll();

        //    if (result.Correct)
        //    {
        //        return StatusCode(200, result); 
        //    }
        //    else
        //    {
        //        return StatusCode(400, result);
        //    }
        //}

        [Route("getbyid/{IdAlumno}")]
        [HttpGet]
        
        public IActionResult GetById(int IdAlumno) 
        {
            ML.Result result = BL.Alumno.GetById(IdAlumno);

            if (result.Correct)
            {
                return StatusCode(200, result); 
            }
            else
            {
                return StatusCode(400, result);
            }

        }


    }
}
