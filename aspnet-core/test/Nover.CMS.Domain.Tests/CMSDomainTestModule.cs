using Nover.CMS.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Nover.CMS;

[DependsOn(
    typeof(CMSEntityFrameworkCoreTestModule)
    )]
public class CMSDomainTestModule : AbpModule
{

}
