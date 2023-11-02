using Volo.Abp.Application.Dtos;

namespace Nover.CMS.Application.Contracts.Dtos
{
    public class GetMenuItemListInput : PagedAndSortedResultRequestDto
    {
        public string ParentName { get; set; }
    }
}