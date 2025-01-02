using Umbraco.Cms.Core.Composing;
using Umbraco.Community.BackOfficeOrganiser.Core.OrganiseActions;

namespace Umbraco.Community.BackOfficeOrganiser.Core.Composing;

public class MemberTypeOrganiseActionCollectionBuilder : OrderedCollectionBuilderBase<MemberTypeOrganiseActionCollectionBuilder, MemberTypeOrganiseActionCollection, IMemberTypeOrganiseAction>
{
    protected override MemberTypeOrganiseActionCollectionBuilder This => this;
}