namespace Umbraco.Community.BackOfficeOrganiser.Core.Models;

public class DataTypeOptions
{
    public string InternalFolderName { get; set; } = "🔒 Internal";
    public string ThirdPartyFolderName { get; set; } = "🦄 Third Party";
    public string CustomFolderName { get; set; } = "🔧 Custom";
    public bool OrganiseOnSave { get; set; } = true;
}