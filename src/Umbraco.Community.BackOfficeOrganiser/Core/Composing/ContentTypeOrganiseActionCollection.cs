using Umbraco.Cms.Core.Composing;
using Umbraco.Community.BackOfficeOrganiser.Core.OrganiseActions;

namespace Umbraco.Community.BackOfficeOrganiser.Core.Composing;

public class ContentTypeOrganiseActionCollection(Func<IEnumerable<IContentTypeOrganiseAction>> items) : BuilderCollectionBase<IContentTypeOrganiseAction>(items);