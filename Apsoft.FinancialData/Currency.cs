using Apsoft.Domain.Entities;

namespace Apsoft.Domain.FinancialData;


// ReSharper disable InconsistentNaming
public class Currency(
    string alphabeticCode,
    int numericCode,
    string? name,
    string? symbol,
    int decimalDigits,
    int rounding)
    : ValueObject<Currency>
{
    // More ISO: BOV, COU, XUA, MXV, SLE, XSU, SSP, CHE, CHW, USN, UYI, UYW, VED, XBA, XBB, XBC, XBD, XTS, XXX
    // More currencyAPI: BYR, GGP, HRK, IMP, JEP, LTL, LVL, MRO, SLL, STD, VEF, ZMK, BTC, ETH, BNB, XRP, SOL, DOT, AVAX, MATIC, LTC, ADA, USDT, USDC, DAI, ARB, OP
    public static readonly Currency AED = new("AED", 784, "United Arab Emirates Dirham", "AED", 2, 0);
    public static readonly Currency AFN = new("AFN", 971, "Afghan Afghani", "Af", 0, 0);
    public static readonly Currency ALL = new("ALL", 008, "Albanian Lek", "ALL", 0, 0);
    public static readonly Currency AMD = new("AMD", 051, "Armenian Dram", "AMD", 0, 0);
    public static readonly Currency ANG = new("ANG", 532, "NL Antillean Guilder", "ƒ", 2, 0);
    public static readonly Currency AOA = new("AOA", 973, "Angolan Kwanza", "Kz", 2, 0);
    public static readonly Currency ARS = new("ARS", 032, "Argentine Peso", "AR$", 2, 0);
    public static readonly Currency AUD = new("AUD", 036, "Australian Dollar", "AU$", 2, 0);
    public static readonly Currency AWG = new("AWG", 533, "Aruban Florin", "Afl.", 2, 0);
    public static readonly Currency AZN = new("AZN", 944, "Azerbaijani Manat", "man.", 2, 0);
    public static readonly Currency BAM = new("BAM", 977, "Bosnia-Herzegovina Convertible Mark", "KM", 2, 0);
    public static readonly Currency BBD = new("BBD", 052, "Barbadian Dollar", "Bds$", 2, 0);
    public static readonly Currency BDT = new("BDT", 050, "Bangladeshi Taka", "Tk", 2, 0);
    public static readonly Currency BGN = new("BGN", 975, "Bulgarian Lev", "BGN", 2, 0);
    public static readonly Currency BHD = new("BHD", 048, "Bahraini Dinar", "BD", 3, 0);
    public static readonly Currency BIF = new("BIF", 108, "Burundian Franc", "FBu", 0, 0);
    public static readonly Currency BMD = new("BMD", 060, "Bermudan Dollar", "BD$", 2, 0);
    public static readonly Currency BND = new("BND", 096, "Brunei Dollar", "BN$", 2, 0);
    public static readonly Currency BOB = new("BOB", 068, "Bolivian Boliviano", "Bs", 2, 0);
    public static readonly Currency BRL = new("BRL", 986, "Brazilian Real", "R$", 2, 0);
    public static readonly Currency BSD = new("BSD", 044, "Bahamian Dollar", "B$", 2, 0);
    public static readonly Currency BTN = new("BTN", 064, "Bhutanese Ngultrum", "Nu.", 2, 0);
    public static readonly Currency BWP = new("BWP", 072, "Botswanan Pula", "BWP", 2, 0);
    public static readonly Currency BYN = new("BYN", 933, "Belarusian ruble", "Br", 2, 0);
    public static readonly Currency BZD = new("BZD", 084, "Belize Dollar", "BZ$", 2, 0);
    public static readonly Currency CAD = new("CAD", 124, "Canadian Dollar", "CA$", 2, 0);
    public static readonly Currency CDF = new("CDF", 976, "Congolese Franc", "CDF", 2, 0);
    public static readonly Currency CHF = new("CHF", 756, "Swiss Franc", "CHF", 2, 0);
    public static readonly Currency CLF = new("CLF", 990, "Unidad de Fomento", "UF", 2, 0);
    public static readonly Currency CLP = new("CLP", 152, "Chilean Peso", "CL$", 0, 0);
    public static readonly Currency CNY = new("CNY", 156, "Chinese Yuan", "CN¥", 2, 0);
    public static readonly Currency COP = new("COP", 170, "Coombian Peso", "CO$", 0, 0);
    public static readonly Currency CRC = new("CRC", 188, "Costa Rican Colón", "₡", 0, 0);
    public static readonly Currency CUC = new("CUC", 931, "Cuban Convertible Peso", "CUC$", 2, 0);
    public static readonly Currency CUP = new("CUP", 192, "Cuban Peso", "$MN", 2, 0);
    public static readonly Currency CVE = new("CVE", 132, "Cape Verdean Escudo", "CV$", 2, 0);
    public static readonly Currency CZK = new("CZK", 203, "Czech Republic Koruna", "Kč", 2, 0);
    public static readonly Currency DJF = new("DJF", 262, "Djiboutian Franc", "Fdj", 0, 0);
    public static readonly Currency DKK = new("DKK", 208, "Danish Krone", "Dkr", 2, 0);
    public static readonly Currency DOP = new("DOP", 214, "Dominican Peso", "RD$", 2, 0);
    public static readonly Currency DZD = new("DZD", 012, "Algerian Dinar", "DA", 2, 0);
    public static readonly Currency EGP = new("EGP", 818, "Egyptian Pound", "EGP", 2, 0);
    public static readonly Currency ERN = new("ERN", 232, "Eritrean Nakfa", "Nfk", 2, 0);
    public static readonly Currency ETB = new("ETB", 230, "Ethiopian Birr", "Br", 2, 0);
    public static readonly Currency EUR = new("EUR", 978, "Euro", "€", 2, 0);
    public static readonly Currency FJD = new("FJD", 242, "Fijian Dollar", "FJ$", 2, 0);
    public static readonly Currency FKP = new("FKP", 238, "Falkland Islands Pound", "FK£", 2, 0);
    public static readonly Currency GBP = new("GBP", 826, "British Pound Sterling", "£", 2, 0);
    public static readonly Currency GEL = new("GEL", 981, "Georgian Lari", "GEL", 2, 0);
    public static readonly Currency GHS = new("GHS", 936, "Ghanaian Cedi", "GH₵", 2, 0);
    public static readonly Currency GIP = new("GIP", 292, "Gibraltar Pound", "£", 2, 0);
    public static readonly Currency GMD = new("GMD", 270, "Gambian Dalasi", "D", 2, 0);
    public static readonly Currency GNF = new("GNF", 324, "Guinean Franc", "FG", 0, 0);
    public static readonly Currency GTQ = new("GTQ", 320, "Guatemalan Quetzal", "GTQ", 2, 0);
    public static readonly Currency GYD = new("GYD", 328, "Guyanaese Dollar", "G$", 2, 0);
    public static readonly Currency HKD = new("HKD", 344, "Hong Kong Dollar", "HK$", 2, 0);
    public static readonly Currency HNL = new("HNL", 340, "Honduran Lempira", "HNL", 2, 0);
    public static readonly Currency HTG = new("HTG", 332, "Haitian Gourde", "G", 2, 0);
    public static readonly Currency HUF = new("HUF", 348, "Hungarian Forint", "Ft", 0, 0);
    public static readonly Currency IDR = new("IDR", 360, "Indonesian Rupiah", "Rp", 0, 0);
    public static readonly Currency ILS = new("ILS", 376, "Israeli New Sheqel", "₪", 2, 0);
    public static readonly Currency INR = new("INR", 356, "Indian Rupee", "Rs", 2, 0);
    public static readonly Currency IQD = new("IQD", 368, "Iraqi Dinar", "IQD", 0, 0);
    public static readonly Currency IRR = new("IRR", 364, "Iranian Rial", "IRR", 0, 0);
    public static readonly Currency ISK = new("ISK", 352, "Icelandic Króna", "Ikr", 0, 0);
    public static readonly Currency JMD = new("JMD", 388, "Jamaican Dollar", "J$", 2, 0);
    public static readonly Currency JOD = new("JOD", 400, "Jordanian Dinar", "JD", 3, 0);
    public static readonly Currency JPY = new("JPY", 392, "Japanese Yen", "¥", 0, 0);
    public static readonly Currency KES = new("KES", 404, "Kenyan Shilling", "Ksh", 2, 0);
    public static readonly Currency KGS = new("KGS", 417, "Kyrgystani Som", "KGS", 2, 0);
    public static readonly Currency KHR = new("KHR", 116, "Cambodian Riel", "KHR", 2, 0);
    public static readonly Currency KMF = new("KMF", 174, "Comorian Franc", "CF", 0, 0);
    public static readonly Currency KPW = new("KPW", 408, "North Korean Won", "₩", 2, 0);
    public static readonly Currency KRW = new("KRW", 410, "South Korean Won", "₩", 0, 0);
    public static readonly Currency KWD = new("KWD", 414, "Kuwaiti Dinar", "KD", 3, 0);
    public static readonly Currency KYD = new("KYD", 136, "Cayman Islands Dollar", "CI$", 2, 0);
    public static readonly Currency KZT = new("KZT", 398, "Kazakhstani Tenge", "KZT", 2, 0);
    public static readonly Currency LAK = new("LAK", 418, "Laotian Kip", "₭N", 0, 0);
    public static readonly Currency LBP = new("LBP", 422, "Lebanese Pound", "LB£", 0, 0);
    public static readonly Currency LKR = new("LKR", 144, "Sri Lankan Rupee", "SLRs", 2, 0);
    public static readonly Currency LRD = new("LRD", 430, "Liberian Dollar", "LD$", 2, 0);
    public static readonly Currency LSL = new("LSL", 426, "Lesotho Loti", "L", 2, 0);
    public static readonly Currency LYD = new("LYD", 434, "Libyan Dinar", "LD", 3, 0);
    public static readonly Currency MAD = new("MAD", 504, "Moroccan Dirham", "MAD", 2, 0);
    public static readonly Currency MDL = new("MDL", 498, "Moldovan Leu", "MDL", 2, 0);
    public static readonly Currency MGA = new("MGA", 969, "Malagasy Ariary", "MGA", 0, 0);
    public static readonly Currency MKD = new("MKD", 807, "Macedonian Denar", "MKD", 2, 0);
    public static readonly Currency MMK = new("MMK", 104, "Myanma Kyat", "MMK", 0, 0);
    public static readonly Currency MNT = new("MNT", 496, "Mongolian Tugrik", "₮", 2, 0);
    public static readonly Currency MOP = new("MOP", 446, "Macanese Pataca", "MOP$", 2, 0);
    public static readonly Currency MUR = new("MUR", 480, "Mauritian Rupee", "MURs", 0, 0);
    public static readonly Currency MVR = new("MVR", 462, "Maldivian Rufiyaa", "MRf", 2, 0);
    public static readonly Currency MWK = new("MWK", 454, "Malawian Kwacha", "MK", 2, 0);
    public static readonly Currency MXN = new("MXN", 484, "Mexican Peso", "MX$", 2, 0);
    public static readonly Currency MYR = new("MYR", 458, "Malaysian Ringgit", "RM", 2, 0);
    public static readonly Currency MZN = new("MZN", 943, "Mozambican Metical", "MTn", 2, 0);
    public static readonly Currency NAD = new("NAD", 516, "Namibian Dollar", "N$", 2, 0);
    public static readonly Currency NGN = new("NGN", 566, "Nigerian Naira", "₦", 2, 0);
    public static readonly Currency NIO = new("NIO", 558, "Nicaraguan Córdoba", "C$", 2, 0);
    public static readonly Currency NOK = new("NOK", 578, "Norwegian Krone", "Nkr", 2, 0);
    public static readonly Currency NPR = new("NPR", 524, "Nepalese Rupee", "NPRs", 2, 0);
    public static readonly Currency NZD = new("NZD", 554, "New Zealand Dollar", "NZ$", 2, 0);
    public static readonly Currency OMR = new("OMR", 512, "Omani Rial", "OMR", 3, 0);
    public static readonly Currency PAB = new("PAB", 590, "Panamanian Balboa", "B/.", 2, 0);
    public static readonly Currency PEN = new("PEN", 604, "Peruvian Nuevo Sol", "S/.", 2, 0);
    public static readonly Currency PGK = new("PGK", 598, "Papua New Guinean Kina", "K", 2, 0);
    public static readonly Currency PHP = new("PHP", 608, "Philippine Peso", "₱", 2, 0);
    public static readonly Currency PKR = new("PKR", 586, "Pakistani Rupee", "PKRs", 0, 0);
    public static readonly Currency PLN = new("PLN", 985, "Polish Zloty", "zł", 2, 0);
    public static readonly Currency PYG = new("PYG", 600, "Paraguayan Guarani", "₲", 0, 0);
    public static readonly Currency QAR = new("QAR", 634, "Qatari Rial", "QR", 2, 0);
    public static readonly Currency RON = new("RON", 946, "Romanian Leu", "RON", 2, 0);
    public static readonly Currency RSD = new("RSD", 941, "Serbian Dinar", "din.", 0, 0);
    public static readonly Currency RUB = new("RUB", 643, "Russian Ruble", "RUB", 2, 0);
    public static readonly Currency RWF = new("RWF", 646, "Rwandan Franc", "RWF", 0, 0);
    public static readonly Currency SAR = new("SAR", 682, "Saudi Riyal", "SR", 2, 0);
    public static readonly Currency SBD = new("SBD", 090, "Solomon Islands Dollar", "SI$", 2, 0);
    public static readonly Currency SCR = new("SCR", 690, "Seychellois Rupee", "SRe", 2, 0);
    public static readonly Currency SDG = new("SDG", 938, "Sudanese Pound", "SDG", 2, 0);
    public static readonly Currency SEK = new("SEK", 752, "Swedish Krona", "Skr", 2, 0);
    public static readonly Currency SGD = new("SGD", 702, "Singapore Dollar", "S$", 2, 0);
    public static readonly Currency SHP = new("SHP", 654, "Saint Helena Pound", "£", 2, 0);
    public static readonly Currency SOS = new("SOS", 706, "Somali Shilling", "Ssh", 0, 0);
    public static readonly Currency SRD = new("SRD", 968, "Surinamese Dollar", "$", 2, 0);
    public static readonly Currency SVC = new("SVC", 222, "Salvadoran Colón", "₡", 2, 0);
    public static readonly Currency SYP = new("SYP", 760, "Syrian Pound", "SY£", 0, 0);
    public static readonly Currency SZL = new("SZL", 748, "Swazi Lilangeni", "L", 2, 0);
    public static readonly Currency THB = new("THB", 764, "Thai Baht", "฿", 2, 0);
    public static readonly Currency TJS = new("TJS", 972, "Tajikistani Somoni", "TJS", 2, 0);
    public static readonly Currency TMT = new("TMT", 934, "Turkmenistani Manat", "T", 2, 0);
    public static readonly Currency TND = new("TND", 788, "Tunisian Dinar", "DT", 3, 0);
    public static readonly Currency TOP = new("TOP", 776, "Tongan Paʻanga", "T$", 2, 0);
    public static readonly Currency TRY = new("TRY", 949, "Turkish Lira", "TL", 2, 0);
    public static readonly Currency TTD = new("TTD", 780, "Trinidad and Tobago Dollar", "TT$", 2, 0);
    public static readonly Currency TWD = new("TWD", 901, "New Taiwan Dollar", "NT$", 2, 0);
    public static readonly Currency TZS = new("TZS", 834, "Tanzanian Shilling", "TSh", 0, 0);
    public static readonly Currency UAH = new("UAH", 980, "Ukrainian Hryvnia", "₴", 2, 0);
    public static readonly Currency UGX = new("UGX", 800, "Ugandan Shilling", "USh", 0, 0);
    public static readonly Currency USD = new("USD", 840, "US Dollar", "$", 2, 0);
    public static readonly Currency UYU = new("UYU", 858, "Uruguayan Peso", "$U", 2, 0);
    public static readonly Currency UZS = new("UZS", 860, "Uzbekistan Som", "UZS", 0, 0);
    public static readonly Currency VND = new("VND", 704, "Vietnamese Dong", "₫", 0, 0);
    public static readonly Currency VUV = new("VUV", 548, "Vanuatu Vatu", "VUV", 0, 0);
    public static readonly Currency WST = new("WST", 882, "Samoan Tala", "WS$", 2, 0);
    public static readonly Currency XAF = new("XAF", 950, "CFA Franc BEAC", "FCFA", 0, 0);
    public static readonly Currency XAG = new("XAG", 961, "Silver Ounce", "XAG", 2, 0);
    public static readonly Currency XAU = new("XAU", 959, "Gold Ounce", "XAU", 2, 0);
    public static readonly Currency XCD = new("XCD", 951, "East Caribbean Dollar", "EC$", 2, 0);
    public static readonly Currency XDR = new("XDR", 960, "Special drawing rights", "SDR", 2, 0);
    public static readonly Currency XOF = new("XOF", 952, "CFA Franc BCEAO", "CFA", 0, 0);
    public static readonly Currency XPF = new("XPF", 953, "CFP Franc", "CFP", 0, 0);
    public static readonly Currency YER = new("YER", 886, "Yemeni Rial", "YR", 0, 0);
    public static readonly Currency ZAR = new("ZAR", 710, "South African Rand", "R", 2, 0);
    public static readonly Currency ZMW = new("ZMW", 967, "Zambian Kwacha", "ZK", 0, 0);
    public static readonly Currency ZWL = new("ZWL", 932, "Zimbabwean dollar", "ZWL", 2, 0);
    public static readonly Currency XPT = new("XPT", 962, "Platinum Ounce", "XPT", 6, 0);
    public static readonly Currency XPD = new("XPD", 964, "Palladium Ounce", "XPD", 6, 0);
    public static readonly Currency VES = new("VES", 928, "Venezuelan Bolívar", "Bs.S.", 2, 0);
    public static readonly Currency STN = new("STN", 930, "São Tomé and Príncipe dobra", "STN", 2, 0);
    public static readonly Currency MRU = new("MRU", 929, "Mauritanian ouguiya", "MRU", 2, 0);


    public string AlphabeticCode { get; } = alphabeticCode;     // Alfanumerico a 3 cifre
    public int NumericCode { get; } = numericCode;              // Numerico a 3 cifre
    public string? Name { get; } = name;
    public string? Symbol { get; } = symbol;
    public int DecimalDigits { get; } = decimalDigits;
    public int Rounding { get; } = rounding;
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return AlphabeticCode;
    }

    public static Currency GetByAlphabeticCode(string alphaIso3)
    {
        return GetAll().Single(x => x.AlphabeticCode == alphaIso3);
    }

    public static Currency GetByNumericCode(int numericCode)
    {
        return GetAll().Single(x => x.NumericCode == numericCode);
    }

}


/*
 * Divise di BOSS non trovate nella ISO 4217

 * PTG
   SGR
   G08
   GGR
   PTK
   PDG*/