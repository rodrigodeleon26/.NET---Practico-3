namespace Shared
{
    public class Persona
    {
        public long Id { get; set; }

        private string documento = "";

        public string Documento
        {
            get
            {
                return documento;
            }
            set
            {
                if (value.Length < 7)
                    throw new Exception("Formato de documento incorrecto.");
                else
                    documento = value.ToUpper();
            }
        }

        public string Nombres { get; set; } = "-- Sin Nombre --";

        public string Apellidos { get; set; } = "-- Sin Apellidos --";

        public string Telefono { get; set; } = "-- Sin Teléfono --";

        public string Direccion { get; set; } = "-- Sin Dirección --";

        public DateOnly FechaDeNacimiento { get; set; } = new DateOnly();


        public string GetString()
        {
            return $"Id: {Id}, Documento: {documento}, Nombre: {Nombres}, Apellido: {Apellidos}, Teléfono: {Telefono}, Dirección: {Direccion}, Fecha de Nacimiento: {FechaDeNacimiento}";
        }
    }
}
