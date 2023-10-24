﻿using Nover.CMS.Application.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace Nover.CMS.Application.Contracts
{
    public interface INoverCmsOrganizationUnitAppService : ICrudAppService<OrganizationUnitDto, Guid, GetOrganizationUnitInput, OrganizationUnitCreateDto, OrganizationUnitUpdateDto>
    {
        Task<ListResultDto<OrganizationUnitDto>> GetRootListAsync();

        Task<OrganizationUnitDto> GetDetailsAsync(Guid id);

        Task<PagedResultDto<OrganizationUnitDto>> GetListDetailsAsync(GetOrganizationUnitInput input);

        Task<ListResultDto<OrganizationUnitDto>> GetAllListAsync(GetAllOrgnizationUnitInput input);

        Task<ListResultDto<OrganizationUnitDto>> GetAllListDetailsAsync(GetAllOrgnizationUnitInput input);

        Task<List<OrganizationUnitDto>> GetChildrenAsync(Guid parentId);

        Task<string> GetNextChildCodeAsync(Guid? parentId);

        Task MoveAsync(Guid id, Guid? parentId);

        Task<PagedResultDto<IdentityUserDto>> GetUsersAsync(Guid? ouId, GetIdentityUsersInput userInput);
        Task<PagedResultDto<IdentityRoleDto>> GetRolesAsync(Guid? ouId, GetIdentityRolesInput roleInput);
    }
}
