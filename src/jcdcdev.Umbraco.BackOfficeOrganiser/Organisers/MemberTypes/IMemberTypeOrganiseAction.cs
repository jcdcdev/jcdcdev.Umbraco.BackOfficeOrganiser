using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;

namespace jcdcdev.Umbraco.BackOfficeOrganiser.Organisers.MemberTypes;

public interface IMemberTypeOrganiseAction
{
    public bool CanMove(IMemberType memberType, IMemberTypeService memberTypeService);
    public void Move(IMemberType memberType, IMemberTypeService memberTypeService);
}