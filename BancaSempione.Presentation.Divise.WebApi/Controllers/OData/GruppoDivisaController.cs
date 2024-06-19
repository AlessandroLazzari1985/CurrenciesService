using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace BancaSempione.Presentation.Divise.WebApi.Controllers.OData;

public class GruppoDivisaController(IGruppoDivisaService gruppoDivisaService) : ODataController
{
    [HttpGet, EnableQuery]
    public ActionResult<IEnumerable<GruppoDivisa>> Get()
    {
        return Ok(gruppoDivisaService.GruppoDivisaById.Values);
    }

    [HttpGet, EnableQuery]
    public ActionResult<GruppoDivisa> Get([FromRoute] int key)
    {
        if(!gruppoDivisaService.GruppoDivisaById.TryGetValue(key, out var item))
            return NotFound();

        return Ok(item);
    }
}