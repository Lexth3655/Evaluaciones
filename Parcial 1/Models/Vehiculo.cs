using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial_1.Models
{
    public class Vehiculo: BaseEntity
    {
        public string modelo { get; set; }
        public int anio { get; set; }
        public int cantidadPuertas { get; set; }

        [ForeignKey("marca_veh")]
        public int marcaID { get; set; }
        public Marca marcaVeh{ get; set; }
    }
}
