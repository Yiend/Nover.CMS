using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Application.Services;
using Nover.CMS.Application.Contracts.Dtos;
using Nover.CMS.Application.Contracts;
using Nover.CMS.Domain;
using Nover.CMS.Permissions;
using Volo.Abp;

namespace Nover.CMS.Application
{
    public class MenuItemAppService : AbstractKeyCrudAppService<MenuItem, MenuItemDto, MenuItemKey, GetMenuItemListInput, CreateMenuItemDto, UpdateMenuItemDto>, IMenuItemAppService
    {
        protected override string GetPolicyName { get; set; } = null;
        protected override string GetListPolicyName { get; set; } = null;
        protected override string CreatePolicyName { get; set; } = NoverCmsPermissions.MenuItem.Create;
        protected override string UpdatePolicyName { get; set; } = NoverCmsPermissions.MenuItem.Update;
        protected override string DeletePolicyName { get; set; } = NoverCmsPermissions.MenuItem.Delete;

        private readonly IMenuItemRepository _repository;

        public MenuItemAppService(IMenuItemRepository repository) : base(repository)
        {
            _repository = repository;
        }

        protected override async Task<IQueryable<MenuItem>> CreateFilteredQueryAsync(GetMenuItemListInput input)
        {
            return (await _repository.WithDetailsAsync()).Where(x => x.ParentId == input.ParentId);
        }

        protected override Task DeleteByIdAsync(MenuItemKey id)
        {
            // TODO: AbpHelper generated
            return _repository.DeleteAsync(e =>
                e.Name == id.Name
            );
        }

        protected override async Task<MenuItem> GetEntityByIdAsync(MenuItemKey id)
        {
            // TODO: AbpHelper generated
            return await AsyncExecuter.FirstOrDefaultAsync((await _repository.WithDetailsAsync()).Where(e => e.Name == id.Name));
        }

        protected override IQueryable<MenuItem> ApplyDefaultSorting(IQueryable<MenuItem> query)
        {
            // TODO: AbpHelper generated
            return query.OrderBy(e => e.Name);
        }

        public override async Task<MenuItemDto> CreateAsync(CreateMenuItemDto input)
        {
            await CheckCreatePolicyAsync();

            await CheckParentNameAsync(input.ParentName);

            var entity = await MapToEntityAsync(input);

            TryToSetTenantId(entity);

            await Repository.InsertAsync(entity, autoSave: true);

            return await MapToGetOutputDtoAsync(entity);
        }

        public override async Task<MenuItemDto> UpdateAsync(MenuItemKey id, UpdateMenuItemDto input)
        {
            await CheckUpdatePolicyAsync();

            await CheckParentNameAsync(input.ParentName);

            var entity = await GetEntityByIdAsync(id);

            await MapToEntityAsync(input, entity);

            await Repository.UpdateAsync(entity, autoSave: true);

            return await MapToGetOutputDtoAsync(entity);
        }

        public override async Task DeleteAsync(MenuItemKey id)
        {
            await CheckDeletePolicyAsync();

            var menuItem = await GetEntityByIdAsync(id);

            await RecursiveDeleteAsync(menuItem);

            await CurrentUnitOfWork.SaveChangesAsync();
        }

        protected virtual async Task RecursiveDeleteAsync(MenuItem menuItem)
        {
            if (!menuItem.MenuItems.IsNullOrEmpty())
            {
                foreach (var subItem in menuItem.MenuItems)
                {
                    await RecursiveDeleteAsync(subItem);
                }
            }

            await _repository.DeleteAsync(menuItem);
        }

        protected async Task CheckParentNameAsync([CanBeNull] string parentName)
        {
            if (parentName == null)
            {
                return;
            }

            var parent = await _repository.FindAsync(x => x.Name == parentName);

            if (parent == null)
            {
                throw new BusinessException("DynamicMenu:NonexistentParentMenuItem").WithData("ParentName", parentName);
            }

            // Maximum menu item level: 3
            if (parent.ParentId != Guid.Empty)
            {
                var grandparent = await _repository.GetAsync(x => x.Id == parent.ParentId);

                if (grandparent.ParentId != Guid.Empty)
                {
                    throw new BusinessException("DynamicMenu:ExceededMenuLevelLimit").WithData("MaxLevel", 3);
                }
            }
        }
    }
}