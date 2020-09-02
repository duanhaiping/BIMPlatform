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
        public int CurrentProject { get; set; }
      
    }
}