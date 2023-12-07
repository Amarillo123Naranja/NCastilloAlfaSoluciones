namespace ML
{
    public class Alumno
    {

        public int IdAlumno { get; set; }   

        public string Nombre { get; set; }  

        public string Genero { get; set; }  
        public int Edad { get; set; }   

        public int IdBecaCultural { get; set; } 

        public int IdBecaDeportiva { get; set; }    

        public int IdBecaEducativa { get; set; }  

        public List<Object> Alumnos { get; set; }   
        
        public ML.BecaCultural BecaCultural { get; set; }   

        public ML.BecaDeportiva BecaDeportiva { get; set; }

        public ML.BecaEducativa BecaEducativa { get; set; }

    }
}