using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial_1.Models
{
    public class Usuario: BaseEntity
    {
        public string usuario { get; set; }
        public string clave { get; set;}

        [ForeignKey("roles")]
        public int rolID { get; set; }
        public Roles rolesU { get; set; }

    }
}
