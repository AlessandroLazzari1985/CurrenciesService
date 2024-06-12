﻿using Apsoft.Domain.FinancialData;

namespace Apsoft.Domain.Services.Interfaces;

public interface ICountryService
{
    Dictionary<string, Country> CuntriesByAlpha2();
    Dictionary<int, Country> CountriesByNumeric3();

    Country? GetByAlpha3(string alpha2);
    Country? ByNumeric3(int numeric3);
}