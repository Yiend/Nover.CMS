using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Nover.CMS.Application.Contracts.Dtos;
using Nover.CMS.Application.Contracts;

namespace Nover.CMS.HttpApi.Controllers
{
    [RemoteService(true, Name = IdentityRemoteServiceConsts.RemoteServiceName)]
    [Area("identity")]
    [ControllerName("ClaimType")]
    [Route("api/identity/claim-types")]
    public class NoverCmsIdentityClaimTypeController:NoverCmsController, INoverCmsIdentityClaimTypeAppService
    {
        protected INoverCmsIdentityClaimTypeAppService ClaimTypeAppService { get; }

        public NoverCmsIdentityClaimTypeController(INoverCmsIdentityClaimTypeAppService claimTypeAppService)
        {
            ClaimTypeAppService = claimTypeAppService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual Task<PagedResultDto<ClaimTypeDto>> GetListAsync(GetIdentityClaimTypesInput input)
        {
            return this.ClaimTypeAppService.GetListAsync(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("all")]
        [HttpGet]
        public virtual Task<List<ClaimTypeDto>> GetAllListAsync()
        {
            return this.ClaimTypeAppService.GetAllListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpGet]
        public virtual Task<ClaimTypeDto> GetAsync(Guid id)
        {
            return this.ClaimTypeAppService.GetAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual Task<ClaimTypeDto> CreateAsync(CreateClaimTypeDto input)
        {
            return this.ClaimTypeAppService.CreateAsync(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public virtual Task<ClaimTypeDto> UpdateAsync(Guid id, UpdateClaimTypeDto input)
        {
            return this.ClaimTypeAppService.UpdateAsync(id, input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpDelete]
        public virtual Task DeleteAsync(Guid id)
        {
            return this.ClaimTypeAppService.DeleteAsync(id);
        }
    }
}
