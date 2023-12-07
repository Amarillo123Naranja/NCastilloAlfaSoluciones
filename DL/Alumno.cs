using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Alumno
    {
        public int IdAlumno { get; set; }
        public string? Nombre { get; set; }
        public string? Genero { get; set; }
        public int? Edad { get; set; }
        public int? IdBecaCultural { get; set; }
        public int? IdBecaDeportiva { get; set; }
        public int? IdBecaEducativa { get; set; }

        public string NombreCultural { get; set; }  

        public string NombreDeportiva { get; set; } 

        public string NombreEducativa { get; set; }

        public virtual BecaCultural? IdBecaCulturalNavigation { get; set; }
        public virtual BecaDeportiva? IdBecaDeportivaNavigation { get; set; }
        public virtual BecaEducativa? IdBecaEducativaNavigation { get; set; }
    }
}
