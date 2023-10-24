using System;
using Volo.Abp.Identity;

namespace Nover.CMS.Application.Contracts.Dtos
{
    public class IdentityRoleOrgCreateDto : IdentityRoleCreateDto
    {
        public Guid? OrgId { get; set; }
    }
}
