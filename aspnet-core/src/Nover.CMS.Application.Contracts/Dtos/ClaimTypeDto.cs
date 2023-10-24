using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;

namespace Nover.CMS.Application.Contracts.Dtos
{
    public class ClaimTypeDto : ExtensibleEntityDto<Guid>
    {
        public string Name { get; set; }

        public bool Required { get; set; }

        public bool IsStatic { get; set; }

        public string Regex { get; set; }

        public string RegexDescription { get; set; }

        public string Description { get; set; }

        public IdentityClaimValueType ValueType { get; set; }

        public string ValueTypeAsString { get; set; }
    }

    public class CreateClaimTypeDto : ExtensibleObject
    {
        public string Name { get; set; }

        public bool Required { get; set; }

        public string Regex { get; set; }

        public string RegexDescription { get; set; }

        public string Description { get; set; }

        public IdentityClaimValueType ValueType { get; set; }
    }

    public class UpdateClaimTypeDto : ExtensibleObject
    {
        public string Name { get; set; }

        public bool Required { get; set; }

        public string Regex { get; set; }

        public string RegexDescription { get; set; }

        public string Description { get; set; }

        public IdentityClaimValueType ValueType { get; set; }

        public UpdateClaimTypeDto()
            : base(false)
        {
        }
    }
}
