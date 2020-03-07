using Microsoft.EntityFrameworkCore;
using RegistroConSqLite.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroConSqLite.DAL
{
    public class Contexto : DbContext
    {
        public DbSet <Persona> Personas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source = Personas.db");
        }
    }
}
