using Apsoft.Domain.Entities;

namespace Apsoft.Domain.FinancialData;

public class CurrencyExchangeRate : Entity
{
    public CurrencyPair CurrencyPair { get; }
    public decimal BidRate { get; }                 // Tasso di acquisto
    public decimal AskRate { get; }                 // Tasso di vendita
    public decimal ExchangeRate { get; }            // Tasso di cambio. Valore di riferimento o media tra Bid e Ask
    public decimal PreviousExchangeRate { get; }    // Tasso di cambio. Valore di riferimento o media tra Bid e Ask
    public decimal Performance { get; }             // 100 * (ExchangeRate - PreviousRate) / PreviousRate
    public decimal Spread => AskRate - BidRate;
    public Period ValidPeriod { get; }

    public CurrencyExchangeRate(CurrencyPair currencyPair, decimal bidRate, decimal askRate, Period validPeriod, decimal previousExchangeRate)
    {
        if (bidRate < 0) throw new ArgumentException("Must be > 0.", nameof(bidRate));
        if (askRate < 0) throw new ArgumentException("Must be > 0.", nameof(askRate));

        var exchangeRate = (askRate + bidRate) / 2;

        Id = Guid.NewGuid();
        CurrencyPair = currencyPair ?? throw new ArgumentNullException(nameof(currencyPair)); ;
        ExchangeRate = exchangeRate;
        PreviousExchangeRate = previousExchangeRate;
        BidRate = bidRate;
        AskRate = askRate;
        Performance = CalculateRateOfReturn(exchangeRate, previousExchangeRate);
        ValidPeriod = validPeriod ?? throw new ArgumentNullException(nameof(validPeriod));
    }

    private static decimal CalculateRateOfReturn(decimal exchangeRate, decimal? previousExchangeRate)
    {
        if (previousExchangeRate == null)
            return 0m;

        if (previousExchangeRate < 0)
            throw new ArgumentException("Previous rate must be > 0.", nameof(previousExchangeRate));

        if (previousExchangeRate == 0)
            return 0m;
      
        // Calcolo del tasso di rendimento come variazione percentuale del Rate
        return 100 * (exchangeRate - previousExchangeRate.Value) / previousExchangeRate.Value;
    }
}


/*
 
Nel contesto dei mercati finanziari, "Bid" e "Ask" rappresentano due concetti fondamentali che definiscono i prezzi ai quali gli acquirenti e i venditori sono disposti a scambiare uno strumento finanziario. Essi sono parte essenziale del meccanismo di formazione dei prezzi e della liquidità di mercato. Ecco una spiegazione dettagliata:
   
Bid
Il "Bid" è il prezzo più alto che un acquirente è disposto a pagare per un determinato strumento finanziario. 
Rappresenta la domanda e indica il livello di prezzo al quale un acquirente è pronto ad entrare in una transazione. 
Nel caso di un'azione, ad esempio, se il prezzo di bid per l'azione XYZ è di 10$, significa che qualcuno è disposto a comprare l'azione XYZ a quel prezzo.

Ask (o Offer)
L'"Ask" (o "Offer") è il prezzo più basso a cui un venditore è disposto a vendere il suo strumento finanziario. 
Rappresenta l'offerta e indica il prezzo minimo che un venditore accetterebbe per vendere. 
Continuando l'esempio precedente, se il prezzo di ask per l'azione XYZ è di 10,50$, significa che il venditore più disposto a scendere a compromessi richiede quel prezzo per vendere l'azione.

Spread
La differenza tra il prezzo di ask e il prezzo di bid è conosciuta come "Spread". 
Lo spread può essere visto come un indicatore della liquidità di mercato per quello strumento finanziario.
Spread stretti (piccoli) generalmente indicano una buona liquidità, mentre spread ampi possono indicare il contrario. 
Lo spread è anche una fonte di profitto per i market maker e le piattaforme di trading che facilitano le transazioni.

Importanza di Bid e Ask
Formazione dei Prezzi: Bid e ask giocano un ruolo cruciale nel processo di formazione dei prezzi sui mercati finanziari.
Riflettono le intenzioni immediate di acquisto e vendita degli operatori di mercato.

Liquidità: 
La presenza di bid e ask vicini tra loro indica che ci sono molti acquirenti e venditori, il che contribuisce alla liquidità di mercato.
Una maggiore liquidità facilita le transazioni, consentendo agli operatori di entrare e uscire dalle posizioni con minore impatto sul prezzo.

Decisioni di Trading: 
Gli investitori e i trader utilizzano le informazioni sui prezzi di bid e ask per prendere decisioni di trading informate, ad esempio, stabilendo prezzi limite per gli ordini di acquisto o vendita.

Esempio di Utilizzo
Immagina di voler acquistare azioni della società XYZ. 
Controllando la quotazione di mercato, vedi che il prezzo di bid è di 10$ e il prezzo di ask è di 10,50$. 
Questo significa che potresti inserire un ordine di acquisto al prezzo di bid (o superiore) per cercare di acquistare immediatamente, 
o potresti tentare di negoziare e inserire un ordine a un prezzo tra bid e ask, sperando che un venditore accetti.

In conclusione, comprendere i concetti di bid e ask è fondamentale per chiunque operi sui mercati finanziari, 
poiché forniscono informazioni preziose sulla domanda, l'offerta e la liquidità del mercato per gli strumenti finanziari.   
   



DOMANDA: Ma se ci sono Bid e Ask perche esiste ExchangeRate? e cosa serve?

   
Exchange Rate (Tasso di Cambio)
Definizione: Un tasso di cambio rappresenta il valore di una valuta rispetto a un'altra. 
È il prezzo a cui le valute possono essere scambiate tra loro. 
Ad esempio, se l'EUR/USD è 1.2000, significa che 1 Euro può essere scambiato per 1.20 Dollari USA.
   
Scopo: I tassi di cambio sono usati per trasferimenti monetari internazionali, operazioni di commercio estero, speculazioni finanziarie, e per valutare il costo degli investimenti e dei debiti in valute estere. Sono cruciali per l'economia globale, permettendo alle aziende e ai governi di convertire una valuta in un'altra.
   
Bid e Ask nel Contesto del Tasso di Cambio
Bid: È il prezzo massimo che un acquirente (tipicamente una banca o un altro intermediario finanziario) è disposto a pagare per una valuta. 
Questo è il prezzo al quale tu, come venditore, puoi vendere la valuta base (nella coppia EUR/USD, l'Euro è la valuta base).
   
Ask (o Offer): 
È il prezzo minimo a cui un venditore è disposto a vendere una valuta. 
Se vuoi acquistare la valuta base, questo è il prezzo che dovrai pagare.

Scopo: I prezzi Bid e Ask permettono ai mercati di funzionare in modo efficiente, facilitando le transazioni tra compratori e venditori. 
Lo spread tra questi prezzi (la differenza tra Bid e Ask) è il costo per effettuare la transazione ed è anche una fonte di profitto per gli intermediari finanziari.

Relazione tra Exchange Rate, Bid e Ask
Nel trading di valute, l'exchange rate che spesso vedi quotato (ad esempio, su un sito di notizie finanziarie) è generalmente un valore di riferimento 
o una media dei prezzi attuali di Bid e Ask nel mercato. 
Questo tasso fornisce un'indicazione generale del valore di scambio tra due valute.

Gli specifici prezzi di Bid e Ask rappresentano i termini concreti ai quali una transazione di valuta può essere attualmente eseguita. 
Questi prezzi riflettono la domanda e l'offerta correnti nel mercato per quella valuta e possono variare da un intermediario all'altro.

Conclusione
Mentre l'exchange rate fornisce un'indicazione generale del valore di una valuta rispetto a un'altra, 
i prezzi di Bid e Ask sono i termini specifici ai quali le valute possono essere attualmente scambiate. 
I tassi di cambio sono importanti per la valutazione e la conversione delle valute a livello macroeconomico e per le persone fisiche che viaggiano o effettuano transazioni internazionali, 
mentre Bid e Ask sono cruciali per il trading quotidiano e le operazioni nel mercato delle valute.

 * */