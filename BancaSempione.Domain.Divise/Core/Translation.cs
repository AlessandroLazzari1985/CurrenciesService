namespace BancaSempione.Domain.Divise.Core;

public class Translation
{
    public Guid TranslationId { get; set; }
    public required string EntityName { get; set; }
    public required string EntityId { get; set; }
    public required string Language { get; set; }
    public required string Value { get; set; }
}