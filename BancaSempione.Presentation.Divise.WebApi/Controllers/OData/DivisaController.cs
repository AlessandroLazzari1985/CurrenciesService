using AutoMapper;
using BancaSempione.Application.DTOs.Dtos;
using BancaSempione.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace BancaSempione.Presentation.Divise.WebApi.Controllers.OData;

public class DivisaController(IDivisaService divisaService, IMapper mapper) : ODataController
{
    [HttpGet, EnableQuery]
    public List<DivisaDto> Get()
    {
        var result = divisaService.Divise.Select(mapper.Map<DivisaDto>).ToList();
        return result;
    }

    [HttpGet, EnableQuery]
    public ActionResult<DivisaDto> Get([FromRoute] int key)
    {
        var item = divisaService.Divise.SingleOrDefault(d => d.DivisaId.Equals(key));

        if (item == null)
        {
            return NotFound();
        }

        return Ok(mapper.Map<DivisaDto>(item));
    }
}