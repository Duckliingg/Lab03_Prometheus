using Microsoft.EntityFrameworkCore;

namespace ClienteAPI.Data
{
    public class BdClientesContext : DbContext
    {
        public BdClientesContext(DbContextOptions<BdClientesContext> options)
            : base(options)
        {
        }

        public DbSet<TiposDocumento> TiposDocumentos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}