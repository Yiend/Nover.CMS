using Nover.CMS.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Nover.CMS.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class NoverCmsController : AbpControllerBase
{
    protected NoverCmsController()
    {
        LocalizationResource = typeof(CMSResource);
    }
}
