using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Nover.CMS.Domain.Shared;
using OpenIddict.Abstractions;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.ObjectMapping;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Uow;

namespace Nover.CMS.Domain;

/* Creates initial data that is needed to property run the application
 * and make client-to-server communication possible.
 */
public class MenuItemDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IConfiguration _configuration;
    private readonly IMenuItemRepository _menuItemRepository;
    private readonly IPermissionDataSeeder _permissionDataSeeder;
    private readonly IObjectMapper _objectMapper;
    private readonly IGuidGenerator _guidGenerator;
    private readonly IStringLocalizer<OpenIddictResponse> L;

    public MenuItemDataSeedContributor(
        IConfiguration configuration,
        IMenuItemRepository menuItemRepository,
        IPermissionDataSeeder permissionDataSeeder,
        IObjectMapper objectMapper,
        IGuidGenerator guidGenerator,
        IStringLocalizer<OpenIddictResponse> l)
    {
        _configuration = configuration;
        _menuItemRepository = menuItemRepository;
        _permissionDataSeeder = permissionDataSeeder;
        _guidGenerator = guidGenerator;
        _objectMapper = objectMapper;
        L = l;
    }

    [UnitOfWork]
    public virtual Task SeedAsync(DataSeedContext context)
    {
        /*
        var configurationSection = _configuration.GetSection("DynamicMenu:MenuData");
        var menuItemEtos = configurationSection.Get<List<TryCreateMenuItemEto>>();
        var menuItems = new List<MenuItem>();
        menuItemEtos.ForEach(x =>
        {
            x.Id = _guidGenerator.Create();
            x.DisplayName = x.Name;
            x.MenuItems.ForEach(y =>
            {
                y.Id = _guidGenerator.Create();
                y.ParentId = x.Id;
                y.DisplayName = y.Name;
                y.MenuItems.ForEach(z =>
                {
                    z.Id = _guidGenerator.Create();
                    z.ParentId = y.Id;
                    z.DisplayName = z.Name;
                    menuItems.Add(_objectMapper.Map<TryCreateMenuItemEto, MenuItem>(z));
                });
                menuItems.Add(_objectMapper.Map<TryCreateMenuItemEto, MenuItem>(y));
            });
            menuItems.Add(_objectMapper.Map<TryCreateMenuItemEto, MenuItem>(x));
        });


        return _menuItemRepository.InsertManyAsync(menuItems);
        */
       return Task.CompletedTask;
    }
}
