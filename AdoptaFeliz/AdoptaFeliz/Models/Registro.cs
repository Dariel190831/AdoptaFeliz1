using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdoptaFeliz.Models
{
    [Table("registro")]
    public class Registro
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("raza")]
        public string Raza { get; set; }

        [Column("edad")]
        public string Edad { get; set; }

        [Column("categoria")]
        public string Categoria { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
