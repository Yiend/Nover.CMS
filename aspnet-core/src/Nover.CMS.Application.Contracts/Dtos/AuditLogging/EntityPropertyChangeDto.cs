﻿using System;
using Volo.Abp.Application.Dtos;

namespace Nover.CMS.Application.Contracts.Dtos
{
    public class EntityPropertyChangeDto : EntityDto<Guid>
    {
        public string NewValue { get; set; }
        public string OriginalValue { get; set; }
        public string PropertyName { get; set; }
        public string PropertyTypeFullName { get; set; }
    }
}
