using Microsoft.AspNetCore.Authorization;
using Nover.CMS.Application.Contracts;
using Nover.CMS.Application.Contracts.Dtos;
using Nover.CMS.Domain;
using Nover.CMS.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Settings;
using Volo.Abp.Validation;

namespace Nover.CMS.Application.Files
{
    public class FileAppService : NoverCmsAppService, IFileAppService
    {
        protected IFileManager FileManager { get; }

        public FileAppService(IFileManager fileManager)
        {
            FileManager = fileManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blobName"></param>
        /// <returns></returns>
        public virtual async Task<FileDto> FindByBlobNameAsync(string blobName)
        {
            Check.NotNullOrWhiteSpace(blobName, nameof(blobName));

            var file = await FileManager.FindByBlobNameAsync(blobName);
            var bytes = await FileManager.GetBlobAsync(blobName);

            return new FileDto
            {
                Bytes = bytes,
                FileName = file.FileName
            };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize]
        public virtual async Task<string> CreateAsync(FileDto input)
        {
            await CheckFile(input);

            var file = await FileManager.CreateAsync(input.FileName, input.Bytes);

            return file.BlobName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="AbpValidationException"></exception>
        /// <exception cref="UserFriendlyException"></exception>
        protected virtual async Task CheckFile(FileDto input)
        {
            if (input.Bytes.IsNullOrEmpty())
            {
                throw new AbpValidationException("Bytes can not be null or empty!", new List<ValidationResult> {
                    new ValidationResult("Bytes can not be null or empty!", new[] { "Bytes" })
                });
            }

            var allowedMaxFileSize = await SettingProvider.GetAsync<int>(NoverCmsSettings.AllowedMaxFileSize);//kb
            var allowedUploadFormats = (await SettingProvider.GetOrNullAsync(NoverCmsSettings.AllowedUploadFormats))?.Split(",", StringSplitOptions.RemoveEmptyEntries);

            if (input.Bytes.Length > allowedMaxFileSize * 1024)
            {
                throw new UserFriendlyException(L["FileManagement.ExceedsTheMaximumSize", allowedMaxFileSize]);
            }

            if (allowedUploadFormats == null || !allowedUploadFormats.Contains(Path.GetExtension(input.FileName)))
            {
                throw new UserFriendlyException(L["FileManagement.NotValidFormat"]);
            }
        }

    }
}
