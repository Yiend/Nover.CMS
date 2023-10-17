using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Nover.CMS.Web;

[Dependency(ReplaceServices = true)]
public class NoverCmsBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CMS";
}
