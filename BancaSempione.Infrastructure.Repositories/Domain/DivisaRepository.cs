using Apsoft.Domain.FinancialData;
using BancaSempione.Domain.Divise;
using BancaSempione.Domain.Repositories;
using BancaSempione.Infrastructure.Database.Model;

namespace BancaSempione.Infrastructure.Repositories.Domain;

public class DivisaRepository(DivisaRecordRepository divisaRecordRepository) : IDivisaRepository
{
    public IQueryable<Divisa> Items => divisaRecordRepository.Items.AsEnumerable().Select(ToDomain).AsQueryable();
    public void Delete()
    {
        divisaRecordRepository.Delete();
    }

    public void Insert(IEnumerable<Divisa> list)
    {
        divisaRecordRepository.Insert(list.Select(FromDomain));
    }

    public void Update(IEnumerable<Divisa> list)
    {
        divisaRecordRepository.Update(list.Select(FromDomain));
    }

    public void Delete(IEnumerable<Divisa> list)
    {
        divisaRecordRepository.Delete(list.Select(FromDomain));
    }

    public void Merge(IEnumerable<Divisa> list)
    {
        divisaRecordRepository.Merge(list.Select(FromDomain));
    }

    public void Insert(Divisa item)
    {
        divisaRecordRepository.Insert(FromDomain(item));
    }

    public void Update(Divisa item)
    {
        divisaRecordRepository.Update(FromDomain(item));
    }

    public void Delete(Divisa item)
    {
        divisaRecordRepository.Delete(FromDomain(item));
    }

    public void Merge(Divisa item)
    {
        divisaRecordRepository.Merge(FromDomain(item));
    }

    public Task InsertAsync(IEnumerable<Divisa> list)
    {
        return divisaRecordRepository.InsertAsync(list.Select(FromDomain));
    }

    public Task UpdateAsync(IEnumerable<Divisa> list)
    {
        return divisaRecordRepository.UpdateAsync(list.Select(FromDomain));
    }

    public Task DeleteAsync(IEnumerable<Divisa> list)
    {
        return divisaRecordRepository.DeleteAsync(list.Select(FromDomain));
    }

    public Task MergeAsync(IEnumerable<Divisa> list)
    {
        return divisaRecordRepository.MergeAsync(list.Select(FromDomain));
    }

    public Task InsertAsync(Divisa item)
    {
        return divisaRecordRepository.InsertAsync(FromDomain(item));
    }

    public Task UpdateAsync(Divisa item)
    {
        return divisaRecordRepository.UpdateAsync(FromDomain(item));
    }

    public Task DeleteAsync(Divisa item)
    {
        return divisaRecordRepository.DeleteAsync(FromDomain(item));
    }

    public Task MergeAsync(Divisa item)
    {
        return divisaRecordRepository.MergeAsync(FromDomain(item));
    }

    public Dictionary<string, Divisa> DiviseByIsoCode => divisaRecordRepository.Items.AsEnumerable()
        .Select(ToDomain)
        .ToDictionary(x => x.AlphabeticCode, x => x);

    public Dictionary<string, Divisa> DiviseIn => divisaRecordRepository.Items.AsEnumerable()
        .Select(ToDomain)
        .Where(x => x.IsDivisaIn)
        .ToDictionary(x => x.AlphabeticCode, x => x);

    public Divisa DivisaIstituto => divisaRecordRepository.Items.AsEnumerable()
        .Select(ToDomain)
        .Single(x => x.AlphabeticCode == Currency.CHF.AlphabeticCode);

    private static Divisa ToDomain(DivisaRecord record)
    {
        return new Divisa(
            record.DivisaRecordId,
            record.AlphabeticCode,
            record.NumericCode,
            record.Name,
            record.Symbol,
            record.DecimalDigits,
            record.Rounding,
            record.IsDivisaIn,
            record.Taglio,
            record.GruppoDivisaId,
            record.TipoDivisaId
        );
    }

    private static DivisaRecord FromDomain(Divisa divisa)
    {
        return new DivisaRecord
        {
            DivisaRecordId = divisa.DivisaId,
            AlphabeticCode = divisa.AlphabeticCode,
            NumericCode = divisa.NumericCode,
            Name = divisa.Name,
            Symbol = divisa.Symbol,
            DecimalDigits = divisa.DecimalDigits,
            Rounding = divisa.Rounding,
            IsDivisaIn = divisa.IsDivisaIn,
            Taglio = divisa.Taglio,
            GruppoDivisaId = divisa.GruppoDivisaId,
            TipoDivisaId = divisa.TipoDivisaId
        };
    }
}