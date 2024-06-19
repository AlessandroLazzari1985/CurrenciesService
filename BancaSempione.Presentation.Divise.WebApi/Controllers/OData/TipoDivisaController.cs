using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace BancaSempione.Presentation.Divise.WebApi.Controllers.OData;


public class TipoDivisaController(ITipoDivisaService tipoDivisaService) : ODataController
{
    [HttpGet, EnableQuery]
    public ActionResult<IEnumerable<TipoDivisa>> Get()
    {
        return Ok(tipoDivisaService.TipoDivisaById.Values);
    }

    [HttpGet, EnableQuery]
    public ActionResult<TipoDivisa> Get([FromRoute] string key)
    {
        if(!tipoDivisaService.TipoDivisaById.TryGetValue(key, out var item))
            return NotFound();

        return Ok(item);
    }
}