using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteAPI.Data
{
    [Table("TiposDocumentos")]
    public class TiposDocumento
    {
        [Key]
        public int IdTipoDocumento { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        
        [StringLength(255)]
        public string Descripcion { get; set; }
        
        public bool Activo { get; set; } = true;
    }
}