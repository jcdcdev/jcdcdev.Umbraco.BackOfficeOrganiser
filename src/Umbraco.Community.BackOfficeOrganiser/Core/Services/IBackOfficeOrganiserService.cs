using Umbraco.Cms.Core;
using Umbraco.Community.BackOfficeOrganiser.Core.Models;

namespace Umbraco.Community.BackOfficeOrganiser.Core;

public interface IBackOfficeOrganiserService
{
    Task<Attempt<OrganiseType>> OrganiseDataTypesAsync();
    Task<Attempt<OrganiseType>> OrganiseMemberTypesAsync();
    Task<Attempt<OrganiseType>> OrganiseMediaTypesAsync();
    Task<Attempt<OrganiseType>> OrganiseContentTypesAsync();
    Task<Attempt<OrganiseType>> OrganiseAsync(OrganiseType type);
}