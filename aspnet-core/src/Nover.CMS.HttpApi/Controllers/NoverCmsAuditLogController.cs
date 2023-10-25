using Microsoft.AspNetCore.Mvc;
using Nover.CMS.Application.Contracts;
using Nover.CMS.Application.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Nover.CMS.HttpApi.Controllers
{
    [RemoteService(Name = "AuditLogging")]
    [ControllerName("AuditLogging")]
    [Area("auditlogging")]
    [Route("/api/audit-logging/audit-logs")]
    public class NoverCmsAuditLogController : NoverCmsController, IAuditLogAppService
    {
        protected IAuditLogAppService AuditLogAppService { get; }
        public NoverCmsAuditLogController(IAuditLogAppService auditLogAppService)
        {
            AuditLogAppService = auditLogAppService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return AuditLogAppService.DeleteAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete-many")]
        public virtual Task DeleteManyAsync(Guid[] ids)
        {
            return AuditLogAppService.DeleteManyAsync(ids);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public virtual Task<AuditLogDto> GetAsync(Guid id)
        {
            return AuditLogAppService.GetAsync(id);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual Task<PagedResultDto<AuditLogDto>> GetListAsync(GetAuditLogDto input)
        {
            return AuditLogAppService.GetListAsync(input);
        }
    }
}
