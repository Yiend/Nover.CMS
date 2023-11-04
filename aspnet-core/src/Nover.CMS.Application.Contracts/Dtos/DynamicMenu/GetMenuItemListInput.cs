using System;
using Volo.Abp.Application.Dtos;

namespace Nover.CMS.Application.Contracts.Dtos
{
    public class GetMenuItemListInput : PagedAndSortedResultRequestDto
    {
        public Guid ParentId { get; set; }
    }
}