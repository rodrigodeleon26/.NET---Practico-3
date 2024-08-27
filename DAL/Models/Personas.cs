using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Personas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]

        [MaxLength(128), MinLength(3), Required]
        public long Id { get; set; }

        [MaxLength(128), MinLength(8), Required]
        public string Documento { get; set; } = "";

        [MaxLength(128), MinLength(3), Required]
        public string Nombres { get; set; } = "";

        [MaxLength(128), MinLength(3), Required]
        public string Apellidos { get; set; } = "";

        [MaxLength(9), MinLength(8), Required]
        public string Telefono { get; set; } = "";

        [MaxLength(128), MinLength(10), Required]
        public string Direccion { get; set; } = "";

        [Required]
        public DateOnly FechaDeNacimiento { get; set; } = new DateOnly();

        public virtual List<Vehiculos> Vehiculos { get; set; }
    }
}
