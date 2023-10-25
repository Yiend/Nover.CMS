using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Nover.CMS.Domain
{
    public interface IFileRepository : IRepository<File, Guid>
    {
        Task<File> FindByBlobNameAsync(string blobName);
    }
}