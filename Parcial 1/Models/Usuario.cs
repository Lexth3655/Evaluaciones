using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial_1.Models
{
    public class Usuario: BaseEntity
    {
        public string usuario { get; set; }
        public string clave { get; set;}

        [ForeignKey("Empleado")]
        public int empID { get; set; }
        public Empleado empleado { get; set; }

    }
}
