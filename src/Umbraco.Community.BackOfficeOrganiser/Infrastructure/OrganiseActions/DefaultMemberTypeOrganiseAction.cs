using jcdcdev.Umbraco.Core.Extensions;
using StackExchange.Profiling.Internal;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;
using Umbraco.Community.BackOfficeOrganiser.Core.OrganiseActions;

namespace Umbraco.Community.BackOfficeOrganiser.Infrastructure.OrganiseActions;

public class DefaultMemberTypeOrganiseAction : IMemberTypeOrganiseAction
{
    public bool CanMove(IMemberType memberType, IMemberTypeService memberTypeService) => true;

    public async Task MoveAsync(IMemberType memberType, IMemberTypeService memberTypeService)
    {
        var folderKey = Cms.Core.Constants.System.RootKey;
        var folderName = string.Empty;

        if (memberType.CompositionIds().Any())
        {
            folderName = "Compositions";
        }
        else if (memberType.IsElement)
        {
            folderName = "Element Types";
        }

        if (!folderName.IsNullOrWhiteSpace())
        {
            folderKey = memberTypeService.GetOrCreateFolder(folderName).Key;
        }

        await memberTypeService.MoveAsync(memberType.Key, folderKey);
    }

    public string Name => "Default Member Type Organise Action";
    public string Description => "Organises member types into folders based on their composition and element type status.";
}