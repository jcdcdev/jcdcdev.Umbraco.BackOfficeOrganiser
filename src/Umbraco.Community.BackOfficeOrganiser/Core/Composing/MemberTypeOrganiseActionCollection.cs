using Umbraco.Cms.Core.Composing;
using Umbraco.Community.BackOfficeOrganiser.Core.OrganiseActions;

namespace Umbraco.Community.BackOfficeOrganiser.Core.Composing;

public class MemberTypeOrganiseActionCollection(Func<IEnumerable<IMemberTypeOrganiseAction>> items) : BuilderCollectionBase<IMemberTypeOrganiseAction>(items);