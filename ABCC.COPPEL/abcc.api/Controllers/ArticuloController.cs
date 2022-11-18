using abcc.domain.Entities;
using abcc.service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace abcc.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly IArticuloService _articuloService;

        public ArticuloController(IArticuloService articuloService)
        {
            this._articuloService = articuloService;
        }

        [HttpGet("{sku}")]
        public async Task<ActionResult<Articulo>> GetArticulo(int sku)
        {
            try
            {
                Articulo articulo = await _articuloService.GetArticuloBySku(sku);
                return Ok(articulo);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{sku}")]
        public async Task<ActionResult<int>> DeleteArticulo(int sku)
        {
            try
            {
                int res = await _articuloService.DeleteArticulo(sku);
                return Ok(res);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Articulo>> UpdateArticulo([FromBody] Articulo articulo)
        {
            try
            {
                Articulo res = await _articuloService.UpdateArticuloAsync(articulo);
                return Ok(res);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Articulo>> CreatedArticulo([FromBody] Articulo articulo)
        {
            try
            {
                Articulo res = await _articuloService.CreateArticulo(articulo);
                return Ok(res);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

    }
}
