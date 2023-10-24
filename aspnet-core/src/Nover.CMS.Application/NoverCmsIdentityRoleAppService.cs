using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using Nover.CMS.Application.Contracts;
using Nover.CMS.Application.Contracts.Dtos;
using Nover.CMS.Application.Contracts.Permissions;
using Nover.CMS.Localization;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;

namespace Nover.CMS.Application
{
    [RemoteService(IsEnabled = false)]
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IIdentityRoleAppService), typeof(IdentityRoleAppService), typeof(INoverCmsIdentityRoleAppService), typeof(NoverCmsIdentityRoleAppService))]
    public class NoverCmsIdentityRoleAppService : IdentityRoleAppService, INoverCmsIdentityRoleAppService
    {
        private IStringLocalizer<CMSResource> _localizer;
        protected OrganizationUnitManager OrgManager { get; }
        public NoverCmsIdentityRoleAppService(IdentityRoleManager roleManager,
            IIdentityRoleRepository roleRepository,
            IStringLocalizer<CMSResource> localizer,
            OrganizationUnitManager orgManager) : base(roleManager, roleRepository)
        {
            _localizer = localizer;
            OrgManager = orgManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="ouId"></param>
        /// <returns></returns>
        [Authorize(NoverCmsIdentityPermissions.Roles.AddOrganizationUnitRole)]
        public Task AddToOrganizationUnitAsync(Guid roleId, Guid ouId)
        {
            return OrgManager.AddRoleToOrganizationUnitAsync(roleId, ouId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(IdentityPermissions.Roles.Create)]
        [Authorize(NoverCmsIdentityPermissions.Roles.AddOrganizationUnitRole)]
        public virtual async Task<IdentityRoleDto> CreateAsync(IdentityRoleOrgCreateDto input)
        {
            var role = await base.CreateAsync(
                ObjectMapper.Map<IdentityRoleOrgCreateDto, IdentityRoleCreateDto>(input)
            );
            if (input.OrgId.HasValue)
            {
                await OrgManager.AddRoleToOrganizationUnitAsync(role.Id, input.OrgId.Value);
            }
            return role;
        }
    }
}
