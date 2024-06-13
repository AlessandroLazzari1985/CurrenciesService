using BancaSempione.Domain.Services.Interfaces;
using BancaSempione.Presentation.Divise.WebApi.Controllers.DevExtreme.Binders;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace BancaSempione.Presentation.Divise.WebApi.Controllers.DevExtreme
{
    [ApiController]
    [Route("api/[controller]")]
    public class DivisaController(IDivisaService divisaService) : ControllerBase
    {
        [HttpGet]
        public LoadResult GetDivise(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(divisaService.Divise, loadOptions);
        }

        // GET: api/divisa/{id}
        [HttpGet("{id}")]
        public IActionResult GetDivisaById(int id)
        {
            if(divisaService.DiviseById.TryGetValue(id, out var divisa))
            {
                return Ok(divisa);
            }

            return NotFound();
        }

        // GET: api/divisa/code/{code}
        [HttpGet("code/{isoCode}")]
        public async Task<IActionResult> GetDivisaByCode(string isoCode)
        {
            if (divisaService.DiviseByIsoCode.TryGetValue(isoCode, out var divisa))
            {
                return Ok(divisa);
            }

            return NotFound();
        }

        // GET: api/divisa/all
        [HttpGet("all")]
        public async Task<IActionResult> GetAllDivise()
        {
            return Ok(await Task.FromResult(divisaService.Divise));
        }
    }
}
