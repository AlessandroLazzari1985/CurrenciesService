using AutoMapper;
using BancaSempione.Domain.Divise;
using BancaSempione.Infrastructure.Database.Model;

namespace BancaSempione.Infrastructure.Repositories.Mappers;

public class DivisaProfile : Profile
{
    public DivisaProfile()
    {
        CreateMap<Divisa, DivisaRecord>();
        CreateMap<DivisaRecord, Divisa>();
    }
}