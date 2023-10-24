using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Identity;

namespace Nover.CMS.Application.Contracts.Dtos
{
    public class IdentityUserOrgCreateDto : IdentityUserCreateDto
    {
        public List<Guid> OrgIds { get; set; }
    }

    public class IdentityUserOrgUpdateDto : IdentityUserUpdateDto
    {
        public List<Guid> OrgIds { get; set; }
    }
}
