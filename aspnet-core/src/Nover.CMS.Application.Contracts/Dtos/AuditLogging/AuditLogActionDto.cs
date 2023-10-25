using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;

namespace Nover.CMS.Application.Contracts.Dtos
{
    public class AuditLogActionDto : EntityDto<Guid>, IHasExtraProperties
    {
        public string ServiceName { get; set; }
        public string MethodName { get; set; }
        public string Parameters { get; set; }
        public DateTime ExecutionTime { get; set; }
        public int ExecutionDuration { get; set; }
        public ExtraPropertyDictionary ExtraProperties { get; set; }

    }
}
