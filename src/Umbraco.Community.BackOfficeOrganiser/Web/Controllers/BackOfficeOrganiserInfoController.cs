using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Api.Common.Attributes;
using Umbraco.Cms.Api.Common.Filters;
using Umbraco.Cms.Api.Management.Filters;
using Umbraco.Cms.Web.Common.Authorization;
using Umbraco.Community.BackOfficeOrganiser.Core.Extensions;
using Umbraco.Community.BackOfficeOrganiser.Core.Models;
using Umbraco.Community.BackOfficeOrganiser.Core.Services;
using Umbraco.Community.BackOfficeOrganiser.Web.Models;

namespace Umbraco.Community.BackOfficeOrganiser.Web.Controllers;

[ApiExplorerSettings(GroupName = Constants.Api.ApiName)]
[BackOfficeOrganiserRoute("info")]
[MapToApi(Constants.Api.ApiName)]
[JsonOptionsName(Cms.Core.Constants.JsonOptionsNames.BackOffice)]
[ApiController]
[Authorize(Policy = AuthorizationPolicies.BackOfficeAccess)]
[AppendEventMessages]
[Produces("application/json")]
public class BackOfficeOrganiserInfoController(IBackOfficeOrganiserService service) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<OrganiseInfoResponse>(200)]
    public IActionResult Index()
    {
        var model = new OrganiseInfoResponse
        {
            DataTypes = service.GetActions(OrganiseType.DataTypes).Select(x => new OrganiseInfoModel
            {
                Alias = x.GetAlias(),
                Name = x.Name,
                Description = x.Description
            }),
            ContentTypes = service.GetActions(OrganiseType.ContentTypes).Select(x => new OrganiseInfoModel
            {
                Alias = x.GetAlias(),
                Name = x.Name,
                Description = x.Description
            }),
            MediaTypes = service.GetActions(OrganiseType.MediaTypes).Select(x => new OrganiseInfoModel
            {
                Alias = x.GetAlias(),
                Name = x.Name,
                Description = x.Description
            }),
            MemberTypes = service.GetActions(OrganiseType.MemberTypes).Select(x => new OrganiseInfoModel
            {
                Alias = x.GetAlias(),
                Name = x.Name,
                Description = x.Description
            })
        };

        return Ok(model);
    }
}