using jcdcdev.Umbraco.Core.Extensions;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;
using Umbraco.Community.BackOfficeOrganiser.Organisers.DataTypes;
using Umbraco.Extensions;

namespace Umbraco.Community.BackOfficeOrganiser.TestSite;

public class ExampleDataTypeOrganiseAction : IDataTypeOrganiseAction
{
    public bool CanMove(IDataType dataType, IDataTypeService dataTypeService, IDataTypeContainerService dataTypeContainerService) => dataType.EditorAlias.InvariantContains("Media");

    public async Task MoveAsync(IDataType dataType, IDataTypeService dataTypeService, IDataTypeContainerService dataTypeContainerService)
    {
        var folder = dataTypeService.GetOrCreateFolder("📂 - Media");
        await dataTypeService.MoveAsync(dataType, folder.Key, Cms.Core.Constants.Security.SuperUserKey);
    }
}