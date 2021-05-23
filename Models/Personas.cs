using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RegistroPrestamo.Models
{
    public class Personas
    {
        [Key]
        [Required(ErrorMessage = "No debe de estar Vacío el campo 'PersonaId'")]
        [Range(0, 100, ErrorMessage = "El campo 'PersonaId' no puede ser 0 o (mayor a 1000).")]
        public int PersonaId { set; get; }

        [Required(ErrorMessage = "No debe de estar Vacío el campo 'Nombre'")]
        [MaxLength(50, ErrorMessage = "El Campo 'Nombres' es muy largo.")]
        [MinLength(4, ErrorMessage = "El Campo 'Nombres' debe tener por lo menos (4 caracteres).")]
        [RegularExpression(@"\S(.*)\S", ErrorMessage = "Debe ser un texto.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "No debe de estar Vacío el campo 'Telefono'")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Por favor ingrese un No. de Teléfono válido.")]
        [MaxLength(10, ErrorMessage = "El campo 'Telefono' no tiene más de diez dígitos.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "No debe de estar Vacío el campo 'Cedula'")]
        [RegularExpression("^\\d{3}\\D?\\d{7}\\D?\\d$", ErrorMessage = "Por favor ingrese un No. de Cedula válido.")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "No debe de estar Vacío el campo 'Dirección'")]
        [MinLength(10, ErrorMessage = "La dirección bebe tener minimo (10 caracteres).")]
        [MaxLength(100, ErrorMessage = "La dirección debe tener Maximo (100 caracteres).")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "No debe de estar Vacío el campo 'Fecha")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd,mm,yyyy}")]
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;

        public double Balance { get; set; }
    }
}
