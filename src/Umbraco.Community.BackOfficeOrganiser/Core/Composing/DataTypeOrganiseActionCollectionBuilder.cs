using Umbraco.Cms.Core.Composing;
using Umbraco.Community.BackOfficeOrganiser.Core.OrganiseActions;

namespace Umbraco.Community.BackOfficeOrganiser.Core.Composing;

public class DataTypeOrganiseActionCollectionBuilder : OrderedCollectionBuilderBase<DataTypeOrganiseActionCollectionBuilder, DataTypeOrganiseActionCollection, IDataTypeOrganiseAction>
{
    protected override DataTypeOrganiseActionCollectionBuilder This => this;
}