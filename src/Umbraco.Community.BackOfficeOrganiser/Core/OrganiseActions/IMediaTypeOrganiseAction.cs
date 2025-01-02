using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;

namespace Umbraco.Community.BackOfficeOrganiser.Core.OrganiseActions;

public interface IMediaTypeOrganiseAction: IOrganiseAction
{
    public bool CanMove(IMediaType mediaType, IMediaTypeService mediaTypeService);
    public Task MoveAsync(IMediaType mediaType, IMediaTypeService mediaTypeService);
}