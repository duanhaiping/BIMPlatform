using BIMPlatform.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace BIMPlatform.Controllers
{
    /* Inherit your controllers from this class.
     */
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public abstract class BaseController : AbpController
    {
        public string CurrentUser { get; set; }

        public string CurrentTenant { get; set; }

        public int CurrentProject { get; set; }
        protected BaseController()
        {
            LocalizationResource = typeof(BIMPlatformResource);
            CurrentUser = "687f8f01-5e29-4faf-f55c-39f60c267f5e";
            CurrentTenant = null;
            CurrentProject = 0;
        }
    }
}