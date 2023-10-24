using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Nover.CMS.Application.Contracts.Dtos
{
    public class GetAllOrgnizationUnitInput : ISortedResultRequest
    {
        public GetAllOrgnizationUnitInput()
        {
            Sorting = "Code";
        }
        public string Filter { get; set; }
        public string Sorting { get; set; }
    }

    public class GetOrganizationUnitInput : PagedAndSortedResultRequestDto
    {
        public Guid? ParentId { get; set; }
        public string Filter { get; set; }
    }
}
