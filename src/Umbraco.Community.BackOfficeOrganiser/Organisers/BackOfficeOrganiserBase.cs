using Microsoft.Extensions.Logging;

namespace Umbraco.Community.BackOfficeOrganiser.Organisers;

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

            PostOrganiseAll();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "BackOfficeOrganiser: Cleanup for {Type} Failed", typeof(T).Name);
            return;
        }

        Logger.LogInformation("BackOfficeOrganiser: Cleanup for {Type} Complete", typeof(T).Name);
    }

    public abstract Task OrganiseAsync(T item);

    protected virtual void PostOrganiseAll()
    {
    }

    protected abstract Task<IEnumerable<T>> GetAllAsync();
}