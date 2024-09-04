namespace Parcial_1.Models
{
    public class BaseEntity
    {
        public int id { get; set; }
        public DateTime fechaCreado { get; set; }
        public DateTime fechaModificado { get; set; }

        public bool activo { get; set; }
    }
}
