using AutoMapper;
using Nover.CMS.Application.Contracts.Dtos;
using Nover.CMS.Domain;
using Volo.Abp.OpenIddict.Applications;

namespace Nover.CMS;

public class NoverCmsApplicationAutoMapperProfile : Profile
{
    public NoverCmsApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<MenuItem, MenuItemDto>().MapExtraProperties();
        CreateMap<CreateMenuItemDto, MenuItem>(MemberList.Source).MapExtraProperties();
        CreateMap<UpdateMenuItemDto, MenuItem>(MemberList.Source).MapExtraProperties();

        CreateMap<OpenIddictApplication, OpenIddictApplicationDto>();
        CreateMap<OpenIddictApplicationInput, OpenIddictApplication>();
    }
}
