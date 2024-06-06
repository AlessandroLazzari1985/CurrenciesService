using Microsoft.Extensions.DependencyInjection;

namespace Apsoft.Domain.Repositories
{
    public static class RegisterDependencies
    {
        public static IServiceCollection Register_Apsoft_Domain_Repositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICountryRepository, CountryRepository>();
            serviceCollection.AddScoped<ICurrencyRepository, CurrencyRepository>();

            return serviceCollection;
        }
    }
}
