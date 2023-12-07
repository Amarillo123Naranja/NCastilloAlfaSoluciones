using System;
using System.Collections.Generic;

namespace DL
{
    public partial class BecaEducativa
    {
        public BecaEducativa()
        {
            Alumnos = new HashSet<Alumno>();
        }

        public int IdBecaEducativa { get; set; }
        public string? NombreEducativa { get; set; }

        public virtual ICollection<Alumno> Alumnos { get; set; }
    }
}
