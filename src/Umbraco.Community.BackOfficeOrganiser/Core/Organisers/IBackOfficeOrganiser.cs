using Umbraco.Community.BackOfficeOrganiser.Core.OrganiseActions;

namespace Umbraco.Community.BackOfficeOrganiser.Core.Organisers;

public interface IBackOfficeOrganiser<in T>
{
    Task OrganiseAllAsync();
    Task OrganiseAsync(T item);
    IEnumerable<IOrganiseAction> GetOrganiseActions();
}