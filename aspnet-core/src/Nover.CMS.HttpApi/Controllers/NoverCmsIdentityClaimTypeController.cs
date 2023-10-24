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

        [HttpGet]
        public virtual Task<PagedResultDto<ClaimTypeDto>> GetListAsync(GetIdentityClaimTypesInput input)
        {
            return this.ClaimTypeAppService.GetListAsync(input);
        }

        [Route("all")]
        [HttpGet]
        public virtual Task<List<ClaimTypeDto>> GetAllListAsync()
        {
            return this.ClaimTypeAppService.GetAllListAsync();
        }

        [Route("{id}")]
        [HttpGet]
        public virtual Task<ClaimTypeDto> GetAsync(Guid id)
        {
            return this.ClaimTypeAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ClaimTypeDto> CreateAsync(CreateClaimTypeDto input)
        {
            return this.ClaimTypeAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ClaimTypeDto> UpdateAsync(Guid id, UpdateClaimTypeDto input)
        {
            return this.ClaimTypeAppService.UpdateAsync(id, input);
        }

        [Route("{id}")]
        [HttpDelete]
        public virtual Task DeleteAsync(Guid id)
        {
            return this.ClaimTypeAppService.DeleteAsync(id);
        }
    }
}
