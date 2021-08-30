using flo.desarrollo.prueba.entidades.Articulo;
using flo.desarrollo.prueba.entidades.Fabricante;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace flo.desarrollo.prueba.datos
{
    /// <summary>
    /// Clase para gestionar conexion a base de datos
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Fabricante> Fabricante { get; set; }
        public DbSet<Articulo> Articulo { get; set; }

    }
}
