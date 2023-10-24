using Nover.CMS.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Localization;
using Volo.Abp.AuditLogging;
using Volo.Abp.AuditLogging.Localization;
using Nover.CMS.Application.Contracts.Permissions;

namespace Nover.CMS.Permissions;

public class NoverCmsPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(NoverCmsPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(CMSPermissions.MyPermission1, L("Permission:MyPermission1"));


        var identityGroup = context.GetGroup(IdentityPermissions.GroupName);

        var ouPermission = identityGroup.AddPermission(NoverCmsIdentityPermissions.OrganitaionUnits.Default, IdentityL("Permission:OrganitaionUnitManagement"));
        ouPermission.AddChild(NoverCmsIdentityPermissions.OrganitaionUnits.Create, IdentityL("Permission:Create"));
        ouPermission.AddChild(NoverCmsIdentityPermissions.OrganitaionUnits.Update, IdentityL("Permission:Edit"));
        ouPermission.AddChild(NoverCmsIdentityPermissions.OrganitaionUnits.Delete, IdentityL("Permission:Delete"));

        var userPermission = identityGroup.GetPermissionOrNull(IdentityPermissions.Users.Default);
        userPermission?.AddChild(NoverCmsIdentityPermissions.Users.DistributionOrganizationUnit, IdentityL("Permission:DistributionOrganizationUnit"));

        var rolePermission = identityGroup.GetPermissionOrNull(IdentityPermissions.Roles.Default);
        rolePermission?.AddChild(NoverCmsIdentityPermissions.Roles.AddOrganizationUnitRole, IdentityL("Permission:AddOrganizationUnitRole"));

        //Claim
        var claimPermission = identityGroup.AddPermission(NoverCmsIdentityPermissions.ClaimTypes.Default, IdentityL("Permission:ClaimManagement"));
        claimPermission.AddChild(NoverCmsIdentityPermissions.ClaimTypes.Create, IdentityL("Permission:Create"));
        claimPermission.AddChild(NoverCmsIdentityPermissions.ClaimTypes.Update, IdentityL("Permission:Edit"));
        claimPermission.AddChild(NoverCmsIdentityPermissions.ClaimTypes.Delete, IdentityL("Permission:Delete"));

        //AuditLogging
        var auditLogGroup = context.AddGroup(NoverCmsAuditLogPermissions.GroupName);
        var aduditLogPermission = auditLogGroup.AddPermission(NoverCmsAuditLogPermissions.AuditLogs.Default, AuditLoggingL("Permission:AuditLogManagement"));
        aduditLogPermission.AddChild(NoverCmsAuditLogPermissions.AuditLogs.Delete, AuditLoggingL("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CMSResource>(name);
    }

    private static LocalizableString IdentityL(string name)
    {
        return LocalizableString.Create<IdentityResource>(name);
    }

    private static LocalizableString AuditLoggingL(string name)
    {
        return LocalizableString.Create<AuditLoggingResource>(name);
    }

}
