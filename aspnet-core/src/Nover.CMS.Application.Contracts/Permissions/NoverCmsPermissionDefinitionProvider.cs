using Nover.CMS.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Nover.CMS.Permissions;

public class NoverCmsPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(NoverCmsPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(CMSPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CMSResource>(name);
    }
}
