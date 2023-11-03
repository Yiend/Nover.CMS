using AutoMapper;
using Nover.CMS.Domain.Shared;

namespace Nover.CMS.Domain
{
    public class NoverCmsDomainAutoMapperProfile : Profile
    {
        public NoverCmsDomainAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            
            CreateMap<TryCreateMenuItemEto, MenuItem>(MemberList.Source).MapExtraProperties();
        }
    }
}
