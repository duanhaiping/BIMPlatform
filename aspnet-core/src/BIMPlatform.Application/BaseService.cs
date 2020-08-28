using System;
using System.Collections.Generic;
using System.Text;
using BIMPlatform.Localization;
using Volo.Abp.Application.Services;

namespace BIMPlatform
{
    /* Inherit your application services from this class.
     */
    public abstract class BaseService : ApplicationService
    {
       
        protected BaseService()
        {
           
            LocalizationResource = typeof(BIMPlatformResource);
        }
      
    }
}
