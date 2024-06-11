using Apsoft.Domain.FinancialData;
using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Repositories;
using BancaSempione.Domain.Services.Interfaces;

namespace BancaSempione.Domain.Services.Managers;

public class DivisaService(IDivisaRepository divisaRepository) : IDivisaService
{
    public Dictionary<string, Divisa> DiviseByIsoCode => divisaRepository.Items.ToList()
        .ToDictionary(x => x.AlphabeticCode, x => x);

    public Dictionary<string, Divisa> DiviseIn => divisaRepository.Items.ToList()
        .Where(x => x.IsDivisaIn)
        .ToDictionary(x => x.AlphabeticCode, x => x);

    public Dictionary<int, Divisa> DiviseById => divisaRepository.Items.ToList()
        .ToDictionary(x => x.DivisaId, x => x);

    public Divisa DivisaIstituto => divisaRepository.Items.ToList()
        .Single(x => x.AlphabeticCode == Currency.CHF.AlphabeticCode);
}