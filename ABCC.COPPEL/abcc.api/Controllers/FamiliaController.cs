using abcc.domain.Entities;
using abcc.service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace abcc.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliaController : ControllerBase
    {
        private readonly IFamiliaService _familiaService;
        public FamiliaController(IFamiliaService familiaService)
        {
            this._familiaService = familiaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Familia>>> GetAllFamilias()
        {
            try
            {
                IEnumerable<Familia> res = await _familiaService.GetAllFamilias();
                return Ok(res);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
    }
}
