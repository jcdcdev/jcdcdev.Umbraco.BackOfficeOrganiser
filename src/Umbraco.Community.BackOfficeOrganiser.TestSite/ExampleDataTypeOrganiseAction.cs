using jcdcdev.Umbraco.Core.Extensions;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;
using Umbraco.Community.BackOfficeOrganiser.Core.OrganiseActions;

namespace Umbraco.Community.BackOfficeOrganiser.TestSite;

public class ExampleDataTypeOrganiseAction : IDataTypeOrganiseAction
{
    public bool CanMove(
        IDataType dataType, 
        IDataTypeService dataTypeService, 
        IDataTypeContainerService dataTypeContainerService)
        => dataType.EditorAlias.InvariantContains("Media");

    public async Task MoveAsync(
        IDataType dataType, 
        IDataTypeService dataTypeService, 
        IDataTypeContainerService dataTypeContainerService)
    {
        var folder = await dataTypeContainerService.GetOrCreateFolderAsync("📷 Media");
        await dataTypeService.MoveAsync(dataType, folder.Key, Cms.Core.Constants.Security.SuperUserKey);
    }

    public string Name => "Move Media Data Types";
    public string Description => "Moves data types with the editor alias 'Media' to the '📷 Media' folder.";
}