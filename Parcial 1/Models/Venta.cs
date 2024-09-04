using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial_1.Models
{
    public class Venta: BaseEntity
    {
        public double totalVenta { get; set; }
        public int cantidad { get; set; }

        [ForeignKey("marca_veh")]
        public int marcaID { get; set; }
        public Vehiculo vehiculoVent { get; set; }
    }
}
