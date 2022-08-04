using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Modelos
{
    public class Contacto
    {
        [Key]//Se convierte id, en dato entero y autoincrementar, no hay dos datos iguales.
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de contacto es obligatorio")]//Requerido y con un error de mensaje
        [StringLength(15, ErrorMessage = "{0} el nombre debe tener entre {2} y {1}", MinimumLength = 4)]// Solicito que el ingreso sea mayor a 4 caracteres y maximo 15
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]//Requerido y con un error de mensaje
        public string Email { get; set; }

        [Required(ErrorMessage = "El telefono es obligatorio")]//Requerido y con un error de mensaje
        public string Telefono { get; set; }

        [DataType(DataType.Date)]//indico que es un dato de fecha 
        [Display(Name = "Fecha de creación")]//añadir display name
        public DateTime? FechaCreacion { get; set; } // ? indica que puede ser null

        [Required]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

    }
}
