namespace Api_Taller_Mecanicos.Models
{// solo es una clase contenedora de los datos de la base de datos.
    public class Mecanicos
    {   
        public int IdMecanico { get; set; }

        public String? Nombre { get; set; }

        public int Edad { get; set; }

        public String? Domicilio { get; set; }

        public String? Titulo { get; set; }

        public String? Especialidad { get; set; }

        public String? SueldoBase { get; set; }

        public String? GratTitulo { get; set; }

        public String? SueldoTotal { get; set; }
    }
}
