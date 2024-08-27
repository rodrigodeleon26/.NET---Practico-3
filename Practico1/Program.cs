using DAL.DALs;
using DAL.IDALs;
using Shared;

IDAL_Personas dal = new DAL_Personas_Mock();

string comando = "NUEVA";

Console.WriteLine("Bienvenido a mi primera app .NET!!!");

do
{
    Console.WriteLine("Ingrese comando (NUEVA/IMPRIMIR/ACTUALIZAR/BORRAR/EXIT): ");

    try
    {
        comando = Console.ReadLine().ToUpper();

        switch (comando)
        {
            case "NUEVA":

                Persona persona = new Persona();
                Console.WriteLine("Ingrese el nombre de la persona: ");
                persona.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el documento de la persona: ");
                persona.Documento = Console.ReadLine();
                dal.AddPersona(persona);
                break;

            case "IMPRIMIR":

                Console.WriteLine("Ingrese Nombre o Documento:");
                string filtro = Console.ReadLine();

                List<Persona> filtradas = 
                    dal.GetPersonas().Where(p => p.Nombre.Contains(filtro) || p.Documento.Contains(filtro))
                            .OrderBy(p => p.Nombre)
                            .ToList();

                foreach (Persona p in filtradas)
                    Console.WriteLine(p.GetString());
                break;

            case "EXIT":
                break;

            default:
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
Console.ReadLine();