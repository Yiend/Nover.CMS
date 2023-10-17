using Nover.CMS.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Nover.CMS.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class NoverCmsPageModel : AbpPageModel
{
    protected NoverCmsPageModel()
    {
        LocalizationResourceType = typeof(CMSResource);
    }
}
