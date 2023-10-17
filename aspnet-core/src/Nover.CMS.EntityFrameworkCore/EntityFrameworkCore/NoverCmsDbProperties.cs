using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Data;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.OpenIddict;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.CmsKit;

namespace Nover.CMS.EntityFrameworkCore
{
    public static class NoverCmsDbProperties
    {
        public static string DbTablePrefix { get; set; } = "n_";

        public static void ConfigureDbProperties()
        {
            AbpPermissionManagementDbProperties.DbTablePrefix = DbTablePrefix;
            AbpSettingManagementDbProperties.DbTablePrefix = DbTablePrefix;
            AbpBackgroundJobsDbProperties.DbTablePrefix = DbTablePrefix;
            AbpAuditLoggingDbProperties.DbTablePrefix = DbTablePrefix;
            AbpIdentityDbProperties.DbTablePrefix = DbTablePrefix;
            AbpOpenIddictDbProperties.DbTablePrefix = DbTablePrefix + "OpenIddict";
            AbpFeatureManagementDbProperties.DbTablePrefix = DbTablePrefix;
            AbpTenantManagementDbProperties.DbTablePrefix = DbTablePrefix;
            AbpCmsKitDbProperties.DbTablePrefix = DbTablePrefix + "Cms";
        }

    }

}
