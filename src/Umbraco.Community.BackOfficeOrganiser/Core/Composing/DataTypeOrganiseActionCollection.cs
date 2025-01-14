using Umbraco.Cms.Core.Composing;
using Umbraco.Community.BackOfficeOrganiser.Core.OrganiseActions;

namespace Umbraco.Community.BackOfficeOrganiser.Core.Composing;

public class DataTypeOrganiseActionCollection(Func<IEnumerable<IDataTypeOrganiseAction>> items) : BuilderCollectionBase<IDataTypeOrganiseAction>(items);