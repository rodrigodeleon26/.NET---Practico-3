using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.IDALs;
using Shared;

namespace DAL.DALs
{
    public class DAL_Vehiculos_EF : IDAL_Vehiculos
    {
        //private DBContext _dbContext;

        //public DAL_Vehiculos_EF(DBContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        public void AddVehiculo(Vehiculo vehiculo)
        {
            using (var context = new DBContext())
            {
                context.Vehiculos.Add(new Models.Vehiculos
                {
                    Marca = vehiculo.Marca,
                    Modelo = vehiculo.Modelo,
                    Matricula = vehiculo.Matricula,
                    Persona = context.Personas.FirstOrDefault(p => p.Id == vehiculo.Persona.Id)
                });
                context.SaveChanges();
            }
        }

        public void DeleteVehiculo(long id)
        {
            using (var context = new DBContext())
            {
                var vehiculo = context.Vehiculos.FirstOrDefault(v => v.Id == id);
                if (vehiculo != null)
                {
                    context.Vehiculos.Remove(vehiculo);
                    context.SaveChanges();
                }
            }
        }

        public Vehiculo GetVehiculo(long id)
        {
            using (var context = new DBContext())
            {
                return context.Vehiculos
                              .Where(v => v.Id == id)
                              .Select(v => new Vehiculo
                              {
                                  Id = v.Id,
                                  Marca = v.Marca,
                                  Modelo = v.Modelo,
                                  Matricula = v.Matricula,
                                  Persona = new Persona
                                  {
                                      Id = v.Persona.Id,
                                      Documento = v.Persona.Documento,
                                      Nombres = v.Persona.Nombres,
                                      Apellidos = v.Persona.Apellidos,
                                      Telefono = v.Persona.Telefono,
                                      Direccion = v.Persona.Direccion,
                                      FechaDeNacimiento = v.Persona.FechaDeNacimiento
                                  }
                              }).FirstOrDefault();
            }
        }

        public List<Vehiculo> GetVehiculos()
        {
            using (var context = new DBContext())
            {
                return context.Vehiculos
                              .Select(v => new Vehiculo
                              {
                                  Id = v.Id,
                                  Marca = v.Marca,
                                  Modelo = v.Modelo,
                                  Matricula = v.Matricula,
                                  Persona = new Persona
                                  {
                                      Id = v.Persona.Id,
                                      Documento = v.Persona.Documento,
                                      Nombres = v.Persona.Nombres,
                                      Apellidos = v.Persona.Apellidos,
                                      Telefono = v.Persona.Telefono,
                                      Direccion = v.Persona.Direccion,
                                      FechaDeNacimiento = v.Persona.FechaDeNacimiento
                                  }
                              }
                              ).ToList();
            }
        }
        public void UpdateVehiculo(Vehiculo vehiculo)
        {
            using (var context = new DBContext())
            {
                var vehiculoActualizado = context.Vehiculos.FirstOrDefault(v => v.Id == vehiculo.Id);
                if (vehiculoActualizado != null)
                {
                    vehiculoActualizado.Marca = vehiculo.Marca;
                    vehiculoActualizado.Modelo = vehiculo.Modelo;
                    vehiculoActualizado.Matricula = vehiculo.Matricula;
                    vehiculoActualizado.Persona = context.Personas.FirstOrDefault(p => p.Id == vehiculo.Persona.Id);
                    context.SaveChanges();
                }
            }
        }

        public List<Vehiculo> GetVehiculosByPersona(long id)
        {
            using (var context = new DBContext())
            {
                return context.Vehiculos
                              .Where(v => v.Persona.Id == id)
                              .Select(v => new Vehiculo
                              {
                                  Id = v.Id,
                                  Marca = v.Marca,
                                  Modelo = v.Modelo,
                                  Matricula = v.Matricula,
                                  Persona = new Persona
                                  {
                                      Id = v.Persona.Id,
                                      Documento = v.Persona.Documento,
                                      Nombres = v.Persona.Nombres,
                                      Apellidos = v.Persona.Apellidos,
                                      Telefono = v.Persona.Telefono,
                                      Direccion = v.Persona.Direccion,
                                      FechaDeNacimiento = v.Persona.FechaDeNacimiento
                                  }
                              }).ToList();
            }
        }
    }
}
