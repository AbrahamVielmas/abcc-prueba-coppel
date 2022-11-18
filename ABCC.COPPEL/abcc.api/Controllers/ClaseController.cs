using abcc.domain.Entities;
using abcc.service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace abcc.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaseController : ControllerBase
    {
        private readonly IClaseService _claseService;

        public ClaseController(IClaseService claseService)
        {
            this._claseService = claseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clase>>> GetAllClases()
        {
            try
            {
                IEnumerable<Clase> res = await _claseService.GetAllClases();
                return Ok(res);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}
