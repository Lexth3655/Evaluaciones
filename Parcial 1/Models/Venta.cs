using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial_1.Models
{
    public class Venta: BaseEntity
    {
        public double totalVenta { get; set; }
        public int cantidad { get; set; }

        [ForeignKey("venta_veh")]
        public int vehiculoID { get; set; }
        public Vehiculo vehiculoVent { get; set; }
    }
}
