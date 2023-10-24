using Nover.CMS.Application.Contracts.Dtos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace Nover.CMS.Application.Contracts
{
    public interface INoverCmsIdentityRoleAppService : IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="ouId"></param>
        /// <returns></returns>
        Task AddToOrganizationUnitAsync(Guid roleId, Guid ouId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<IdentityRoleDto> CreateAsync(IdentityRoleOrgCreateDto input);
    }
}
