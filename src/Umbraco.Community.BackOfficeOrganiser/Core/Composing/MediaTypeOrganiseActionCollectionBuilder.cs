using Umbraco.Cms.Core.Composing;
using Umbraco.Community.BackOfficeOrganiser.Core.OrganiseActions;

namespace Umbraco.Community.BackOfficeOrganiser.Core.Composing;

public class MediaTypeOrganiseActionCollectionBuilder : OrderedCollectionBuilderBase<MediaTypeOrganiseActionCollectionBuilder, MediaTypeOrganiseActionCollection, IMediaTypeOrganiseAction>
{
    protected override MediaTypeOrganiseActionCollectionBuilder This => this;
}