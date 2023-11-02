using System;
using Nover.CMS.Application.Contracts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Nover.CMS.Application.Contracts
{
    public interface IMenuItemAppService : ICrudAppService<MenuItemDto, MenuItemKey, GetMenuItemListInput, CreateMenuItemDto, UpdateMenuItemDto>
    {
    }
}