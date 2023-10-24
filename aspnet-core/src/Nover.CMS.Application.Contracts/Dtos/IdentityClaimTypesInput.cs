using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Nover.CMS.Application.Contracts.Dtos
{
    public class GetIdentityClaimTypesInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }


}
