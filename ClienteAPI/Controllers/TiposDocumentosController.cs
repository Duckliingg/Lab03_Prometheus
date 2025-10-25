using System.Collections.Generic;
using System.Threading.Tasks;
using ClienteAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClienteAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiposDocumentosController : ControllerBase
    {
        private readonly BdClientesContext _context;

        public TiposDocumentosController(BdClientesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiposDocumento>>> GetTiposDocumentos()
        {
            return await _context.TiposDocumentos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TiposDocumento>> GetTiposDocumento(int id)
        {
            var tiposDocumento = await _context.TiposDocumentos.FindAsync(id);

            if (tiposDocumento == null)
            {
                return NotFound();
            }

            return tiposDocumento;
        }
    }
}