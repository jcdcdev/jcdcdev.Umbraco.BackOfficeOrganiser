using Umbraco.Cms.Core.DependencyInjection;

namespace Umbraco.Community.BackOfficeOrganiser.Core.Composing;

public static class UmbracoBuilderExtensions
{
    public static DataTypeOrganiseActionCollectionBuilder DataTypeOrganiseActions(this IUmbracoBuilder builder) => builder.WithCollectionBuilder<DataTypeOrganiseActionCollectionBuilder>();

    public static ContentTypeOrganiseActionCollectionBuilder ContentTypeOrganiseActions(this IUmbracoBuilder builder) => builder.WithCollectionBuilder<ContentTypeOrganiseActionCollectionBuilder>();

    public static MediaTypeOrganiseActionCollectionBuilder MediaTypeOrganiseActions(this IUmbracoBuilder builder) => builder.WithCollectionBuilder<MediaTypeOrganiseActionCollectionBuilder>();

    public static MemberTypeOrganiseActionCollectionBuilder MemberTypeOrganiseActions(this IUmbracoBuilder builder) => builder.WithCollectionBuilder<MemberTypeOrganiseActionCollectionBuilder>();
}