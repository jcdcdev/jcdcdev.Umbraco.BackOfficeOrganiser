using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;

namespace Umbraco.Community.BackOfficeOrganiser.Core.OrganiseActions;

public interface IDataTypeOrganiseAction : IOrganiseAction
{
    public bool CanMove(IDataType dataType, IDataTypeService dataTypeService, IDataTypeContainerService dataTypeContainerService);
    public Task MoveAsync(IDataType dataType, IDataTypeService dataTypeService, IDataTypeContainerService dataTypeContainerService);
}

public interface IOrganiseAction
{
    public string Name { get; }
    public string Description { get; }
}