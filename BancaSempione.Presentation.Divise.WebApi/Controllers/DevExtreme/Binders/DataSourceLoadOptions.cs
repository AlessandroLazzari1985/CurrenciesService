using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;

namespace BancaSempione.Presentation.Divise.WebApi.Controllers.DevExtreme.Binders;

[ModelBinder(BinderType = typeof(DataSourceLoadOptionsBinder))]
public class DataSourceLoadOptions : DataSourceLoadOptionsBase;