using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;

namespace Nover.CMS.Application.Contracts.Dtos
{
    public abstract class OrganizationUnitCreateOrUpdateDtoBase : ExtensibleObject
    {
        [DynamicStringLength(typeof(OrganizationUnitConsts), nameof(OrganizationUnitConsts.MaxDisplayNameLength))]
        public string DisplayName { get; set; }

        protected OrganizationUnitCreateOrUpdateDtoBase() : base(false)
        {

        }
    }

    public class OrganizationUnitCreateDto : OrganizationUnitCreateOrUpdateDtoBase
    {
        public Guid? ParentId { get; set; }       
    }


    public class OrganizationUnitUpdateDto : OrganizationUnitCreateOrUpdateDtoBase, IHasConcurrencyStamp
    {
        public string ConcurrencyStamp { get; set; }
    }
}
