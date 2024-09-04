using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial_1.Models
{
    public class Empleado
    {
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string direccion {  get; set; }

        [ForeignKey("tipo_emp")]

        public int tipoEmpid { get; set; } // Tipo de Empleado

        public Tipo_Empleado tipo_Empleado { get; set; }

    }
}
