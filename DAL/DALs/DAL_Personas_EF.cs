using System;
using System.Collections.Generic;
using System.Linq;
using DAL.IDALs;
using Shared;

namespace DAL
{
    public class DAL_Personas_EF : IDAL_Personas
    {
        private DBContext _dbContext;

        public DAL_Personas_EF(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddPersona(Persona persona)
        {
            _dbContext.Personas.Add(new Models.Personas
            {
                Documento = persona.Documento,
                Nombres = persona.Nombres,
                Apellidos = persona.Apellidos,
                Telefono = persona.Telefono,
                Direccion = persona.Direccion,
                FechaDeNacimiento = persona.FechaDeNacimiento
            });
            _dbContext.SaveChanges();
        }

        public void DeletePersona(long id)
        {
            var persona = _dbContext.Personas.FirstOrDefault(p => p.Id == id);
            if (persona != null)
            {
                _dbContext.Personas.Remove(persona);
                _dbContext.SaveChanges();
            }
        }

        public Persona GetPersona(long id)
        {
            return _dbContext.Personas
                .Where(p => p.Id == id)
                .Select(p => new Persona
                {
                    Id = p.Id,
                    Documento = p.Documento,
                    Nombres = p.Nombres,
                    Apellidos = p.Apellidos,
                    Telefono = p.Telefono,
                    Direccion = p.Direccion,
                    FechaDeNacimiento = p.FechaDeNacimiento
                }).FirstOrDefault();
        }

        public List<Persona> GetPersonas()
        {
            return _dbContext.Personas
                .Select(p => new Persona
                {
                    Id = p.Id,
                    Documento = p.Documento,
                    Nombres = p.Nombres,
                    Apellidos = p.Apellidos,
                    Telefono = p.Telefono,
                    Direccion = p.Direccion,
                    FechaDeNacimiento = p.FechaDeNacimiento
                }).ToList();
        }

        public void UpdatePersona(Persona persona)
        {
            var existingPersona = _dbContext.Personas.FirstOrDefault(p => p.Id == persona.Id);
            if (existingPersona != null)
            {
                existingPersona.Documento = persona.Documento;
                existingPersona.Nombres = persona.Nombres;
                existingPersona.Apellidos = persona.Apellidos;
                existingPersona.Telefono = persona.Telefono;
                existingPersona.Direccion = persona.Direccion;
                existingPersona.FechaDeNacimiento = persona.FechaDeNacimiento;

                _dbContext.SaveChanges();
            }
        }
    }
}
