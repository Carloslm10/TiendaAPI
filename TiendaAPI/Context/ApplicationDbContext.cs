﻿using Microsoft.EntityFrameworkCore;
using TiendaAPI.Entities;

namespace TiendaAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Venta> Ventas { get; set; }

        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options)
        {

        }
    }
}
