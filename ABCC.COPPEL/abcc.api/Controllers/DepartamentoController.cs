using abcc.domain.Entities;
using abcc.service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace abcc.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService _departamentoService;
        public DepartamentoController(IDepartamentoService departamentoService)
        {
            this._departamentoService = departamentoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetAllDepartamentos()
        {
            try
            {
                IEnumerable<Departamento> res = await _departamentoService.GetAllDepartamentos();
                return Ok(res);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
    }
}
