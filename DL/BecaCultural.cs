using System;
using System.Collections.Generic;

namespace DL
{
    public partial class BecaCultural
    {
        public BecaCultural()
        {
            Alumnos = new HashSet<Alumno>();
        }

        public int IdBecaCultural { get; set; }
        public string? NombreCultural { get; set; }

        public virtual ICollection<Alumno> Alumnos { get; set; }
    }
}
