using Microsoft.Extensions.Logging;
using Umbraco.Community.BackOfficeOrganiser.Core.OrganiseActions;

namespace Umbraco.Community.BackOfficeOrganiser.Core.Organisers;

public abstract class BackOfficeOrganiserBase<T>(ILogger logger) : IBackOfficeOrganiser<T>
{
    public readonly ILogger Logger = logger;

    public async Task OrganiseAllAsync()
    {
        Logger.LogInformation("BackOfficeOrganiser: Cleanup for {Type} Started", typeof(T).Name);

        try
        {
            var items = await GetAllAsync();
            foreach (var item in items)
            {
                await OrganiseAsync(item);
            }

            await PostOrganiseAll();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "BackOfficeOrganiser: Cleanup for {Type} Failed", typeof(T).Name);
            return;
        }

        Logger.LogInformation("BackOfficeOrganiser: Cleanup for {Type} Complete", typeof(T).Name);
    }

    public abstract Task OrganiseAsync(T item);
    public abstract IEnumerable<IOrganiseAction> GetOrganiseActions();

    protected virtual Task PostOrganiseAll() => Task.CompletedTask;

    protected abstract Task<IEnumerable<T>> GetAllAsync();
}