using DAL.IDALs;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DALs
{
    public class DAL_Personas_Mock : IDAL_Personas
    {
        private long lastId = 7;

        private List<Persona> personas = new List<Persona>
        {
            new Persona { Id = 1, Documento = "1234567", Nombres = "Juan", Apellidos = "Perez", Telefono = "1234567", Direccion = "Calle 123", FechaDeNacimiento = new DateOnly(1990, 1, 1) },
            new Persona { Id = 2, Documento = "7654321", Nombres = "Maria", Apellidos = "Lopez", Telefono = "7654321", Direccion = "Calle 321", FechaDeNacimiento = new DateOnly(1995, 1, 1) },
            new Persona { Id = 3, Documento = "1234567", Nombres = "Pedro", Apellidos = "Gomez", Telefono = "1234567", Direccion = "Calle 123", FechaDeNacimiento = new DateOnly(1990, 1, 1) },
            new Persona { Id = 4, Documento = "7654321", Nombres = "Ana", Apellidos = "Garcia", Telefono = "7654321", Direccion = "Calle 321", FechaDeNacimiento = new DateOnly(1995, 1, 1) },
            new Persona { Id = 5, Documento = "1234567", Nombres = "Carlos", Apellidos = "Martinez", Telefono = "1234567", Direccion = "Calle 123", FechaDeNacimiento = new DateOnly(1990, 1, 1) },
            new Persona { Id = 6, Documento = "7654321", Nombres = "Laura", Apellidos = "Rodriguez", Telefono = "7654321", Direccion = "Calle 321", FechaDeNacimiento = new DateOnly(1995, 1, 1) },
            new Persona { Id = 7, Documento = "1234567", Nombres = "Jorge", Apellidos = "Hernandez", Telefono = "1234567", Direccion = "Calle 123", FechaDeNacimiento = new DateOnly(1990, 1, 1) }

        };

        public void AddPersona(Persona persona)
        {
            lastId++;
            persona.Id = lastId;
            personas.Add(persona);
        }

        public void DeletePersona(long id)
        {
            personas.RemoveAll(p => p.Id == id);
        }

        public Persona GetPersona(long id)
        {
            return personas.FirstOrDefault(p => p.Id == id);
        }

        public List<Persona> GetPersonas()
        {
            return personas;
        }

        public void UpdatePersona(Persona persona)
        {
            Persona p = personas.FirstOrDefault(p => p.Id == persona.Id);
            p.Documento = persona.Documento;
            p.Nombres = persona.Nombres;
            p.Apellidos = persona.Apellidos;
            p.Telefono = persona.Telefono;
            p.Direccion = persona.Direccion;
            p.FechaDeNacimiento = persona.FechaDeNacimiento;
        }
    }
}
