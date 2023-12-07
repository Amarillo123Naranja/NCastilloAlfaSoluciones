using System;
using System.Collections.Generic;

namespace DL
{
    public partial class BecaDeportiva
    {
        public BecaDeportiva()
        {
            Alumnos = new HashSet<Alumno>();
        }

        public int IdBecaDeportiva { get; set; }
        public string? NombreDeportiva { get; set; }

        public virtual ICollection<Alumno> Alumnos { get; set; }
    }
}
