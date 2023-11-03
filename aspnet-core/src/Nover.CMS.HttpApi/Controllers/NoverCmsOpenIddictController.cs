using Volo.Abp.Application.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Nover.CMS.HttpApi.Controllers;
using Nover.CMS.Application.Contracts;
using Nover.CMS.Application.Contracts.Dtos;

namespace EasyAbp.Abp.DynamicMenu.MenuItems
{
    [RemoteService(Name = "OpenIddict")]
    [Route("/api/identity/openid-dict")]
    public class NoverCmsOpenIddictController : NoverCmsController, IOpenIddictApplicationService
    {
        private readonly IOpenIddictApplicationService _service;

        public NoverCmsOpenIddictController(IOpenIddictApplicationService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public Task<PagedResultDto<OpenIddictApplicationDto>> GetListAsync(GetOpenIddictListInput input)
        {
           return _service.GetListAsync(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        public Task UpdateAsync(OpenIddictApplicationInput input)
        {
           return _service.UpdateAsync(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public Task CreateAsync(OpenIddictApplicationInput input)
        {
           return _service.CreateAsync(input);
        }
    }
}