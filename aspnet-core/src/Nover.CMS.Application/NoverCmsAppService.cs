using System;
using System.Collections.Generic;
using System.Text;
using Nover.CMS.Localization;
using Volo.Abp.Application.Services;

namespace Nover.CMS;

/* Inherit your application services from this class.
 */
public abstract class NoverCmsAppService : ApplicationService
{
    protected NoverCmsAppService()
    {
        LocalizationResource = typeof(CMSResource);
    }
}
