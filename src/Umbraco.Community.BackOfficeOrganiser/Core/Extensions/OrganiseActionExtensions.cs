using Umbraco.Community.BackOfficeOrganiser.Core.OrganiseActions;
using Umbraco.Extensions;

namespace Umbraco.Community.BackOfficeOrganiser.Core.Extensions;

public static class OrganiseActionExtensions
{
    public static string GetAlias(this IOrganiseAction action) => action.GetType().Name.ToFirstLowerInvariant();
}