using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Nover.CMS.Application.Contracts.Dtos
{
    public class AuditLogDto : ExtensibleEntityDto<Guid>
    {
        public int? HttpStatusCode { get; set; }
        public string Comments { get; set; }
        public string Exceptions { get; set; }
        public string Url { get; set; }
        public string HttpMethod { get; set; }
        public string BrowserInfo { get; set; }
        public string CorrelationId { get; set; }
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientIpAddress { get; set; }
        public int ExecutionDuration { get; set; }
        public DateTime ExecutionTime { get; set; }
        public Guid? ImpersonatorTenantId { get; set; }
        public Guid? ImpersonatorUserId { get; set; }
        public string TenantName { get; set; }
        public Guid? TenantId { get; set; }
        public string UserName { get; set; }
        public Guid? UserId { get; set; }
        public string ApplicationName { get; set; }
        public List<EntityChangeDto> EntityChanges { get; set; }
        public List<AuditLogActionDto> Actions { get; set; }
    }

    public class GetAuditLogDto : PagedAndSortedResultRequestDto
    {
        public GetAuditLogDto()
        {
        }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string HttpMethod { get; set; }
        public string Url { get; set; }
        public string UserName { get; set; }
        public string ApplicationName { get; set; }
        public string CorrelationId { get; set; }
        public int? MaxExecutionDuration { get; set; }
        public int? MinExecutionDuration { get; set; }
        public bool? HasException { get; set; }
        public HttpStatusCode? HttpStatusCode { get; set; }
        public bool IncludeDetails { get; set; }
    }
}
