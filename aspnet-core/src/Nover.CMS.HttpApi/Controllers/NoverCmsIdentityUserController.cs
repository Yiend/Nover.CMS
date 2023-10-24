using Microsoft.AspNetCore.Mvc;
using Nover.CMS.Application.Contracts;
using Nover.CMS.Application.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace Nover.CMS.HttpApi.Controllers
{
    [RemoteService(Name = IdentityRemoteServiceConsts.RemoteServiceName)]
    [Area("identity")]
    [ControllerName("User")]
    [Route("api/identity/users")]
    public class NoverCmsIdentityUserController : NoverCmsController, INoverCmsIdentityUserAppService
    {
        protected INoverCmsIdentityUserAppService IdentityUserAppService { get; }

        public NoverCmsIdentityUserController(INoverCmsIdentityUserAppService identityUserAppService) 
        {
            IdentityUserAppService = identityUserAppService;
        }

        [HttpPost]
        [Route("{userId}/add-to-organizations")]
        public virtual Task AddToOrganizationUnitsAsync(Guid userId, List<Guid> ouIds)
        {
            return IdentityUserAppService.AddToOrganizationUnitsAsync(userId, ouIds);
        }

        [HttpPost]
        [Route("create-to-organizations")]
        public virtual Task<IdentityUserDto> CreateAsync(IdentityUserOrgCreateDto input)
        {
            return IdentityUserAppService.CreateAsync(input);
        }

        [HttpGet]
        [Route("{id}/organizations")]
        public virtual Task<ListResultDto<OrganizationUnitDto>> GetListOrganizationUnitsAsync(Guid id, bool includeDetails = false)
        {
            return IdentityUserAppService.GetListOrganizationUnitsAsync(id, includeDetails);
        }

        [HttpPut]
        [Route("{id}/update-to-organizations")]
        public virtual Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserOrgUpdateDto input)
        {
            return IdentityUserAppService.UpdateAsync(id, input);
        }
    }
}
