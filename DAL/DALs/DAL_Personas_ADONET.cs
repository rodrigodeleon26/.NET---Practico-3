using DAL.IDALs;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL.DALs
{
    public class DAL_Personas_ADONET : IDAL_Personas
    {
        private string connectionString = "Data Source=Rodrigo\\SQLEXPRESS;Initial Catalog=PRACTICO1;" + 
                                          "Persist Security Info=True;User ID=sa;Password=1234;Encrypt=False";

        //  Connection String: Cadena de conexión a la base de datos
        //  Data Source: Nombre del servidor de base de datos al que estoy conectado
        //  Initial Catalog: Nombre de la base de datos a la que estoy conectado
        //  Persist Security Info: Si es true, la información de seguridad (nombre de usuario y contraseña) se mantiene después de cerrar la conexión.
        //  User ID: Nombre de usuario para autenticar la conexión a la base de datos
        //  Password: Contraseña para autenticar la conexión a la base de datos
        //  Encrypt: Si es true, la conexión se cifra, de lo contrario, no se cifra.
        public void AddPersona(Persona persona)
        {
            string query = "insert into Personas (Documento, Nombres, Apellidso, Telefono, Direccion, FechaDeNacimiento) " +
                           "values (@Documento, @Nombres, @Apellidos, @Telefono, @Direccion, @FechaDeNacimiento)";

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, cn);
                command.Parameters.AddWithValue("@Documento", persona.Documento);
                command.Parameters.AddWithValue("@Nombres", persona.Nombres);
                command.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
                command.Parameters.AddWithValue("@Telefono", persona.Telefono);
                command.Parameters.AddWithValue("@Direccion", persona.Direccion);
                command.Parameters.AddWithValue("@FechaDeNacimiento", persona.FechaDeNacimiento);

                try
                {
                    cn.Open();
                    command.ExecuteNonQuery();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la base de datos: " + ex.Message);
                }
            }
        }

        public void DeletePersona(long id)
        {
            string query = "delete from Personas where Id = @Id";

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, cn);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    cn.Open();
                    command.ExecuteNonQuery();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la base de datos: " + ex.Message);
                }
            }
        }

        public Persona GetPersona(long id)
        {
            Persona persona = new Persona();
            string query = "select * from Personas where Id = @Id";

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, cn);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    cn.Open();
                    SqlDataReader datos = command.ExecuteReader();
                    datos.Read();
                    persona.Id = datos.GetInt32(0);
                    persona.Documento = datos.GetString(1);
                    persona.Nombres = datos.GetString(2);
                    persona.Apellidos = datos.GetString(3);
                    persona.Telefono = datos.GetString(4);
                    persona.Direccion = datos.GetString(5);
                    persona.FechaDeNacimiento = DateOnly.FromDateTime(datos.GetDateTime(6));
                    cn.Close();
                    datos.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la base de datos: " + ex.Message);
                }
            }

            return persona;
        }

        public List<Persona> GetPersonas()
        {
            List<Persona> personas = new List<Persona>();

            string query = "select * from Personas";

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, cn);

                try
                {
                    cn.Open();
                    SqlDataReader datos = command.ExecuteReader();
                    while (datos.Read())
                    {

                        Persona persona = new Persona();
                        persona.Id = datos.GetInt32(0);
                        persona.Documento = datos.GetString(1);
                        persona.Nombres = datos.GetString(2);
                        persona.Apellidos = datos.GetString(3);
                        persona.Telefono = datos.GetString(4);
                        persona.Direccion = datos.GetString(5);
                        persona.FechaDeNacimiento = DateOnly.FromDateTime(datos.GetDateTime(6));
                        personas.Add(persona);
                    }
                    datos.Close();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la base de datos: " + ex.Message);
                }
            }

            return personas;
        }

        public void UpdatePersona(Persona persona)
        {
            string query = "update Personas set Nombres = @Nombres, Documento = @Documento, Apellidos = @Apellidos, Telefono = @Telefono, Direccion = @Direccion, FechaDeNacimiento = @FechaDeNacimiento where Id = @Id";

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, cn);
                command.Parameters.AddWithValue("@Id", persona.Id);
                command.Parameters.AddWithValue("@Documento", persona.Documento);
                command.Parameters.AddWithValue("@Nombres", persona.Nombres);
                command.Parameters.AddWithValue("@Apellidos", persona.Apellidos);
                command.Parameters.AddWithValue("@Telefono", persona.Telefono);
                command.Parameters.AddWithValue("@Direccion", persona.Direccion);
                command.Parameters.AddWithValue("@FechaDeNacimiento", persona.FechaDeNacimiento);

                try
                {
                    cn.Open();
                    command.ExecuteNonQuery();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la base de datos: " + ex.Message);
                }
            }
        }
    }
}