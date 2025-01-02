using Umbraco.Cms.Core.Composing;
using Umbraco.Community.BackOfficeOrganiser.Core.OrganiseActions;

namespace Umbraco.Community.BackOfficeOrganiser.Core.Composing;

public class MediaTypeOrganiseActionCollection(Func<IEnumerable<IMediaTypeOrganiseAction>> items) : BuilderCollectionBase<IMediaTypeOrganiseAction>(items);