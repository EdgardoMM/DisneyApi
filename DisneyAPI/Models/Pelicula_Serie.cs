using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyAPI.Models
{
    public class Pelicula_Serie
    {
        public int Id { get; set; }
        //public object Imagen { get; set; }
        public string Titulo { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public int Calificacion { get; set; }
        public string Personaje_Asoc { get; set; }
    }
}
