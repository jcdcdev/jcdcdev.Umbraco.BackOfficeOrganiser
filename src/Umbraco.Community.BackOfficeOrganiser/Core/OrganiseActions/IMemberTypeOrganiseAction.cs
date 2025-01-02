using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;

namespace Umbraco.Community.BackOfficeOrganiser.Core.OrganiseActions;

public interface IMemberTypeOrganiseAction : IOrganiseAction
{
    public bool CanMove(IMemberType memberType, IMemberTypeService memberTypeService);
    public Task MoveAsync(IMemberType memberType, IMemberTypeService memberTypeService);
}