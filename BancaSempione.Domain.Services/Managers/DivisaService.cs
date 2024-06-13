using Apsoft.Domain.FinancialData;
using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Repositories;
using BancaSempione.Domain.Services.Interfaces;

namespace BancaSempione.Domain.Services.Managers;

public class DivisaService(IDivisaRepository repository) : IDivisaService
{
    public List<Divisa> Divise => repository.Items.ToList();

    public Dictionary<string, Divisa> DiviseByIsoCode => repository.Items.ToList()
        .ToDictionary(x => x.AlphabeticCode, x => x);

    public Dictionary<string, Divisa> DiviseIn => repository.Items.ToList()
        .Where(x => x.IsDivisaIn)
        .ToDictionary(x => x.AlphabeticCode, x => x);

    public Dictionary<int, Divisa> DiviseById => repository.Items.ToList()
        .ToDictionary(x => x.DivisaId, x => x);

    public Divisa DivisaIstituto => repository.Items.ToList()
        .Single(x => x.AlphabeticCode == Currency.CHF.AlphabeticCode);
}