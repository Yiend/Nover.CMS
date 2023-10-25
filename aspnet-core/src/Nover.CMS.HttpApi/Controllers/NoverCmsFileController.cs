using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nover.CMS.Application.Contracts;
using Nover.CMS.Application.Contracts.Dtos;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Http;

namespace Nover.CMS.HttpApi.Controllers
{

    [RemoteService]
    [Route("api/file-management/files")]
    public class NoverCmsFileController : AbpController
    {
        protected IFileAppService FileAppService { get; }

        public NoverCmsFileController(IFileAppService fileAppService)
        {
            FileAppService = fileAppService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blobName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{blobName}")]
        public virtual async Task<FileResult> GetAsync(string blobName)
        {
            var fileDto = await FileAppService.FindByBlobNameAsync(blobName);
            return File(fileDto.Bytes, MimeTypes.GetByExtension(Path.GetExtension(fileDto.FileName)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        [HttpPost]
        [Route("upload")]
        [Authorize]
        public virtual async Task<JsonResult> CreateAsync(IFormFile file)
        {
            if (file == null)
            {
                throw new UserFriendlyException("No file found!");
            }

            var bytes = await file.GetAllBytesAsync();
            var result = await FileAppService.CreateAsync(new FileDto()
            {
                Bytes = bytes,
                FileName = file.FileName
            });
            return Json(result);
        }

    }
}
