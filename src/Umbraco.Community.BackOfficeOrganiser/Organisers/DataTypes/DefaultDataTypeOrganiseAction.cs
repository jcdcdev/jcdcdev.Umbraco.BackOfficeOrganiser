using jcdcdev.Umbraco.Core.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;
using Umbraco.Community.BackOfficeOrganiser.Models;
using Umbraco.Extensions;

namespace Umbraco.Community.BackOfficeOrganiser.Organisers.DataTypes;

public class DefaultDataTypeOrganiseAction(IOptions<BackOfficeOrganiserOptions> options, ILogger<DefaultDataTypeOrganiseAction> logger) : IDataTypeOrganiseAction
{
    private readonly ILogger _logger = logger;
    private readonly BackOfficeOrganiserOptions _options = options.Value;

    public bool CanMove(IDataType dataType, IDataTypeService dataTypeService) => true;

    public async Task MoveAsync(IDataType dataType, IDataTypeService dataTypeService)
    {
        string internalFolder;
        if (dataType.IsInternalUmbracoEditor())
        {
            internalFolder = _options.DataTypes.InternalFolderName;
        }
        else if (dataType.IsUmbracoEditor())
        {
            internalFolder = _options.DataTypes.CustomFolderName;
        }
        else
        {
            internalFolder = _options.DataTypes.ThirdPartyFolderName;
        }

        var parentFolder = dataTypeService.GetOrCreateFolder(internalFolder);
        var folder = GetFolderName(dataType);
        if (folder.IsNullOrWhiteSpace())
        {
            _logger.LogWarning("Failed to determine folder name. {DataType} will be considered Custom", dataType.Name);
            await dataTypeService.MoveAsync(dataType, parentFolder.Key, global::Umbraco.Cms.Core.Constants.Security.SuperUserKey);
            return;
        }

        var dataTypeFolder = dataTypeService.GetOrCreateFolder(folder, parentFolder.Id);
        await dataTypeService.MoveAsync(dataType, dataTypeFolder.Key, global::Umbraco.Cms.Core.Constants.Security.SuperUserKey);
    }

    private static string ResolveDataTypeFolderName(IDataType dataType)
    {
        var segments = dataType.EditorAlias.Split(".").SkipLast(1);
        return string.Join(".", segments);
    }

    private static string GetFolderName(IDataType dataType)
    {
        var folder = dataType.EditorAlias switch
        {
            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.BlockList => "Block List",

            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.NestedContent => "Nested Content",

            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.BlockGrid => "Grid",
            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.Grid => "Grid",

            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.ImageCropper => "Image Cropper",

            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.ListView => "List View",

            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.Boolean => "Checkbox",
            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.UploadField => "Upload",

            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.Tags => "Tags",

            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.CheckBoxList => "List",
            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.DropDownListFlexible => "List",
            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.RadioButtonList => "List",

            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.ColorPickerEyeDropper => "Picker",
            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.ColorPicker => "Picker",
            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.ContentPicker => "Picker",
            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.MultipleMediaPicker => "Picker",
            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.MemberPicker => "Picker",
            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.MemberGroupPicker => "Picker",
            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.MultiNodeTreePicker => "Picker",
            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.MediaPicker3 => "Picker",
            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.UserPicker => "Picker",
            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.MultiUrlPicker => "Picker",
            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.PickerRelations => "Picker",

            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.Decimal => "Number",
            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.Slider => "Number",
            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.Integer => "Number",

            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.DateTime => "Date",

            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.MultipleTextstring => "Text",
            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.TextBox => "Text",
            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.TextArea => "Text",
            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.EmailAddress => "Text",
            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.Label => "Text",

            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.TinyMce => "Rich Text",
            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.RichText => "Rich Text",
            global::Umbraco.Cms.Core.Constants.PropertyEditors.Aliases.MarkdownEditor => "Rich Text",

            _ => ResolveDataTypeFolderName(dataType)
        };
        return folder;
    }
}