using Nover.CMS.Application.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Nover.CMS.Application.Contracts
{
    public interface IFileAppService : IApplicationService
    {
        Task<FileDto> FindByBlobNameAsync(string blobName);

        Task<string> CreateAsync(FileDto input);
    }
}
