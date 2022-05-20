using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyAPI.Models
{
    public class Genero
    {
        public string Nombre { get; set; }
        public object Imagen { get; set; }
        public virtual Pelicula_Serie Peli_Serie { get; set; }
    }
}
