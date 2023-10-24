using Nover.CMS.Application.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Nover.CMS.Application.Contracts
{
    public interface INoverCmsIdentityClaimTypeAppService : ICrudAppService<ClaimTypeDto, Guid, GetIdentityClaimTypesInput, CreateClaimTypeDto, UpdateClaimTypeDto>
    {
        Task<List<ClaimTypeDto>> GetAllListAsync();
    }
}
