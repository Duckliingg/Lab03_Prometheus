using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteAPI.Data
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nombres { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Apellidos { get; set; }
        
        public int IdTipoDocumento { get; set; }
        
        [Required]
        [StringLength(20)]
        public string NumeroDocumento { get; set; }
        
        [StringLength(100)]
        public string Email { get; set; }
        
        [StringLength(20)]
        public string Telefono { get; set; }
        
        public bool Activo { get; set; } = true;
        
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [ForeignKey("IdTipoDocumento")]
        public virtual TiposDocumento TipoDocumento { get; set; }
    }
}