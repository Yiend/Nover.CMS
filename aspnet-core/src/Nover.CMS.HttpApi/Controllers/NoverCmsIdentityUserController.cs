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

        /// <summary>
        /// 添加到组织单位
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="ouIds">组织Id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{userId}/add-to-organizations")]
        public virtual Task AddToOrganizationUnitsAsync(Guid userId, List<Guid> ouIds)
        {
            return IdentityUserAppService.AddToOrganizationUnitsAsync(userId, ouIds);
        }

        /// <summary>
        /// 创建用户到组织
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create-to-organizations")]
        public virtual Task<IdentityUserDto> CreateAsync(IdentityUserOrgCreateDto input)
        {
            return IdentityUserAppService.CreateAsync(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeDetails"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/organizations")]
        public virtual Task<ListResultDto<OrganizationUnitDto>> GetListOrganizationUnitsAsync(Guid id, bool includeDetails = false)
        {
            return IdentityUserAppService.GetListOrganizationUnitsAsync(id, includeDetails);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}/update-to-organizations")]
        public virtual Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserOrgUpdateDto input)
        {
            return IdentityUserAppService.UpdateAsync(id, input);
        }
    }
}
