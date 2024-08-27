using DAL;
using DAL.DALs;
using DAL.IDALs;
using Practico1;
using Shared;

using (var context = new DBContext())
{
    IDAL_Personas dalP = new DAL_Personas_EF(context);
    IDAL_Vehiculos dalV = new DAL_Vehiculos_EF(context);
    Startup startup = new Startup();
    startup.UpdateDatabase();

    string comando = "NUEVA";

    Console.WriteLine("Bienvenido a mi primera app .NET!!!\n");

    do
    {
        Console.WriteLine("\tNUEVA_P: Agregar persona");
        Console.WriteLine("\tIMPRIMIR_P: Listar personas");
        Console.WriteLine("\tACTUALIZAR_P: Actualizar persona");
        Console.WriteLine("\tBORRAR_P: Borrar persona");
        Console.WriteLine("\t----------------------------------");

        Console.WriteLine("\tNUEVO_V: Agregar vehiculo");
        Console.WriteLine("\tIMPRIMIR_V: Listar vehiculos");
        Console.WriteLine("\tACTUALIZAR_V: Actualizar vehiculo");
        Console.WriteLine("\tBORRAR_V: Borrar vehiculo\n");

        Console.WriteLine("\tEXIT: Salir");
        try
        {
            Console.WriteLine("\nIngrese comando: ");
            comando = Console.ReadLine().ToUpper();

            switch (comando)
            {
                case "NUEVA_P":
                    Console.Clear();
                    Persona persona = new Persona();
                    Console.WriteLine("Ingrese el documento de la persona: ");
                    persona.Documento = Console.ReadLine();
                    Console.WriteLine("Ingrese el nombre de la persona: ");
                    persona.Nombres = Console.ReadLine();
                    Console.WriteLine("Ingrese el apellido de la persona: ");
                    persona.Apellidos = Console.ReadLine();
                    Console.WriteLine("Ingrese el telefono de la persona: ");
                    persona.Telefono = Console.ReadLine();
                    Console.WriteLine("Ingrese la dirección de la persona: ");
                    persona.Direccion = Console.ReadLine();
                    Console.WriteLine("Ingrese la fecha de nacimiento de la persona: ");
                    persona.FechaDeNacimiento = DateOnly.Parse(Console.ReadLine());
                    dalP.AddPersona(persona);
                    Console.WriteLine("Persona agregada.");
                    break;

                case "IMPRIMIR_P":
                    Console.Clear();
                    Console.WriteLine("Ingrese Nombre o Documento:");
                    string filtro = Console.ReadLine();

                    List<Persona> filtradas =
                        dalP.GetPersonas().Where(p => p.Nombres.Contains(filtro) || p.Documento.Contains(filtro))
                                .OrderBy(p => p.Nombres)
                                .ToList();

                    foreach (Persona p in filtradas)
                        Console.WriteLine(p.GetString());
                    break;

                case "ACTUALIZAR_P":
                    Console.Clear();
                    foreach (Persona p in dalP.GetPersonas())
                        Console.WriteLine(p.GetString());
                    Console.WriteLine("Ingrese el Id de la persona a actualizar: ");
                    long id = long.Parse(Console.ReadLine());
                    Persona personaActualizada = dalP.GetPersona(id);
                    if (personaActualizada != null)
                    {
                        Console.WriteLine(personaActualizada.GetString());
                        Console.WriteLine("Ingrese el documento de la persona: ");
                        personaActualizada.Documento = Console.ReadLine();
                        Console.WriteLine("Ingrese el nombre de la persona: ");
                        personaActualizada.Nombres = Console.ReadLine();
                        Console.WriteLine("Ingrese el apellido de la persona: ");
                        personaActualizada.Apellidos = Console.ReadLine();
                        Console.WriteLine("Ingrese el telefono de la persona: ");
                        personaActualizada.Telefono = Console.ReadLine();
                        Console.WriteLine("Ingrese la dirección de la persona: ");
                        personaActualizada.Direccion = Console.ReadLine();
                        Console.WriteLine("Ingrese la fecha de nacimiento de la persona: ");
                        personaActualizada.FechaDeNacimiento = DateOnly.Parse(Console.ReadLine());
                        dalP.UpdatePersona(personaActualizada);
                        Console.WriteLine("Persona actualizada.");
                    }
                    else
                        Console.WriteLine("Persona no encontrada.");
                    break;

                case "BORRAR_P":
                    Console.Clear();
                    foreach (Persona p in dalP.GetPersonas())
                        Console.WriteLine(p.GetString());
                    Console.WriteLine("Ingrese el Id de la persona a borrar: ");
                    long idBorrar = long.Parse(Console.ReadLine());
                    if (dalP.GetPersona(idBorrar) != null)
                    {
                        dalP.DeletePersona(idBorrar);
                        Console.WriteLine("Persona borrada.");
                    }
                    else
                        Console.WriteLine("Persona no encontrada.");
                    break;

                case "NUEVO_V":
                    Console.Clear();
                    Vehiculo vehiculo = new Vehiculo();
                    Console.WriteLine("Ingrese la marca del vehiculo: ");
                    vehiculo.Marca = Console.ReadLine();
                    Console.WriteLine("Ingrese el modelo del vehiculo: ");
                    vehiculo.Modelo = Console.ReadLine();
                    Console.WriteLine("Ingrese la matricula del vehiculo: ");
                    vehiculo.Matricula = Console.ReadLine();

                    foreach (Persona p in dalP.GetPersonas())
                        Console.WriteLine(p.GetString());

                    Console.WriteLine("Ingrese el Id de la persona dueña del vehiculo: ");
                    long idPersona = long.Parse(Console.ReadLine());
                    vehiculo.Persona = dalP.GetPersona(idPersona);
                    dalV.AddVehiculo(vehiculo);
                    Console.WriteLine("Vehiculo agregado.");
                    break;

                case "IMPRIMIR_V":
                    Console.Clear();

                    foreach (Persona p in dalP.GetPersonas())
                        Console.WriteLine(p.GetString());

                    Console.WriteLine("Ingrese el Id de la persona para listar sus vehiculos (deje en blanco para listar todos): ");

                    string stringId = Console.ReadLine();
                    List<Vehiculo> vehiculos;

                    if (string.IsNullOrWhiteSpace(stringId))
                    {
                        vehiculos = dalV.GetVehiculos().OrderBy(v => v.Marca).ToList();
                    }
                    else
                    {
                        long idPersonaV = long.Parse(stringId);
                        vehiculos = dalV.GetVehiculosByPersona(idPersonaV).OrderBy(v => v.Marca).ToList();
                    }

                    foreach (Vehiculo v in vehiculos)
                        Console.WriteLine(v.GetString());
                    break;

                case "ACTUALIZAR_V":
                    Console.Clear();
                    foreach (Vehiculo v in dalV.GetVehiculos())
                        Console.WriteLine(v.GetString());
                    Console.WriteLine("Ingrese el Id del vehiculo a actualizar: ");
                    long idV = long.Parse(Console.ReadLine());
                    Vehiculo vehiculoActualizado = dalV.GetVehiculo(idV);
                    if (vehiculoActualizado != null)
                    {
                        Console.WriteLine(vehiculoActualizado.GetString());
                        Console.WriteLine("Ingrese la marca del vehiculo: ");
                        vehiculoActualizado.Marca = Console.ReadLine();
                        Console.WriteLine("Ingrese el modelo del vehiculo: ");
                        vehiculoActualizado.Modelo = Console.ReadLine();
                        Console.WriteLine("Ingrese la matricula del vehiculo: ");
                        vehiculoActualizado.Matricula = Console.ReadLine();

                        foreach (Persona p in dalP.GetPersonas())
                            Console.WriteLine(p.GetString());

                        Console.WriteLine("Ingrese el Id de la persona dueña del vehiculo: ");
                        long idPersonaVe = long.Parse(Console.ReadLine());
                        vehiculoActualizado.Persona = dalP.GetPersona(idPersonaVe);
                        dalV.UpdateVehiculo(vehiculoActualizado);
                        Console.WriteLine("Vehiculo actualizado.");
                    }
                    else
                        Console.WriteLine("Vehiculo no encontrado.");
                    break;

                case "BORRAR_V":
                    Console.Clear();
                    foreach (Vehiculo v in dalV.GetVehiculos())
                        Console.WriteLine(v.GetString());
                    Console.WriteLine("Ingrese el Id del vehiculo a borrar: ");
                    long idBorrarV = long.Parse(Console.ReadLine());
                    if (dalV.GetVehiculo(idBorrarV) != null)
                    {
                        dalV.DeleteVehiculo(idBorrarV);
                        Console.WriteLine("Vehiculo borrado.");
                    }
                    else
                        Console.WriteLine("Vehiculo no encontrado.");
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Comando no reconocido.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


    } while (comando != "EXIT");

 
}

/*do
{
    Console.WriteLine("Ingrese comando (NUEVA/IMPRIMIR/ACTUALIZAR/BORRAR/EXIT): ");

    try
    {
        comando = Console.ReadLine().ToUpper();

        switch (comando)
        {
            case "NUEVA":
                Console.Clear();
                Persona persona = new Persona();
                Console.WriteLine("Ingrese el nombre de la persona: ");
                persona.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el documento de la persona: ");
                persona.Documento = Console.ReadLine();
                dal.AddPersona(persona);
                Console.WriteLine("Persona agregada.");
                break;

            case "IMPRIMIR":
                Console.Clear();
                Console.WriteLine("Ingrese Nombre o Documento:");
                string filtro = Console.ReadLine();

                List<Persona> filtradas =
                    dal.GetPersonas().Where(p => p.Nombre.Contains(filtro) || p.Documento.Contains(filtro))
                            .OrderBy(p => p.Nombre)
                            .ToList();

                foreach (Persona p in filtradas)
                    Console.WriteLine(p.GetString());
                break;

            case "ACTUALIZAR":
                Console.Clear();
                foreach (Persona p in dal.GetPersonas())
                    Console.WriteLine(p.GetString());
                Console.WriteLine("Ingrese el Id de la persona a actualizar: ");
                long id = long.Parse(Console.ReadLine());
                Persona personaActualizada = dal.GetPersona(id);
                if (personaActualizada != null)
                {
                    Console.WriteLine(personaActualizada.GetString());
                    Console.WriteLine("Ingrese el nombre de la persona: ");
                    personaActualizada.Nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el documento de la persona: ");
                    personaActualizada.Documento = Console.ReadLine();
                    dal.UpdatePersona(personaActualizada);
                    Console.WriteLine("Persona actualizada.");
                }
                else
                    Console.WriteLine("Persona no encontrada.");
                break;

            case "BORRAR":
                Console.Clear();
                foreach (Persona p in dal.GetPersonas())
                    Console.WriteLine(p.GetString());
                Console.WriteLine("Ingrese el Id de la persona a borrar: ");
                long idBorrar = long.Parse(Console.ReadLine());
                if (dal.GetPersona(idBorrar) != null) { 
                    dal.DeletePersona(idBorrar);
                    Console.WriteLine("Persona borrada.");
                }
                else
                    Console.WriteLine("Persona no encontrada.");
                break;

            case "EXIT":
                break;

            default:
                Console.Clear();
                Console.WriteLine("Comando no reconocido.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
while (comando != "EXIT");

Console.WriteLine("Hasta luego!!!");
Console.ReadLine();*/