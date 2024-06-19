using BancaSempione.Domain.Services.Managers;
using BancaSempione.Presentation.Divise.WebApi.Controllers.DevExtreme.Binders;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace BancaSempione.Presentation.Divise.WebApi.Controllers.DevExtreme;

[ApiController]
[Route("devExtreme/[controller]")]
public class CorsoDivisaController(ICorsoDivisaService corsoDivisaService) : ControllerBase
{
    [HttpPost]
    public LoadResult GetLastCorsiDivisa(DataSourceLoadOptions loadOptions)
    {
        return DataSourceLoader.Load(corsoDivisaService.CorsiDivisa, loadOptions);
    }

    [HttpPost, Route("At")]
    public LoadResult GetLastCorsiDivisa(DataSourceLoadOptions loadOptions, DateTime dateTime)
    {
        return DataSourceLoader.Load(corsoDivisaService.GetCorsiDivisaAt(dateTime), loadOptions);
    }
}