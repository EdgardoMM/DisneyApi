using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DisneyAPI.Models;

namespace DisneyAPI.Data
{
    public class DisneyAPIContext : DbContext
    {
        public DisneyAPIContext (DbContextOptions<DisneyAPIContext> options)
            : base(options)
        {
        }

        public DbSet<DisneyAPI.Models.Personaje> Personaje { get; set; }

        public DbSet<DisneyAPI.Models.Pelicula_Serie> Pelicula_Serie { get; set; }
    }
}
