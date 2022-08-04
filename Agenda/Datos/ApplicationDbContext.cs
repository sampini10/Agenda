using Agenda.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Datos
{
    public class ApplicationDbContext : DbContext //Busca en la base de datos
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //constructor queda asi

        {

        }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Contacto> Contacto { get; set; }
    }
}
