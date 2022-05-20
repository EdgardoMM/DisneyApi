using DisneyAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisneyAPI
{
    public class DisneyContext : DbContext
    {
        public DisneyContext (DbContextOptions<DisneyContext> options) : base(options)
        {

        }

        public DbSet<Personaje> Personajes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Pelicula_Serie> Pelicula_Series { get; set; }

    }
}
