using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;

namespace Umbraco.Community.BackOfficeOrganiser.Core.OrganiseActions;

public interface IContentTypeOrganiseAction: IOrganiseAction
{
    public bool CanMove(IContentType contentType, IContentTypeService contentTypeService);
    public Task MoveAsync(IContentType contentType, IContentTypeService contentTypeService);
}