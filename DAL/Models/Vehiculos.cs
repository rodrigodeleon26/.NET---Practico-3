using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DAL.Models
{
    public class Vehiculos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]

        [MaxLength(128), MinLength(3), Required]
        public long Id { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Marca { get; set; } = "";

        [MaxLength(128), MinLength(3), Required]
        public string Modelo { get; set; } = "";

        [MaxLength(128), MinLength(3), Required]
        public string Matricula { get; set; } = "";

        public virtual Personas Persona { get; set; }
    }
}
