using Microsoft.AspNetCore.Mvc;
using Nover.CMS.Application.Contracts;
using Nover.CMS.Application.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace Nover.CMS.HttpApi.Controllers;


[RemoteService(Name = IdentityRemoteServiceConsts.RemoteServiceName)]
[Area("identity")]
[ControllerName("Organization")]
[Route("api/identity/organizations")]
public abstract class NoverCmsOrganizationUnitController : NoverCmsController, INoverCmsOrganizationUnitAppService   
{
    protected INoverCmsOrganizationUnitAppService UnitAppService { get; }
    public NoverCmsOrganizationUnitController(INoverCmsOrganizationUnitAppService unitAppService)
    {
        UnitAppService = unitAppService;
    }

    /// <summary>
    /// 创建组织单位
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public virtual Task<OrganizationUnitDto> CreateAsync(OrganizationUnitCreateDto input)
    {
        return UnitAppService.CreateAsync(input);
    }

    /// <summary>
    /// 删除组织单位
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("{id}")]
    public virtual Task DeleteAsync(Guid id)
    {
        return UnitAppService.DeleteAsync(id);
    }

    /// <summary>
    /// 获取组织单位列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("all")]
    public virtual Task<ListResultDto<OrganizationUnitDto>> GetAllListAsync(GetAllOrgnizationUnitInput input)
    {
        return UnitAppService.GetAllListAsync(input);
    }

    /// <summary>
    /// 根据Id,获取组织单位
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{id}")]
    public virtual Task<OrganizationUnitDto> GetAsync(Guid id)
    {
        return UnitAppService.GetAsync(id);
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public virtual Task<PagedResultDto<OrganizationUnitDto>> GetListAsync(GetOrganizationUnitInput input)
    {
        return UnitAppService.GetListAsync(input);
    }

    /// <summary>
    /// 更新组织单位
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("{id}")]
    public virtual Task<OrganizationUnitDto> UpdateAsync(Guid id, OrganizationUnitUpdateDto input)
    {
        return UnitAppService.UpdateAsync(id, input);
    }

    /// <summary>
    /// 移动组织单位
    /// </summary>
    /// <param name="id"></param>
    /// <param name="parentId"></param>
    /// <returns></returns>
    [HttpPut]
    [Route("move")]
    public Task MoveAsync(Guid id, Guid? parentId)
    {
        return UnitAppService.MoveAsync(id, parentId);
    }

    /// <summary>
    /// 获取组织单位详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{id}/details")]
    public Task<OrganizationUnitDto> GetDetailsAsync(Guid id)
    {
        return UnitAppService.GetDetailsAsync(id);
    }

    /// <summary>
    /// 获取列表详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("details")]
    public Task<PagedResultDto<OrganizationUnitDto>> GetListDetailsAsync(GetOrganizationUnitInput input)
    {
        return UnitAppService.GetListDetailsAsync(input);
    }

    /// <summary>
    /// 获取所有列表详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("all/details")]
    public Task<ListResultDto<OrganizationUnitDto>> GetAllListDetailsAsync(GetAllOrgnizationUnitInput input)
    {
        return UnitAppService.GetAllListDetailsAsync(input);
    }

    /// <summary>
    /// 获取组织单位下级
    /// </summary>
    /// <param name="parentId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("children/{parentId}")]
    public Task<List<OrganizationUnitDto>> GetChildrenAsync(Guid parentId)
    {
        return UnitAppService.GetChildrenAsync(parentId);
    }

    /// <summary>
    /// 获取根组织
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("root")]
    public Task<ListResultDto<OrganizationUnitDto>> GetRootListAsync()
    {
        return UnitAppService.GetRootListAsync();
    }

    /// <summary>
    /// 获取下一个组织单位编码
    /// </summary>
    /// <param name="parentId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("next-code")]
    public Task<string> GetNextChildCodeAsync(Guid? parentId)
    {
        return UnitAppService.GetNextChildCodeAsync(parentId);
    }

    /// <summary>
    /// 获取组织单位用户
    /// </summary>
    /// <param name="ouId"></param>
    /// <param name="usersInput"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("users")]
    public Task<PagedResultDto<IdentityUserDto>> GetUsersAsync(Guid? ouId, GetIdentityUsersInput usersInput)
    {
        return UnitAppService.GetUsersAsync(ouId, usersInput);
    }

    /// <summary>
    /// 获取组织单位角色
    /// </summary>
    /// <param name="ouId"></param>
    /// <param name="roleInput"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("roles")]
    public Task<PagedResultDto<IdentityRoleDto>> GetRolesAsync(Guid? ouId, GetIdentityRolesInput roleInput)
    {
        return UnitAppService.GetRolesAsync(ouId, roleInput);
    }
}
