using Nover.CMS.Application.Contracts.Dtos;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.CmsKit;

namespace Nover.CMS;

[DependsOn(
    typeof(NoverCmsDomainSharedModule),
    typeof(AbpAccountApplicationContractsModule),
    typeof(AbpFeatureManagementApplicationContractsModule),
    typeof(AbpIdentityApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationContractsModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpTenantManagementApplicationContractsModule),
    typeof(AbpObjectExtendingModule)
)]
[DependsOn(typeof(CmsKitApplicationContractsModule))]
    public class NoverCmsApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        NoverCmsDtoExtensions.Configure();

        ModuleExtensionConfigurationHelper
              .ApplyEntityConfigurationToApi(
                  IdentityModuleExtensionConsts.ModuleName,
                  IdentityModuleExtensionConsts.EntityNames.OrganizationUnit,
                  getApiTypes: new[] { typeof(OrganizationUnitDto) },
                  createApiTypes: new[] { typeof(OrganizationUnitCreateDto) },
                  updateApiTypes: new[] { typeof(OrganizationUnitUpdateDto) }
              );
    }
}
