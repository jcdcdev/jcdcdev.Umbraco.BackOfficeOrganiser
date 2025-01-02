using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Api.Common.Attributes;
using Umbraco.Cms.Api.Common.Filters;
using Umbraco.Cms.Api.Management.Filters;
using Umbraco.Cms.Web.Common.Authorization;
using Umbraco.Community.BackOfficeOrganiser.Core.Services;
using Umbraco.Community.BackOfficeOrganiser.Web.Models;

namespace Umbraco.Community.BackOfficeOrganiser.Web.Controllers;

[ApiExplorerSettings(GroupName = Constants.Api.ApiName)]
[BackOfficeOrganiserRoute("organise")]
[MapToApi(Constants.Api.ApiName)]
[JsonOptionsName(Cms.Core.Constants.JsonOptionsNames.BackOffice)]
[ApiController]
[Authorize(Policy = AuthorizationPolicies.BackOfficeAccess)]
[AppendEventMessages]
[Produces("application/json")]
public class BackOfficeOrganiserController(IBackOfficeOrganiserService service) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType<OrganiseResponse>(200)]
    [ProducesResponseType<OrganiseResponse>(400)]
    [Consumes(typeof(OrganiseRequest), "application/json")]
    public async Task<IActionResult> Organise([FromBody] OrganiseRequest model)
    {
        var success = true;
        foreach (var type in model.GetOrganiseTypes())
        {
            var attempt = await service.OrganiseAsync(type);
            if (!attempt.Success)
            {
                success = false;
            }
        }

        if (!success)
        {
            return BadRequest(OrganiseResponse.Fail("Failed to organise"));
        }

        return Ok(OrganiseResponse.Success("Successfully organised \ud83d\ude80"));
    }
}