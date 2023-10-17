using Volo.Abp.Modularity;

namespace Nover.CMS;

[DependsOn(
    typeof(NoverCmsApplicationModule),
    typeof(CMSDomainTestModule)
    )]
public class CMSApplicationTestModule : AbpModule
{

}
