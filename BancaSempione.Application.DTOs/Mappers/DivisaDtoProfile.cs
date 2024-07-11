using AutoMapper;
using BancaSempione.Application.DTOs.Dtos;
using BancaSempione.Domain.Divise;

namespace BancaSempione.Application.DTOs.Mappers;

public class DivisaDtoProfile : Profile
{
    public DivisaDtoProfile()
    {
        CreateMap<Divisa, DivisaDto>();
    }
}