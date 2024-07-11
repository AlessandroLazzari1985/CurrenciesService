using BancaSempione.Application.DTOs.Dtos;
using BancaSempione.Domain.Divise;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace BancaSempione.Presentation.Divise.WebApi.Controllers.OData.Configurations
{
    public static class EdmModelBuilder
    {
        public static IMvcBuilder RegisterOdata(this IMvcBuilder mvcBuilder, string route)
        {
            return mvcBuilder.AddOData(options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null)
                .AddRouteComponents(route, Build()));
        }

        public static IEdmModel Build()
        {
            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<DivisaDto>(nameof(Divisa)).EntityType.HasKey(x => x.DivisaId);
            modelBuilder.EntitySet<CorsoDivisaDto>(nameof(CorsoDivisa)).EntityType.HasKey(x => x.CorsoDivisaId);
            modelBuilder.EntitySet<GruppoDivisa>(nameof(GruppoDivisa));
            modelBuilder.EntitySet<TipoDivisa>(nameof(TipoDivisa));

            return modelBuilder.GetEdmModel();
        }
    }
}
