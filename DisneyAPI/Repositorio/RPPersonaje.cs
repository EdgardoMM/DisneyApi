using DisneyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyAPI.Repositorio
{
    public class RPPersonaje
    {
        public static List<Personaje> _listado = new List<Personaje>()
        {
            new Personaje(){Id = 1, Nombre = "Mickey Mouse", Edad = 93, Historia = "Personaje original de Walt Disney" },
            new Personaje(){Id = 2, Nombre = "Pato Donald", Edad = 87, Historia = "Personaje original de Walt Disney" },
            new Personaje(){Id = 3, Nombre = "Goofy", Edad = 89, Historia = "Personaje original de Walt Disney" }
        };

        public IEnumerable<Personaje> ObtenerPersonaje()
        {
            return _listado;
        }

    }
}
