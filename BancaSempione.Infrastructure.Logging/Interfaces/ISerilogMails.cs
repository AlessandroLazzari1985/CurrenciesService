namespace BancaSempione.Infrastructure.Logging.Interfaces;

public interface ISerilogMails
{
    public string From { get; }
    public List<string> To { get; }
}