using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberEntity.Entity
{
    public class PersonaEntity : BaseEntity
    {
        [Required(ErrorMessage ="Cedula Requerida") ]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "Nombre Requerido")]
        public string Nombre { get; set; }
        public string Celular { get; set; }
        [Required(ErrorMessage = "Correo Requerido")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Contraseña Requerida")]
        public string Contraseña { get; set; }
    }
}
