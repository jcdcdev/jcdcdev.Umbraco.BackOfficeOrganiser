using jcdcdev.Umbraco.Core.Extensions;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;
using Umbraco.Community.BackOfficeOrganiser.Core.Composing;
using Umbraco.Community.BackOfficeOrganiser.Core.OrganiseActions;

namespace Umbraco.Community.BackOfficeOrganiser.Core.Organisers;

public class DataTypeOrganiser(
    ILogger<DataTypeOrganiser> logger,
    IDataTypeService dataTypeService,
    IDataTypeContainerService dataTypeContainerService,
    DataTypeOrganiseActionCollection organiseActions)
    : BackOfficeOrganiserBase<IDataType>(logger)
{
    public override async Task OrganiseAsync(IDataType dataType)
    {
        var organiser = organiseActions.FirstOrDefault(x => x.CanMove(dataType, dataTypeService, dataTypeContainerService));
        if (organiser != null)
        {
            await organiser.MoveAsync(dataType, dataTypeService, dataTypeContainerService);
        }
    }

    public override IEnumerable<IOrganiseAction> GetOrganiseActions() => organiseActions;

    protected override async Task<IEnumerable<IDataType>> GetAllAsync() => await dataTypeService.GetAllAsync();

    protected override async Task PostOrganiseAll()
    {
        await dataTypeContainerService.DeleteAllEmptyContainersAsync(dataTypeService);
    }
}