using Umbraco.Cms.Core.Composing;
using Umbraco.Community.BackOfficeOrganiser.Core.OrganiseActions;

namespace Umbraco.Community.BackOfficeOrganiser.Core.Composing;

public class ContentTypeOrganiseActionCollectionBuilder : OrderedCollectionBuilderBase<ContentTypeOrganiseActionCollectionBuilder, ContentTypeOrganiseActionCollection, IContentTypeOrganiseAction>
{
    protected override ContentTypeOrganiseActionCollectionBuilder This => this;
}