using jcdcdev.Umbraco.Core.Extensions;
using jcdcdev.Umbraco.Core.Web.Models.Manifests;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Manifest;
using Umbraco.Cms.Infrastructure.Manifest;
using Umbraco.Community.BackOfficeOrganiser.Core;

namespace Umbraco.Community.BackOfficeOrganiser.Infrastructure;

public class PackageManifestReader(
    ILogger<PackageManifestReader> logger)
    : IPackageManifestReader
{
    public async Task<IEnumerable<PackageManifest>> ReadPackageManifestsAsync()
    {
        var extensions = new List<IManifest>();
        var packageManifest = new PackageManifest
        {
            Name = Constants.PackageName,
            Version = EnvironmentExtensions.CurrentAssemblyVersion().ToSemVer()?.ToString() ?? "0.1.0",
            AllowPublicAccess = false,
            AllowTelemetry = true,
            Extensions = []
        };

        extensions.Add(new BackofficeEntryPointManifest
        {
            Name = "backoffice-organiser.entrypoint",
            Alias = "backoffice-organiser.entrypoint",
            Js = $"/App_Plugins/{Constants.PackageName}/dist/index.js"
        });

        packageManifest.Extensions = extensions.OfType<object>().ToArray();
        return [packageManifest];
    }
}