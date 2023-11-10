﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using ProyectoWeb_24AM_2023.Models.Entities;

namespace ProyectoWeb_24AM_2023.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            :base(options) { }
        

        public  virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }
        public virtual DbSet<Articulo> Articulos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Insert en la tabla Rol

            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PkRoles = 1,
                    Nombre = "admin"
                },
                new Rol
                {
                    PkRoles = 2,
                    Nombre = "sa"
                });  


            //Insert en la tabla usuario

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PKUsuario = 1,
                    Nombre = "Maria Jose",
                    Apellido = "Sosa",
                    UserName = "Majo",
                    Password = "1234",
                    FkRol= 1

                });  
        }
    }
}
