using jcdcdev.Umbraco.Core.Extensions;
using StackExchange.Profiling.Internal;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;
using Umbraco.Community.BackOfficeOrganiser.Core.OrganiseActions;

namespace Umbraco.Community.BackOfficeOrganiser.Infrastructure.OrganiseActions;

public class DefaultMediaTypeOrganiseAction : IMediaTypeOrganiseAction
{
    public bool CanMove(IMediaType mediaType, IMediaTypeService mediaTypeService) => true;

    public async Task MoveAsync(IMediaType mediaType, IMediaTypeService mediaTypeService)
    {
        var folderKey = Cms.Core.Constants.System.RootKey;
        var parentId = Cms.Core.Constants.System.Root;
        var folderName = string.Empty;

        if (mediaType.IsInternal())
        {
            var parent = mediaTypeService.GetOrCreateFolder("Internal");
            folderKey = parent.Key;
            folderName = mediaType.Alias switch
            {
                Cms.Core.Constants.Conventions.MediaTypes.File => string.Empty,
                Cms.Core.Constants.Conventions.MediaTypes.Folder => string.Empty,
                Cms.Core.Constants.Conventions.MediaTypes.VideoAlias => "Video",
                Cms.Core.Constants.Conventions.MediaTypes.AudioAlias => "Audio",
                Cms.Core.Constants.Conventions.MediaTypes.ArticleAlias => "Text File",
                Cms.Core.Constants.Conventions.MediaTypes.VectorGraphicsAlias => "Image",
                Cms.Core.Constants.Conventions.MediaTypes.Image => "Image",
                _ => folderName
            };
        }

        if (mediaType.IsElement)
        {
            folderName = "Element Types";
        }

        if (!folderName.IsNullOrWhiteSpace())
        {
            folderKey = mediaTypeService.GetOrCreateFolder(folderName, parentId).Key;
        }

        await mediaTypeService.MoveAsync(mediaType.Key, folderKey);
    }

    public string Name => "Default Media Type Organise Action";
    public string Description => "Organises media types into folders based on their alias.";
}