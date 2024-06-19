using BancaSempione.Domain.Services.Interfaces;
using BancaSempione.Presentation.Divise.WebApi.Controllers.DevExtreme.Binders;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace BancaSempione.Presentation.Divise.WebApi.Controllers.DevExtreme
{
    [ApiController]
    [Route("devExtreme/[controller]")]
    public class DivisaController(IDivisaService divisaService) : ControllerBase
    {
        [HttpGet]
        public LoadResult GetDivise(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(divisaService.Divise, loadOptions);
        }
    }
}
