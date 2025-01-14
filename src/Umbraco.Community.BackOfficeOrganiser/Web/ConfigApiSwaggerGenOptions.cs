using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Umbraco.Community.BackOfficeOrganiser.Core;

namespace Umbraco.Community.BackOfficeOrganiser.Web;

public class ConfigApiSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {
        options.SwaggerDoc(Constants.Api.ApiName,
            new OpenApiInfo
            {
                Title = Constants.Api.Title,
                Version = "Latest",
                Description = Constants.Api.Description
            });
    }
}