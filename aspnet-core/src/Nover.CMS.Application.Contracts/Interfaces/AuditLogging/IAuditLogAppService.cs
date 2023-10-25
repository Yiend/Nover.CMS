using Nover.CMS.Application.Contracts.Dtos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Nover.CMS.Application.Contracts
{
    public interface IAuditLogAppService : IReadOnlyAppService<AuditLogDto, Guid, GetAuditLogDto>, IDeleteAppService<Guid>
    {
        Task DeleteManyAsync(params Guid[] ids);
    }
}
