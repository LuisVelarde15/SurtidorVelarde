using APIWebVelarde.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebVelarde.Helpers
{
    public class Datos : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; } //Tabla categoria de la base de datos
        public DbSet<Roles> Roles { get; set; } //Tabla Roles de la base de datos
        public DbSet<Clientes> Clientes { get; set; } //Tabla Clietnes de la base de datos
        public DbSet<Provedores> Proveedores { get; set; } //Tabla Provedores les de la base de datos
        public DbSet<Producto> Productos { get; set; } //Tabla Provedores les de la base de datos

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string Conexion = @"Server =surtidorvelarde.database.windows.net;
                                Database = surtidorvelardedb; 
                                User = admindb; 
                                Password =luis1598*;";
                             /*@"Server = surtidor.database.windows.net;
                                Database = surtidordb;
                                User = admindb;
                                Password = 12AB34cd*;";*/ // Servidor Maestro Beltran
            optionsBuilder.UseSqlServer(Conexion);
        }
    }
}
