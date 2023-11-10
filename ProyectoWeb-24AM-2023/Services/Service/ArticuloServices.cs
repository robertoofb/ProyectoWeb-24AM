﻿using Microsoft.EntityFrameworkCore;
using ProyectoWeb_24AM_2023.Context;
using ProyectoWeb_24AM_2023.Models.Entities;
using ProyectoWeb_24AM_2023.Services.IServices;

namespace ProyectoWeb_24AM_2023.Services.Service
{
    public class ArticuloServices : IArticuloServices
    {
        private readonly ApplicationDbContext _context;
        public ArticuloServices(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<List<Articulo>> GetArticulos()
        {
            try
            {
                
                 return await _context.Articulos.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error"+ex.Message);
            }

        }

        public async Task<Articulo> GetByIdArticulo(int id)
        {
            try
            {
                //Articulo response = await _context.Articulos.FindAsync(id);

                Articulo response = await _context.Articulos.FirstOrDefaultAsync(x => x.PkArticulo == id);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }

        public async Task<Articulo> CrearArticulo(Articulo i)
        {
            try
            {
                Articulo request = new Articulo() 
                {
                    Nombre = i.Nombre,  
                    Descripcion = i.Descripcion,
                    Precio = i.Precio,
                };

                var result =  _context.Articulos.Add(request);
                                await _context.SaveChangesAsync();

                return request;
                            

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }

        public async Task<Articulo> ActualizarArticulo(Articulo i)
        {
            try
            {
                Articulo request = _context.Articulos.Find(i.PkArticulo);
                request.Nombre = i.Nombre;
                request.Descripcion = i.Descripcion;
                request.Precio = i.Precio;

                var result = _context.Articulos.Update(request);
                await _context.SaveChangesAsync();

                return request;


            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }

        public async Task<Articulo> EliminarArticulo(Articulo i)
        {
            try
            {
                Articulo request = _context.Articulos.Find(i);

                if (request != null)
                {
                    var result = _context.Articulos.Remove(request);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("No existe el registro");
                }
                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }

    }
}
