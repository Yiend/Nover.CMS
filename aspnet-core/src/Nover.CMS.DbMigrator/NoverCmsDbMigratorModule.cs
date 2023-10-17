using Nover.CMS.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace Nover.CMS.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(NoverCmsEntityFrameworkCoreModule),
    typeof(NoverCmsApplicationContractsModule)
    )]
public class NoverCmsDbMigratorModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        NoverCmsDbProperties.ConfigureDbProperties();
    }
}
