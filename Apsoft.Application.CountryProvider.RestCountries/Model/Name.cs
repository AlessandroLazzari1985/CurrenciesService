﻿namespace Apsoft.Application.Provider.RestCountries.Model;

public class Name
{
    public string Common { get; set; }
    public string Official { get; set; }
    public Dictionary<string, NativeName> NativeName { get; set; } = new();
}