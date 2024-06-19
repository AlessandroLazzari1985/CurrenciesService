using AutoMapper;
using BancaSempione.Application.DTOs.Dtos;
using BancaSempione.Domain.Services.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace BancaSempione.Presentation.Divise.WebApi.Controllers.OData;

public class CorsoDivisaController(ICorsoDivisaService corsoDivisaService, IMapper mapper) : ODataController
{
    [HttpGet, EnableQuery]
    public List<CorsoDivisaDto> Get()
    {
        var result = corsoDivisaService.CorsiDivisa.Select(mapper.Map<CorsoDivisaDto>).ToList();
        return result;
    }

    [HttpGet, EnableQuery]
    public ActionResult<CorsoDivisaDto> Get([FromRoute] Guid key)
    {
        var item = corsoDivisaService.CorsiDivisa.SingleOrDefault(d => d.Id.Equals(key));

        if (item == null)
        {
            return NotFound();
        }

        return Ok(mapper.Map<CorsoDivisaDto>(item));
    }
}