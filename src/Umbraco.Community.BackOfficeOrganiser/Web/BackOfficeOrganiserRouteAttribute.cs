using Umbraco.Cms.Web.Common.Routing;

namespace Umbraco.Community.BackOfficeOrganiser.Web;

public class BackOfficeOrganiserRouteAttribute(string template) : BackOfficeRouteAttribute($"BackOfficeOrganiser/api/v{{version:apiVersion}}/{template.TrimStart('/')}");