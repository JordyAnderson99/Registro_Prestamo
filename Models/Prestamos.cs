using System;
using System.ComponentModel.DataAnnotations;

namespace RegistroPrestamo.Models
{
    public class Prestamos
    {
        [Key]

        [Required(ErrorMessage = "No debe de estar Vacío el campo 'PrestamoId'")]
        [Range(0, 100, ErrorMessage = "El campo 'PrestamoId' no puede ser 0 o (mayor a 1000).")]
        public int PrestamoId { get; set; }

        [Required(ErrorMessage = "No debe de estar Vacío el campo 'PersonaId'")]
        public int PersonaId { get; set; }

        [Required(ErrorMessage = "No debe de estar Vacío el campo 'Fecha")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd,mm,yyyy}")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Range(minimum: 100, maximum: 1000000)]
        public string Concepto { get; set; }

        [Required(ErrorMessage = "No debe de estar Vacío el campo 'Monto'")]
        public double Monto { get; set; }
        public double Balance { get; set; }

        

    }
}
