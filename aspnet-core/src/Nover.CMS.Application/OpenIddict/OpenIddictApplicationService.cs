using Microsoft.AspNetCore.Authorization;
using Nover.CMS.Application.Contracts;
using Nover.CMS.Application.Contracts.Dtos;
using Nover.CMS.Permissions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.OpenIddict.Applications;

namespace Nover.CMS.Application;

/// <inheritdoc />
[Authorize(NoverCmsPermissions.OpenIddictApplication.Default)]
public class OpenIddictApplicationService : ApplicationService, IOpenIddictApplicationService
{
    private readonly IOpenIddictApplicationRepository _openIddictApplicationRepository;
    private readonly IRepository<OpenIddictApplication, Guid> _openIddictApplicationRepositoryGuid;

    public OpenIddictApplicationService(IOpenIddictApplicationRepository openIddictApplicationRepository, IRepository<OpenIddictApplication, Guid> openIddictApplicationRepositoryGuid)
    {
        _openIddictApplicationRepository = openIddictApplicationRepository;
        _openIddictApplicationRepositoryGuid = openIddictApplicationRepositoryGuid;
    }

    /// <inheritdoc/>
    public async Task CreateAsync(OpenIddictApplicationInput input)
    {
        var data = ObjectMapper.Map<OpenIddictApplicationInput, OpenIddictApplication>(input);

        data.ClientId = Guid.NewGuid().ToString("N");
        data.ClientSecret = Guid.NewGuid().ToString("N");

        if (await _openIddictApplicationRepositoryGuid.AnyAsync(x => x.ClientId == data.ClientId))
        {
            data.ClientId = Guid.NewGuid().ToString("N");
        }

        await _openIddictApplicationRepository.InsertAsync(data);
    }

    /// <inheritdoc />
    [Authorize(NoverCmsPermissions.OpenIddictApplication.List)]
    public async Task<PagedResultDto<OpenIddictApplicationDto>> GetListAsync(GetOpenIddictListInput input)
    {
        var data = await _openIddictApplicationRepository
            .GetListAsync(nameof(OpenIddictApplication.CreationTime), input.SkipCount, input.MaxResultCount, input.Keywords);

        var count = await _openIddictApplicationRepository.GetCountAsync(input.Keywords);

        var dto = ObjectMapper.Map<List<OpenIddictApplication>, List<OpenIddictApplicationDto>>(data);

        return new PagedResultDto<OpenIddictApplicationDto>(count, dto);
    }

    /// <inheritdoc />
    [Authorize(NoverCmsPermissions.OpenIddictApplication.Update)]
    public async Task UpdateAsync(OpenIddictApplicationInput input)
    {
        var data = await _openIddictApplicationRepositoryGuid.FirstOrDefaultAsync(x =>
            x.Id == input.Id && x.ClientId == input.ClientId);

        if (data == null)
        {
            throw new BusinessException("DataNotFound");
        }

        data.ClientUri = input.ClientUri;
        data.ConsentType = input.ConsentType;
        data.DisplayName = input.DisplayName;
        data.LogoUri = input.LogoUri;
        data.Permissions = input.Permissions;
        data.Type = input.Type;
        await _openIddictApplicationRepositoryGuid.UpdateAsync(data);
    }
}